using Apps.Fireflies.Models.Dtos;
using Apps.Fireflies.Models.Requests;
using Apps.Fireflies.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Fireflies.Actions;

[ActionList]
public class ParticipantActions(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [Action("Get call participants", Description = "Get attendee names and emails, participant emails, and recorded attendance for a transcript.")]
    public async Task<CallParticipantsResponse> GetCallParticipants([ActionParameter] TranscriptionRequest input)
    {
        const string query = @"
            query Transcript($transcriptId: String!) {
                transcript(id: $transcriptId) {
                    participants
                    meeting_attendees { name displayName email }
                    meeting_attendance { name }
                }
            }";

        var response = await Client.ExecuteQueryWithErrorHandling<CallParticipantsApiResponse>(query, new { input.TranscriptId });
        if (response.Errors?.Count > 0)
            throw new PluginApplicationException(string.Join(", ", response.Errors.Select(x => x.Message)));

        var transcript = response.Data?.Transcript
            ?? throw new PluginApplicationException("Failed to retrieve transcript. Please check the input and try again.");

        return new CallParticipantsResponse
        {
            Attendees = transcript.MeetingAttendees ?? [],
            ParticipantEmails = transcript.Participants ?? [],
            Attendance = transcript.MeetingAttendance ?? []
        };
    }
}
