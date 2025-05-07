using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Fireflies.Models.Response
{
    public class TranscriptResponse
    {
        public string Id { get; set; }
        public string DateString { get; set; }
        public string Privacy { get; set; }
        public string Title { get; set; }
        public string HostEmail { get; set; }
        public string OrganizerEmail { get; set; }
        public string CalendarId { get; set; }
        public long Date { get; set; }
        public string TranscriptUrl { get; set; }
        public double Duration { get; set; }
        public string CalId { get; set; }
        public string CalendarType { get; set; }
        public string MeetingLink { get; set; }
        public FileReference JsonFile { get; set; }
    }
}
