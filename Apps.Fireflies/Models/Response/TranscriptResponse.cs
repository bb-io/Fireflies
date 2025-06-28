using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Fireflies.Models.Response
{
    public class TranscriptResponse
    {
        [Display("Transcript ID")]
        public string Id { get; set; }

        [Display("Date")]
        public string DateString { get; set; }
        public string Privacy { get; set; }
        public string Title { get; set; }

        [Display("Host mail")]
        public string HostEmail { get; set; }

        [Display("Organizer email")]
        public string OrganizerEmail { get; set; }

        [Display("Calendar ID")]
        public string CalendarId { get; set; }

        [Display("Transcript URL")]
        public string TranscriptUrl { get; set; }

        [Display("Video URL")]
        public string VideoUrl { get; set; }

        public int Duration { get; set; }

        [Display("Call ID")]
        public string CalId { get; set; }

        [Display("Calendar type")]
        public string CalendarType { get; set; }

        [Display("Meeting link")]
        public string MeetingLink { get; set; }

        [Display("Transcript file")]
        public FileReference SentencesFile { get; set; }

        [Display("Meeting dialog")]
        public string MeetingDialog { get; set; }
    }
}
