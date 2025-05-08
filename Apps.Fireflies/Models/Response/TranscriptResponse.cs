using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Fireflies.Models.Response
{
    public class TranscriptResponse
    {
        [Display("Transcript ID")]
        public string Id { get; set; }

        [Display("String date")]
        public string DateString { get; set; }
        public string Privacy { get; set; }
        public string Title { get; set; }

        [Display("Host mail")]
        public string HostEmail { get; set; }

        [Display("Organizer email")]
        public string OrganizerEmail { get; set; }

        [Display("Calendar ID")]
        public string CalendarId { get; set; }

        [Display("Date")]
        public long Date { get; set; }

        [Display("Transcript URL")]
        public string TranscriptUrl { get; set; }
        public double Duration { get; set; }

        [Display("Call ID")]
        public string CalId { get; set; }

        [Display("Calendar type")]
        public string CalendarType { get; set; }

        [Display("Meeting link")]
        public string MeetingLink { get; set; }

        [Display("JSON file")]
        public FileReference JsonFile { get; set; }
    }
}
