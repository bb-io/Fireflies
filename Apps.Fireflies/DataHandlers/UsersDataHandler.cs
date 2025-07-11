﻿using Apps.Fireflies.Models.Dtos;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Fireflies.DataHandlers;

public class UsersDataHandler(InvocationContext invocationContext) : Invocable(invocationContext), IAsyncDataSourceItemHandler
{
    public async Task<IEnumerable<DataSourceItem>> GetDataAsync(DataSourceContext context, CancellationToken cancellationToken)
    {
        var query = @"
            query Users {
                users {
                    user_id
                    name
                    email
                }
            }
        ";

        var response = await Client.ExecuteQueryWithErrorHandling<UsersApiResponseDto>(query);

        var dataSourceItems = response.Data.Users
            .Select(x => new DataSourceItem(x.UserId, $"{ x.Name} ({x.Email})"));

        if (string.IsNullOrEmpty(context.SearchString))
            return dataSourceItems;

        return dataSourceItems
            .Where(x => x.DisplayName.Contains(context.SearchString, StringComparison.InvariantCultureIgnoreCase));
    }
}
