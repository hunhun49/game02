using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private TextMeshProUGUI bodyText;

    private Queue<DialogLine> _lines = new();
    private bool _isPlaying;

    public bool IsPlaying => _isPlaying;

    public void Play(DialogSequence sequence)
    {
        if (sequence == null || sequence.lines.Count == 0)
        {
            Debug.LogWarning("Dialog sequence is null or empty.");
            return;
        }

        _lines.Clear();

        foreach (var line in sequence.lines)
            _lines.Enqueue(line);

        dialogPanel.SetActive(true);
        _isPlaying = true;

        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (!_isPlaying)
            return;

        if (_lines.Count == 0)
        {
            EndDialog();
            return;
        }

        DialogLine line = _lines.Dequeue();
        speakerText.text = line.speakerName;
        bodyText.text = line.text;
    }

    public void EndDialog()
    {
        _isPlaying = false;
        dialogPanel.SetActive(false);
    }
}
