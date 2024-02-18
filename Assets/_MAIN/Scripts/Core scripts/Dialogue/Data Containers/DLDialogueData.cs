using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLDialogueData
{

    public List<DialogueSegment> segments;
    public DLDialogueData(string rawDialogue)
    {
        segments = RipSegments(rawDialogue);
    }

    public List<DialogueSegment> RipSegments(string rawDialogue)
    {

    }

    public struct DialogueSegment
    {
        public string dialogue;
        public StartSignal startSignal;
        public float signalDelay;

        public enum StartSignal { NONE, C, A, WA, WC } //none, clear, append, wait and append, wait and clear
    }
}
