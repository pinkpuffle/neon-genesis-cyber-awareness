using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace testing {

    public class TestConversation : MonoBehaviour
    {
        [SerializeField] private TextAsset fileToRead = null;
        // Start is called before the first frame update
        void Start()
        {
            StartConversation();
        }

        void StartConversation()
        {
            List<string> lines = FileManager.ReadTxtAsset(fileToRead);

            for(int i = 0; i < lines.Count; i++) //print out everything
            {
                string line = lines[0];
                DialogueLine dl = DialogueParser.Parse(line);

                Debug.Log($"{dl.speaker.name} as [{(dl.speaker.castName != string.Empty ? dl.speaker.castName : dl.speaker.name)}]at {dl.speaker.castPosition}");

                List<(int l, string ex)> expr = dl.speaker.CastExpressions;
                for(int c = 0; c < expr.Count; c++)
                {
                    Debug.Log($"[Layer[{expr[c].l}] = '{expr[c].ex}']");
                }
            }











            //DialogueSys.instance.Say(lines);
            
            

            
            //foreach(string line in lines)
            //{
                //if (string.IsNullOrEmpty(line))
                    //continue;

                //Debug.Log($"Segmenting line '{line}'");
                //DialogueLine dlLine = DialogueParser.Parse(line);

                //int i = 0;
                //foreach(DLDialogueData.DialogueSegment segment in dlLine.dialogue.segments)
                //{
                    //print segment number, show what dialogue assigned, what signal assigned, if has delay show
                    //Debug.Log($"Segment [{i++}] = '{segment.dialogue}' [signal={segment.startSignal.ToString()}{(segment.signalDelay > 0 ? $" {segment.signalDelay}" : $"")}]");
                //}
            //}

            
        }
    }
}
