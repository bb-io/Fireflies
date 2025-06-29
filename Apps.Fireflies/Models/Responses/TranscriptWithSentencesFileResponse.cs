using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Fireflies.Models.Responses;

public class TranscriptWithSentencesFileResponse : TranscriptResponse
{
    [Display("Transcription sentences file")]
    public FileReference? SentencesFile { get; set; }
}
