using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class DLDialogueData
{

    public List<DialogueSegment> segments;
    private const string segmentIDPattern = @"\{[ca]\}|{w[ca]\s\d*\.?\d*\}"; //regex identifier
    public DLDialogueData(string rawDialogue)
    {
        segments = RipSegments(rawDialogue);
    }

    public List<DialogueSegment> RipSegments(string rawDialogue)
    {
        MatchCollection matches = Regex.Matches(rawDialogue, segmentIDPattern);
    }

    public struct DialogueSegment
    {
        public string dialogue;
        public StartSignal startSignal;
        public float signalDelay;

        public enum StartSignal { NONE, C, A, WA, WC } //none, clear, append, wait and append, wait and clear
    }
}
