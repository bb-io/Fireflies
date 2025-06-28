using Apps.Fireflies.Polling;
using Apps.Fireflies.Polling.Models;
using Blackbird.Applications.Sdk.Common.Polling;
using Tests.Appname.Base;

namespace Tests.Fireflies
{
    [TestClass]
    public class PollingTests : TestBase
    {
        private readonly PollingList _pollingList;

        public PollingTests() : base()
        {
            _pollingList = new PollingList(InvocationContext);
        }

        [TestMethod]
        public async Task PollingTranscriptsResponse_DontFlyOnFirstRun()
        {
            var request = new PollingEventRequest<DateMemory> { Memory = null };
            var input = new PollingTranscriptsRequest {};

            var response = await _pollingList.OnTranscriptionCompleted(request, input);

            Assert.IsFalse(response.FlyBird);
            Assert.IsNotNull(response.Memory);
        }

        [TestMethod]
        public async Task PollingTranscriptsResponse_IsSuccess()
        {
            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = DateTime.UtcNow.AddDays(-5)
                }
            };

            var input = new PollingTranscriptsRequest {};

            var response = await _pollingList.OnTranscriptionCompleted(request, input);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PollingTranscriptsResponse_FiltersByEmail()
        {
            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = DateTime.UtcNow.AddDays(-5)
                }
            };

            var input = new PollingTranscriptsRequest {
                IgnoreWhenAllFromEmailDomain = "blackbird.io",
            };

            var response = await _pollingList.OnTranscriptionCompleted(request, input);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PollingTranscriptsResponse_FiltersByTitle()
        {
            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = DateTime.UtcNow.AddDays(-5)
                }
            };

            var input = new PollingTranscriptsRequest
            {
                IgnoreWhenTitleContains = ["Solution team standup", "Solutions sync-up"],
            };

            var response = await _pollingList.OnTranscriptionCompleted(request, input);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PollingTranscriptsResponse_FiltersByUser()
        {
            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = DateTime.UtcNow.AddDays(-5)
                }
            };

            var input = new PollingTranscriptsRequest
            {
                UserId = "01JXAJHAW82SRT6TY1ANQNBVQP", // Alex Terekhov
            };

            var response = await _pollingList.OnTranscriptionCompleted(request, input);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PollingTranscriptsResponse_FiltersByAllInputsAtOnce()
        {
            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = DateTime.UtcNow.AddDays(-5)
                }
            };

            var input = new PollingTranscriptsRequest
            {
                UserId = "01JXAJHAW82SRT6TY1ANQNBVQP", // Alex Terekhov
                IgnoreWhenTitleContains = ["Solution team standup", "Solutions sync-up"],
                IgnoreWhenAllFromEmailDomain = "blackbird.io",
            };

            var response = await _pollingList.OnTranscriptionCompleted(request, input);

            Assert.IsNotNull(response);
        }
    }
}
