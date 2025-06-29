using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Fireflies.Models.Responses;

public class TranscriptResponse
{
    [Display("Transcript ID")]
    public string Id { get; set; } = string.Empty;

    [Display("Call title")]
    public string Title { get; set; } = string.Empty;

    [Display("Call date (UTC)")]
    public DateTime CallDate { get; set; }

    [Display("Call duration (minutes)")]
    public int Duration { get; set; }

    [Display("Transcript URL")]
    public string TranscriptUrl { get; set; } = string.Empty;

    [Display("Video URL")]
    public string VideoUrl { get; set; } = string.Empty;

    [Display("Transcription sentences file")]
    public FileReference? SentencesFile { get; set; }

    [Display("Transcription text")]
    public string MeetingDialog { get; set; } = string.Empty;

    public string Privacy { get; set; } = string.Empty;

    [Display("Call ID")]
    public string CalId { get; set; } = string.Empty;

    [Display("Host mail")]
    public string HostEmail { get; set; } = string.Empty;

    [Display("Organizer email")]
    public string OrganizerEmail { get; set; } = string.Empty;

    [Display("Calendar ID")]
    public string CalendarId { get; set; } = string.Empty;

    [Display("Calendar type")]
    public string CalendarType { get; set; } = string.Empty;

    [Display("Meeting link")]
    public string MeetingLink { get; set; } = string.Empty;
}
