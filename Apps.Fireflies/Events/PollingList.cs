using Apps.Fireflies.Models.Responses;
using Apps.Fireflies.Events.Models;
using Apps.Fireflies.Utils;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using Apps.Fireflies.Models.Dtos;

namespace Apps.Fireflies.Events;

[PollingEventList]
public class PollingList(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [PollingEvent("On transcription completed", Description ="Starts a flight when transcription is competed")]
    public async Task<PollingEventResponse<DateMemory, PollingTranscriptsResponse>> OnTranscriptionCompleted(
        PollingEventRequest<DateMemory> request,
        [PollingEventParameter] PollingTranscriptsRequest input)
    {
        // First run, initialize memory and return early
        if (request.Memory == null)
        {
            return new PollingEventResponse<DateMemory, PollingTranscriptsResponse>
            {
                FlyBird = false,
                Memory = new DateMemory { LastInteractionDate = DateTime.UtcNow }
            };
        }

        // Main logic
        var query = @"
            query Transcripts($userId: String, $fromDate: DateTime) {
                transcripts(user_id: $userId, fromDate: $fromDate) {
                    id
                    dateString
                    title
                    host_email
                    organizer_email
                    calendar_id
                    fireflies_users
                    participants
                    transcript_url
                    video_url
                    duration
                    cal_id
                    calendar_type
                    meeting_link
                    privacy
                    speakers {
                        id
                        name
                    }
                    sentences {
                        index
                        speaker_name
                        speaker_id
                        text
                        raw_text
                        start_time
                        end_time
                        ai_filters {
                            task
                            pricing
                            metric
                            question
                            date_and_time
                            text_cleanup
                            sentiment
                        }
                    }
                    user {
                        user_id
                        email
                        name
                        num_transcripts
                        recent_meeting
                        minutes_consumed
                        is_admin
                        integrations
                    }
                    meeting_attendees {
                        displayName
                        email
                        phoneNumber
                        name
                        location
                    }
                    summary {
                        keywords
                        action_items
                        outline
                        shorthand_bullet
                        overview
                        bullet_gist
                        gist
                        short_summary
                        short_overview
                        meeting_type
                        topics_discussed
                        transcript_chapters
                    }
                    meeting_info {
                        fred_joined
                        silent_meeting
                        summary_status
                    }
                    apps_preview {
                        outputs {
                            transcript_id
                            user_id
                            app_id
                            created_at
                            title
                            prompt
                            response
                        }
                    }
                }
            }
        ";

        var variables = new
        {
            userId = input.UserId,
            fromDate = request.Memory.LastInteractionDate.ToString("o")
        };

        var transcriptResponse = await Client.ExecuteQueryWithErrorHandling<TranscriptsApiResponseDto>(query, variables);
        var transcripts = transcriptResponse.Data.Transcripts.ToArray();

        var matchingTranscripts = new List<TranscriptResponse>();
        foreach (var transcript in transcripts)
        {
            if (transcript.Date.ToUniversalTime() <= request.Memory.LastInteractionDate)
                continue;

            if (!string.IsNullOrEmpty(input.IgnoreWhenAllFromEmailDomain)
                && !transcript.MeetingAttendees.Any(a => !a.Email?.Contains(input.IgnoreWhenAllFromEmailDomain, StringComparison.OrdinalIgnoreCase) ?? false))
                continue;

            if (input.IgnoreWhenTitleContains != null
                && input.IgnoreWhenTitleContains.Any(ignore => transcript.Title.Contains(ignore, StringComparison.OrdinalIgnoreCase)))
                continue;

            matchingTranscripts.Add(new TranscriptResponse
            {
                Id = transcript.Id,
                CallDate = transcript.Date.ToUniversalTime(),
                Privacy = transcript.Privacy,
                Title = transcript.Title,
                HostEmail = transcript.HostEmail,
                OrganizerEmail = transcript.OrganizerEmail,
                CalendarId = transcript.CalendarId,
                TranscriptUrl = transcript.TranscriptUrl,
                VideoUrl = transcript.VideoUrl,
                Duration = (int)Math.Ceiling(transcript.Duration),
                CalId = transcript.CalId,
                CalendarType = transcript.CalendarType,
                MeetingLink = transcript.MeetingLink,
                SentencesFile = null,
                MeetingDialog = TranscriptUtils.BuildTranscriptText(transcript.Sentences ?? [])
            });
        }

        if (matchingTranscripts.Count == 0)
        {
            return new PollingEventResponse<DateMemory, PollingTranscriptsResponse>
            {
                FlyBird = false,
                Memory = request.Memory
            };
        }

        var newMaxDate = matchingTranscripts.Max(t => t.CallDate);
        request.Memory.LastInteractionDate = newMaxDate;

        return new PollingEventResponse<DateMemory, PollingTranscriptsResponse>
        {
            FlyBird = true,
            Memory = request.Memory,
            Result = new PollingTranscriptsResponse(matchingTranscripts)
        };
    }
}
