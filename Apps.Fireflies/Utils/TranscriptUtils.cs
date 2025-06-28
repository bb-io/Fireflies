using Apps.Fireflies.Models.Response;
using System.Text;

namespace Apps.Fireflies.Utils;

public static class TranscriptUtils
{
    public static string BuildMeetingDialog(IEnumerable<Sentence> sentences)
    {
        var dialogueBuilder = new StringBuilder();
        foreach (var sentence in sentences)
        {
            dialogueBuilder.AppendLine($"{sentence.SpeakerName}: {sentence.Text}");
        }
        return dialogueBuilder.ToString();
    }
}
