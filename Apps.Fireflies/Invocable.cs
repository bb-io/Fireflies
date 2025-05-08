using Apps.Fireflies.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Fireflies;

public class Invocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected FirefliesClient Client { get; }
    public Invocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new(Creds);
    }
}