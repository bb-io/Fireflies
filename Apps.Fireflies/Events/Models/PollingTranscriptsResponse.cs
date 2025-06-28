using Apps.Fireflies.Models.Responses;
using Newtonsoft.Json;

namespace Apps.Fireflies.Events.Models;

public class PollingTranscriptsResponse(IEnumerable<TranscriptResponse> transcripts)
{
    [JsonProperty("transcripts")]
    public IEnumerable<TranscriptResponse> Transcripts { get; } = transcripts;
}
