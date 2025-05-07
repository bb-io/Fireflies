using Apps.Fireflies.DataHandlers;
using Apps.Fireflies.Handlers;
using Apps.Fireflies.Models.Request;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Tests.Appname.Base;

namespace Tests.Fireflies;

[TestClass]
public class HandlerTests : TestBase
{
    [TestMethod]
    public async Task TranscriptsDataHandler_IsSuccess()
    {
       
        var handler = new TranscriptsDataHandler(InvocationContext);

        var result = await handler.GetDataAsync(new DataSourceContext {SearchString="" }, CancellationToken.None);

        Console.WriteLine($"Total: {result.Count()}");
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Value}: {item.DisplayName}");
        }

        Assert.IsTrue(result.Count() > 0);
    }
}
