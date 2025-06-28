using Apps.Fireflies.Models.Dtos;
using System.Text;

namespace Apps.Fireflies.Utils;

public static class TranscriptUtils
{
    public static string BuildTranscriptText(IEnumerable<Sentence> sentences)
    {
        var dialogueBuilder = new StringBuilder();
        foreach (var sentence in sentences)
        {
            dialogueBuilder.AppendLine($"{sentence.SpeakerName}: {sentence.Text}");
        }
        return dialogueBuilder.ToString();
    }
}
