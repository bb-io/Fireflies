using Newtonsoft.Json;

namespace Apps.Fireflies.Polling.Models
{
    public class PollingTranscriptsResponse
    {
        [JsonProperty("transcripts")]
        public IEnumerable<TranscriptDto> Transcripts { get; }

        public PollingTranscriptsResponse(IEnumerable<TranscriptDto> transcripts)
        {
            Transcripts = transcripts;
        }
    }
}
