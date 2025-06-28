using Apps.Fireflies.Models.Response;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Fireflies.DataHandlers
{
    public class UsersDataHandler(InvocationContext invocationContext) : Invocable(invocationContext), IAsyncDataSourceItemHandler
    {
        public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
        {
            var response = await Client.ExecuteQueryWithErrorHandling<UsersDatahandlerResponse>(@"
                query Users {
                    users {
                        user_id
                        name
                        email
                    }
                }
            ");

            var dataSourceItems = response.Data.Users
                .Select(x => new DataSourceItem(x.UserId, $"{x.Name} ({x.Email})"))
                .ToList();

            if (string.IsNullOrEmpty(context.SearchString))
                return dataSourceItems;

            return dataSourceItems
                .Where(x => x.DisplayName.Contains(context.SearchString, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
