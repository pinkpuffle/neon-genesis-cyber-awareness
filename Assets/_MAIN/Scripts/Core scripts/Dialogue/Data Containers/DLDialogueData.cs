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
        List<DialogueSegment> segments =  new List<DialogueSegment>();
        MatchCollection matches = Regex.Matches(rawDialogue, segmentIDPattern);

        int lastIndex = 0;
        //find first or only segment in file
        DialogueSegment segment = new DialogueSegment();
        segment.dialogue = (matches.Count == 0 ? rawDialogue : rawDialogue.Substring(0, matches[0].Index));
        segment.startSignal = DialogueSegment.StartSignal.NONE;
        segment.signalDelay = 0;
        segments.Add(segment);

        if (matches.Count == 0) //if no matches
            return segments;
        else
            lastIndex = matches[0].Index;

        for(int i = 0; i < matches.Count; i++)
        {
            Match match = matches[i];
            segment = new DialogueSegment();

            string signalMatch = match.Value; //grab identifier and container
            signalMatch = signalMatch.Substring(1, match.Length - 2); //just contents
            string[] signalSplit = signalMatch.Split(' '); //remove any space
        }
    }

    public struct DialogueSegment
    {
        public string dialogue;
        public StartSignal startSignal;
        public float signalDelay;

        public enum StartSignal { NONE, C, A, WA, WC } //none, clear, append, wait and append, wait and clear
    }
}
