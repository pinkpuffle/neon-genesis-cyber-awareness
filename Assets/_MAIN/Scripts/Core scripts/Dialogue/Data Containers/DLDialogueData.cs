using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLDialogueData
{
    public DLDialogueData(string rawDialogue)
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
