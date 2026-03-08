using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class DialogDatabase : MonoBehaviour
{
    private Dictionary<string, DialogSequence> _sequences = new();

    public void LoadFromCsv(TextAsset csvFile)
    {
        _sequences.Clear();

        string[] rows = csvFile.text.Split('\n');

        for (int i = 1; i < rows.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(rows[i]))
                continue;

            string[] cols = rows[i].Split(',');

            if (cols.Length < 4)
                continue;

            string sequenceId = cols[0].Trim();
            string speakerName = cols[1].Trim();
            string text = cols[2].Trim();
            string emotion = cols[3].Trim();

            if (!_sequences.TryGetValue(sequenceId, out DialogSequence sequence))
            {
                sequence = new DialogSequence { sequenceId = sequenceId };
                _sequences.Add(sequenceId, sequence);
            }

            sequence.lines.Add(new DialogLine
            {
                speakerName = speakerName,
                text = text,
                emotion = emotion
            });
        }
    }

    public DialogSequence GetSequence(string sequenceId)
    {
        _sequences.TryGetValue(sequenceId, out var sequence);
        return sequence;
    }
}