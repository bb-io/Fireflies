using Apps.Fireflies.Models.Dtos;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Fireflies.Models.Responses;

public class CallParticipantsResponse
{
    [Display("Attendees", Description = "Attendee details returned by Fireflies; inclusion does not confirm that the person joined.")]
    public List<CallAttendee> Attendees { get; set; } = [];

    [Display("Participant emails", Description = "Email addresses from the Fireflies participants field.")]
    public List<string> ParticipantEmails { get; set; } = [];

    [Display("Recorded attendance", Description = "Names from Fireflies meeting attendance records; emails are not provided for these records.")]
    public List<CallAttendance> Attendance { get; set; } = [];
}

public class CallAttendee
{
    public string? Name { get; set; }

    [Display("Display name")]
    public string? DisplayName { get; set; }

    public string? Email { get; set; }
}

public class CallAttendance
{
    public string? Name { get; set; }
}

public class CallParticipantsApiResponse
{
    public CallParticipantsApiData? Data { get; set; }
    public List<ErrorDto>? Errors { get; set; }
}

public class CallParticipantsApiData
{
    public CallParticipantsApiTranscript? Transcript { get; set; }
}

public class CallParticipantsApiTranscript
{
    public List<string>? Participants { get; set; }

    [JsonProperty("meeting_attendees")]
    public List<CallAttendee>? MeetingAttendees { get; set; }

    [JsonProperty("meeting_attendance")]
    public List<CallAttendance>? MeetingAttendance { get; set; }
}
