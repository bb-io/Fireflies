using Apps.Fireflies.Models.Response;
using Newtonsoft.Json;

namespace Apps.Fireflies.Polling.Models
{
    public class PollingTranscriptsResponse(IEnumerable<TranscriptResponse> transcripts)
    {
        [JsonProperty("transcripts")]
        public IEnumerable<TranscriptResponse> Transcripts { get; } = transcripts;
    }
}
