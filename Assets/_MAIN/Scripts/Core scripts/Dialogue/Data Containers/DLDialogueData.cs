using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace DIALOGUE
{
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
            List<DialogueSegment> segments = new List<DialogueSegment>();
            MatchCollection matches = Regex.Matches(rawDialogue, segmentIDPattern);

            int lastIndex = 0;
            //find first or only segment in file
            DialogueSegment segment = new DialogueSegment();
            segment.dialogue = matches.Count == 0 ? rawDialogue : rawDialogue.Substring(0, matches[0].Index);
            segment.startSignal = DialogueSegment.StartSignal.NONE;
            segment.signalDelay = 0;
            segments.Add(segment);

            if (matches.Count == 0) //if no matches
                return segments;
            else
                lastIndex = matches[0].Index;

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                segment = new DialogueSegment();

                //get start signal for segment
                string signalMatch = match.Value; //grab identifier and container
                signalMatch = signalMatch.Substring(1, match.Length - 2); //just contents
                string[] signalSplit = signalMatch.Split(' '); //remove any space

                segment.startSignal = (DialogueSegment.StartSignal)Enum.Parse(typeof(DialogueSegment.StartSignal), signalSplit[0].ToUpper());

                //get signal delay
                if (signalSplit.Length > 1)
                    float.TryParse(signalSplit[1], out segment.signalDelay);

                //get dialogue for segment
                int nextIndex = i + 1 < matches.Count ? matches[i + 1].Index : rawDialogue.Length; //if at end of matches
                segment.dialogue = rawDialogue.Substring(lastIndex + match.Length, nextIndex - (lastIndex + match.Length));
                lastIndex = nextIndex;

                segments.Add(segment);
            }
            return segments;
        }

        public struct DialogueSegment
        {
            public string dialogue;
            public StartSignal startSignal;
            public float signalDelay;

            public enum StartSignal { NONE, C, A, WA, WC } //none, clear, append, wait and append, wait and clear

            public bool appendText => startSignal == StartSignal.A || startSignal == StartSignal.WA;
        }
    }
}