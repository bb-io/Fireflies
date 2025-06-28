using Apps.Fireflies.DataHandlers;
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

        var result = await handler.GetDataAsync(new DataSourceContext { SearchString = "" }, CancellationToken.None);

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public async Task UsersDataHandler_IsSuccess()
    {
        var handler = new UsersDataHandler(InvocationContext);

        var result = await handler.GetDataAsync(new DataSourceContext { SearchString = "" }, CancellationToken.None);

        Assert.IsTrue(result.Any());
    }
}
