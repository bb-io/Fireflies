using Apps.Fireflies.Actions;
using Apps.Fireflies.Models.Request;
using Tests.Fireflies.Base;

namespace Tests.Fireflies;

[TestClass]
public class TranscriptionTests : TestBase
{
    [TestMethod]
    public async Task GetTranscript_IsSuccess()
    {
        var input = new TranscriptRequest
        {
            TranscriptId = "01JXCYPEKZRBBFXZ08J57GQTHG"
        };

        var actions = new TranscriptionActions(InvocationContext, FileManager);
        var result = await actions.GetTranscription(input);

        Assert.IsNotNull(result);
    }
}
