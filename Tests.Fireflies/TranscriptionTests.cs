using Apps.Fireflies.Actions;
using Apps.Fireflies.Models.Request;
using Newtonsoft.Json;
using Tests.Appname.Base;

namespace Tests.Fireflies;

[TestClass]
public class TranscriptionTests : TestBase
{
    [TestMethod]
    public async Task GetTranscript_IsSuccess()
    {

        var action = new TranscriptionActions(InvocationContext, FileManager);
        var input = new TranscriptRequest
        {
            TranscriptId = "01JXCYPEKZRBBFXZ08J57GQTHG"
        };
        var result = await action.GetTranscription(input);

        var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented);
        Console.WriteLine("TranscriptActionResponse:");
        Console.WriteLine(resultJson);

        Assert.IsNotNull(result);
    }
}
