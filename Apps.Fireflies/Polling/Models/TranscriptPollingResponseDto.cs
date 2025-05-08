using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Fireflies.Polling.Models
{
    public class TranscriptPollingResponseDto
    {
        [JsonProperty("data")]
        public TranscriptDataDto Data { get; set; }
    }
    public class TranscriptDataDto
    {
        [JsonProperty("transcripts")]
        public IEnumerable<TranscriptDto> Transcripts { get; set; }
    }

    public class TranscriptDto
    {
        [Display("Transcript ID")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [Display("Title")]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Display("Date")]
        [JsonProperty("date")]
        public long Date { get; set; }

        [Display("Date string")]
        [JsonProperty("dateString")]
        public string DateString { get; set; }

        [Display("Host email")]
        [JsonProperty("host_email")]
        public string HostEmail { get; set; }

        [Display("Organizer email")]
        [JsonProperty("organizer_email")]
        public string OrganizerEmail { get; set; }

        [Display("Meeting attendees")]
        [JsonProperty("meeting_attendees")]
        public IEnumerable<AttendeeDto> MeetingAttendees { get; set; }

        [Display("Meeting link")]
        [JsonProperty("meeting_link")]
        public string MeetingLink { get; set; }
    }
    public class AttendeeDto
    {
        [Display("Display name")]
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [Display("Email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Display("Phone number")]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Display("Name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display("Location")]
        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
