﻿using Newtonsoft.Json;

namespace Apps.Fireflies.Models.Dtos;

public class TranscriptDto
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("dateString")]
    public DateTime Date { get; set; }

    [JsonProperty("privacy")]
    public string Privacy { get; set; } = string.Empty;

    [JsonProperty("speakers")]
    public List<Speaker> Speakers { get; set; } = [];

    [JsonProperty("sentences")]
    public List<Sentence> Sentences { get; set; } = [];

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("host_email")]
    public string HostEmail { get; set; } = string.Empty;

    [JsonProperty("organizer_email")]
    public string OrganizerEmail { get; set; } = string.Empty;

    [JsonProperty("calendar_id")]
    public string CalendarId { get; set; } = string.Empty;

    [JsonProperty("user")]
    public User User { get; set; } = new();

    [JsonProperty("fireflies_users")]
    public List<string> FirefliesUsers { get; set; } = [];

    [JsonProperty("participants")]
    public List<string> Participants { get; set; } = [];

    [JsonProperty("transcript_url")]
    public string TranscriptUrl { get; set; } = string.Empty;

    [JsonProperty("video_url")]
    public string VideoUrl { get; set; } = string.Empty;

    [JsonProperty("duration")]
    public double Duration { get; set; } = 0;

    [JsonProperty("meeting_attendees")]
    public List<MeetingAttendee> MeetingAttendees { get; set; } = [];

    [JsonProperty("summary")]
    public Summary Summary { get; set; } = new();

    [JsonProperty("cal_id")]
    public string CalId { get; set; } = string.Empty;

    [JsonProperty("calendar_type")]
    public string CalendarType { get; set; } = string.Empty;

    [JsonProperty("meeting_info")]
    public MeetingInfo MeetingInfo { get; set; } = new();

    [JsonProperty("meeting_link")]
    public string MeetingLink { get; set; } = string.Empty;
}

public class Speaker
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}

public class Sentence
{
    [JsonProperty("index")]
    public int Index { get; set; }

    [JsonProperty("speaker_name")]
    public string SpeakerName { get; set; } = string.Empty;

    [JsonProperty("speaker_id")]
    public int SpeakerId { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; } = string.Empty;

    [JsonProperty("raw_text")]
    public string RawText { get; set; } = string.Empty;

    [JsonProperty("start_time")]
    public double StartTime { get; set; }

    [JsonProperty("end_time")]
    public double EndTime { get; set; }

    [JsonProperty("ai_filters")]
    public AiFilters AiFilters { get; set; } = new();
}

public class AiFilters
{
    [JsonProperty("task")]
    public string Task { get; set; } = string.Empty;

    [JsonProperty("pricing")]
    public string Pricing { get; set; } = string.Empty;

    [JsonProperty("metric")]
    public string Metric { get; set; } = string.Empty;

    [JsonProperty("question")]
    public string Question { get; set; } = string.Empty;

    [JsonProperty("date_and_time")]
    public string DateAndTime { get; set; } = string.Empty;

    [JsonProperty("text_cleanup")]
    public string TextCleanup { get; set; } = string.Empty;

    [JsonProperty("sentiment")]
    public string Sentiment { get; set; } = string.Empty;
}

public class User
{
    [JsonProperty("user_id")]
    public string UserId { get; set; } = string.Empty;

    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("num_transcripts")]
    public int? NumTranscripts { get; set; }

    [JsonProperty("recent_meeting")]
    public string? RecentMeeting { get; set; }

    [JsonProperty("minutes_consumed")]
    public double? MinutesConsumed { get; set; }

    [JsonProperty("is_admin")]
    public bool? IsAdmin { get; set; }

    [JsonProperty("integrations")]
    public object? Integrations { get; set; }
}

public class MeetingAttendee
{
    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("location")]
    public string? Location { get; set; }
}

public class Summary
{
    [JsonProperty("keywords")]
    public IEnumerable<string> Keywords { get; set; } = [];

    [JsonProperty("action_items")]
    public string? ActionItems { get; set; }

    [JsonProperty("outline")]
    public string? Outline { get; set; }

    [JsonProperty("shorthand_bullet")]
    public string? ShorthandBullet { get; set; }

    [JsonProperty("overview")]
    public string? Overview { get; set; }

    [JsonProperty("bullet_gist")]
    public string? BulletGist { get; set; }

    [JsonProperty("gist")]
    public string? Gist { get; set; }

    [JsonProperty("short_summary")]
    public string? ShortSummary { get; set; }

    [JsonProperty("short_overview")]
    public string? ShortOverview { get; set; }

    [JsonProperty("meeting_type")]
    public string? MeetingType { get; set; }

    [JsonProperty("topics_discussed")]
    public string? TopicsDiscussed { get; set; }

    [JsonProperty("transcript_chapters")]
    public IEnumerable<string> TranscriptChapters { get; set; } = [];
}

public class MeetingInfo
{
    [JsonProperty("fred_joined")]
    public bool? FredJoined { get; set; }

    [JsonProperty("silent_meeting")]
    public bool? SilentMeeting { get; set; }

    [JsonProperty("summary_status")]
    public string? SummaryStatus { get; set; }
}

public class TranscriptApiResponseDto
{
    [JsonProperty("data")]
    public TranscriptApiResponseData Data { get; set; } = new();
}

public class TranscriptApiResponseData
{
    [JsonProperty("transcript")]
    public TranscriptDto Transcript { get; set; } = new();
}

public class TranscriptsApiResponseDto
{
    public TranscriptsApiResponseData Data { get; set; } = new();
}

public class TranscriptsApiResponseData
{
    public List<TranscriptDto> Transcripts { get; set; } = [];
}
