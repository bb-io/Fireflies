using Apps.Fireflies.Api;
using Apps.Fireflies.Models.Response;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Fireflies.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = @"
                { 
                    user {
                        user_id
                        name
                    }
                }
            ";

            var client = new FirefliesClient(authenticationCredentialsProviders);
            var response = await client.ExecuteQueryWithErrorHandling<UserResponse>(query);

            return new()
            {
                IsValid = !string.IsNullOrEmpty(response.Data.User?.UserId),
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