namespace Apps.Fireflies.Models.Response;

public class TranscriptsResponse
{
    public TranscriptData Data { get; set; } = new();
}
public class TranscriptData
{
    public List<Transcript> Transcripts { get; set; } = [];
}
public class Transcript
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}
