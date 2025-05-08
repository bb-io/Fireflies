using Apps.Fireflies.Models.Request;
using Apps.Fireflies.Models.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Fireflies.DataHandlers
{
    public class TranscriptsDataHandler : Invocable, IAsyncDataSourceItemHandler
    {
        readonly string _userId;
        public TranscriptsDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
            _userId = GetUserIdAsync().GetAwaiter().GetResult();
        }

        private async Task<string> GetUserIdAsync()
        {
            var request = new RestRequest
            {
                Method = Method.Post
            };
            request.AddHeader("Content-Type", "application/json")
                   .AddJsonBody(new
                   {
                       query = "{ user { name user_id } }"
                   });

            var response = await Client.ExecuteWithErrorHandling<UserResponse>(request);
            return response.Data.User?.UserId ?? throw new Exception("Failed to retrieve user ID");
        }

        public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
        {
            var request = new RestRequest
            {
                Method = Method.Post
            };
            request.AddHeader("Content-Type", "application/json");

            var graphqlQuery = new
            {
                query = @"
                    query Transcripts($userId: String) {
                        transcripts(user_id: $userId) {
                            title
                            id
                        }
                    }",
                variables = new { _userId }
            };

            request.AddJsonBody(graphqlQuery);

            var response = await Client.ExecuteWithErrorHandling<TranscriptsResponse>(request);

            return response.Data.Transcripts
                .Where(x => context.SearchString == null || x.Title.Contains(context.SearchString, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => new DataSourceItem(x.Id, x.Title));
        }
    }
}
