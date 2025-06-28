using Apps.Fireflies.Models.Response;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Fireflies.DataHandlers;

public class TranscriptsDataHandler : Invocable, IAsyncDataSourceItemHandler
{
    readonly string _userId;
    public TranscriptsDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
        _userId = GetUserIdAsync().GetAwaiter().GetResult();
    }

    private async Task<string> GetUserIdAsync()
    {
        var query = @"
                { 
                    user {
                        user_id
                        name
                    }
                }
            ";

        var response = await Client.ExecuteQueryWithErrorHandling<UserResponse>(query);

        return response.Data.User?.UserId ?? throw new Exception("Failed to retrieve user ID");
    }

    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
    {
        var query = @"
            query Transcripts($userId: String) {
                transcripts(user_id: $userId) {
                    title
                    id
                }
            }
        ";

        var response = await Client.ExecuteQueryWithErrorHandling<TranscriptsResponse>(query, new { _userId });

        var transcripts = response.Data.Transcripts
            .Select(x => new DataSourceItem(x.Id, x.Title));

        if (string.IsNullOrEmpty(context.SearchString))
            return transcripts;

        return transcripts
            .Where(x => x.DisplayName.Contains(context.SearchString, StringComparison.InvariantCultureIgnoreCase));
    }
}
