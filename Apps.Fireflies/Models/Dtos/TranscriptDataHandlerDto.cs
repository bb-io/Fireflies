namespace Apps.Fireflies.Models.Dtos;

public class TranscriptDataHandlerDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}

public class TranscriptDataHandlerApiResponseDto
{
    public TranscriptDataHandlerData Data { get; set; } = new();
}

public class TranscriptDataHandlerData
{
    public List<TranscriptDataHandlerDto> Transcripts { get; set; } = [];
}
