using Apps.Fireflies.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Fireflies.Api;

public class FirefliesClient : BlackBirdRestClient
{
    public FirefliesClient(IEnumerable<AuthenticationCredentialsProvider> creds) : base(new()
    {
        BaseUrl = new Uri("https://api.fireflies.ai/graphql"),
        MaxTimeout = 180000
    })
    {
        this.AddDefaultHeader("Authorization", $"Bearer {creds.Get(CredsNames.ApiToken).Value}");
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var error = JsonConvert.DeserializeObject(response.Content);

        throw new PluginApplicationException(error.ToString());
    }

    public async Task<T> ExecuteQueryWithErrorHandling<T>(string query, object? variables = null)
    {
        var request = new RestRequest
        {
            Method = Method.Post
        };
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new { query, variables });

        return await ExecuteWithErrorHandling<T>(request);
    }

    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        string content = (await ExecuteWithErrorHandling(request)).Content;
        T val = JsonConvert.DeserializeObject<T>(content, JsonSettings);
        if (val == null)
        {
            throw new Exception($"Could not parse {content} to {typeof(T)}");
        }

        return val;
    }

    public override async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        int retryCount = 3;
        int attempt = 0;
        Exception lastException = null;

        while (attempt < retryCount)
        {
            try
            {
                RestResponse restResponse = await ExecuteAsync(request);
                if (!restResponse.IsSuccessStatusCode)
                {
                    throw ConfigureErrorException(restResponse);
                }
                return restResponse;
            }
            catch (Exception ex)
            {
                lastException = ex;
                attempt++;

            }
        }
        throw lastException;
    }
}