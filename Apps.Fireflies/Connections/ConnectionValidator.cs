using Apps.Fireflies.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.Fireflies.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        try
        {
            var client = new FirefliesClient(authenticationCredentialsProviders);

            var request = new RestRequest
            {
                Method = Method.Post
            };
            request.AddHeader("Content-Type", "application/json")
                   .AddJsonBody(new
                   {
                        query = "{ user { name user_id } }"
                   });

            await client.ExecuteWithErrorHandling(request);

            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }

    }
}