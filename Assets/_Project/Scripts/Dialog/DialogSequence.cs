using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogSequence
{
    public string sequenceId;
    public List<DialogLine> lines = new();
}