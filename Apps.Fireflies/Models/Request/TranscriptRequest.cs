using Apps.Fireflies.DataHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Fireflies.Models.Request;

public class TranscriptRequest
{
    [Display("Transcript ID")]
    [DataSource(typeof(TranscriptsDataHandler))]
    public string TranscriptId { get; set; } = string.Empty;
}
