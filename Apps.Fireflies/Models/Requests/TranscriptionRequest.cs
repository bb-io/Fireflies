using Apps.Fireflies.DataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Fireflies.Models.Requests;

public class TranscriptionRequest
{
    [Display("Transcript ID")]
    [DataSource(typeof(TranscriptsDataHandler))]
    public string TranscriptId { get; set; } = string.Empty;
}
