using Apps.Fireflies.Models.Dtos;
using Apps.Fireflies.Models.Requests;
using Apps.Fireflies.Models.Responses;
using Apps.Fireflies.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Apps.Fireflies.Actions;

[ActionList]
public class TranscriptionActions(InvocationContext invocationContext, IFileManagementClient _fileManagementClient) : Invocable(invocationContext)
{
    [Action("Get transcription", Description = "Returns call general information, full transcription, and detailed sentence data.")]
    public async Task<TranscriptResponse> GetTranscription([ActionParameter] TranscriptionRequest input)
    {
        var query = @"
            query Transcript($transcriptId: String!) {
                transcript(id: $transcriptId) {
                    id
                    dateString
                    privacy
                    speakers { id name }
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
                    title
                    host_email
                    organizer_email
                    calendar_id
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
                    fireflies_users
                    participants
                    date
                    transcript_url
                    video_url
                    duration
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
                    cal_id
                    calendar_type
                    meeting_info {
                        fred_joined
                        silent_meeting
                        summary_status
                    }
                    apps_preview {
                        outputs { transcript_id user_id app_id created_at title prompt response }
                    }
                    meeting_link
                }
            }
        ";

        var response = await Client.ExecuteQueryWithErrorHandling<TranscriptApiResponseDto>(query, new { input.TranscriptId });

        if (response.Data?.Transcript == null)
            throw new PluginApplicationException("Failed to retrieve transcript. Please check the input and try again");

        var transcript = response.Data.Transcript;

        var sentencesJson = JsonConvert.SerializeObject(transcript.Sentences);
        var jsonBytes = Encoding.UTF8.GetBytes(sentencesJson);
        var sentencesFile = await _fileManagementClient.UploadAsync(
            new MemoryStream(jsonBytes),
            "application/json",
            $"transcript_{input.TranscriptId}_sentences.json");

        return new TranscriptResponse
        {
            Id = transcript.Id,
            DateString = transcript.DateString,
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
            SentencesFile = sentencesFile,
            MeetingDialog = TranscriptUtils.BuildTranscriptText(transcript.Sentences ?? [])
        };
    }
}