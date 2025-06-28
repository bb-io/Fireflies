using Apps.Fireflies.Models.Response;

namespace Apps.Fireflies.Polling.Models;

public class TranscriptPollingResponseDto
{
    public TranscriptsDataDto Data { get; set; } = new();
}

public class TranscriptsDataDto
{
    public List<TranscriptDto> Transcripts { get; set; } = new();
}
