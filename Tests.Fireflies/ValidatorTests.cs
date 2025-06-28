using Apps.Fireflies.Connections;
using Blackbird.Applications.Sdk.Common.Authentication;
using Tests.Appname.Base;

namespace Tests.Fireflies;

[TestClass]
public class ConnectionValidatorTests : TestBase
{
    [TestMethod]
    public async Task ValidateConnection_ValidData_ShouldBeSuccessful()
    {
        var validator = new ConnectionValidator();
        var result = await validator.ValidateConnection(Creds, CancellationToken.None);

        Assert.IsTrue(result.IsValid);
    }

    [TestMethod]
    public async Task ValidateConnection_InvalidData_ShouldFail()
    {
        
        var newCredentials = Creds
            .Select(x => new AuthenticationCredentialsProvider(x.KeyName, x.Value + "_incorrect"));

        var validator = new ConnectionValidator();
        var result = await validator.ValidateConnection(newCredentials, CancellationToken.None);

        Assert.IsFalse(result.IsValid);
    }
}