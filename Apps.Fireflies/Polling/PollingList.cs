using Apps.Fireflies.Models.Response;
using Apps.Fireflies.Polling.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;

namespace Apps.Fireflies.Polling
{
    [PollingEventList]
    public class PollingList : Invocable
    {
        public PollingList(InvocationContext invocationContext) : base(invocationContext)
        {
        }


        [PollingEvent("On transcription completed", Description ="Triggers when transcription competed")]
        public async Task<PollingEventResponse<DateMemory, PollingTranscriptsResponse>> OnTranscriptionCompleted(PollingEventRequest<DateMemory> request)
        {
            var userRequest = new RestRequest
            {
                Method = Method.Post
            };
            userRequest.AddHeader("Content-Type", "application/json")
                .AddJsonBody(new
                {
                    query = "{ user { user_id } }"
                });

            var userResponse = await Client.ExecuteWithErrorHandling<UserResponse>(userRequest);
            var userId = userResponse.Data.User.UserId;

            var transcriptQuery = @"query Transcripts($userId: String) {
                transcripts(user_id: $userId) {
                    title
                    id
                    date
                    dateString
                    host_email
                    organizer_email
                    meeting_attendees {
                        displayName
                        email
                        phoneNumber
                        name
                        location
                    }
                    meeting_link
                }
            }";

            var transcriptRequest = new RestRequest
            {
                Method = Method.Post
            };
            transcriptRequest.AddJsonBody(new
            {
                query = transcriptQuery,
                variables = new { userId }
            });

            var transcriptResponse = await Client.ExecuteWithErrorHandling<TranscriptPollingResponseDto>(transcriptRequest);
            var transcripts = transcriptResponse.Data.Transcripts.ToArray();

            if (request.Memory == null)
            {
                var maxDate = transcripts.Any()
                    ? transcripts.Max(t => DateTime.Parse(t.DateString).ToUniversalTime())
                    : DateTime.UtcNow;

                return new PollingEventResponse<DateMemory, PollingTranscriptsResponse>
                {
                    FlyBird = false,
                    Memory = new DateMemory { LastInteractionDate = maxDate }
                };
            }

            var newTranscripts = transcripts
                .Where(t => DateTime.Parse(t.DateString).ToUniversalTime() > request.Memory.LastInteractionDate)
                .ToArray();

            if (newTranscripts.Any())
            {
                var newMaxDate = newTranscripts.Max(t => DateTime.Parse(t.DateString).ToUniversalTime());
                request.Memory.LastInteractionDate = newMaxDate;

                return new PollingEventResponse<DateMemory, PollingTranscriptsResponse>
                {
                    FlyBird = true,
                    Memory = request.Memory,
                    Result = new PollingTranscriptsResponse(newTranscripts)
                };
            }

            return new PollingEventResponse<DateMemory, PollingTranscriptsResponse>
            {
                FlyBird = false,
                Memory = request.Memory
            };
        }
    }
}
