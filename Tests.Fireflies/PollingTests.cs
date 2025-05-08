using Apps.Fireflies.Polling.Models;
using Apps.Fireflies.Polling;
using Blackbird.Applications.Sdk.Common.Polling;
using Tests.Appname.Base;
using Newtonsoft.Json;

namespace Tests.Fireflies
{
    [TestClass]
    public class PollingTests : TestBase
    {
        [TestMethod]
        public async Task PollingTranscriptsResponse_IsSuccess()
        {
            var polling = new PollingList(InvocationContext);
            var oldDate = DateTime.UtcNow.AddHours(-5);
            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = oldDate
                }
            };

            var response = polling.OnTranscriptionCompleted(request);
            var serializedResponse = JsonConvert.SerializeObject(response.Result);
            Console.WriteLine(serializedResponse);

            Assert.IsNotNull(response);
        }
    }
}
