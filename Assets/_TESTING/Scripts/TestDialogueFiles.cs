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

            foreach(string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                Debug.Log($"Segmenting line '{line}'");
                DialogueLine dlLine = DialogueParser.Parse(line);

                int i = 0;
                foreach(DLDialogueData.DialogueSegment segment in dlLine.dialogue.segments)
                {
                    //print segment number, show what dialogue assigned, what signal assigned, if has delay show
                    Debug.Log($"Segment [{i++}] = '{segment.dialogue}' [signal={segment.startSignal.ToString()}{(segment.signalDelay > 0 ? $" {segment.signalDelay}" : $"")}]");
                }
            }

            DialogueSys.instance.Say(lines);
        }
    }
}
