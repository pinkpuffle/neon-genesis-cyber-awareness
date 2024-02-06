using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace testing {
    public class TestParsing : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //string line = "Speaker \"Dialogue \\\"goes in\\\" here\" Command(arguments here)";
            //DialogueParser.Parse(line);

            SendFileToParse();

        }

        void SendFileToParse()
        {
            List<string> lines = FileManager.ReadTxtAsset("testFile");

            foreach(string line in lines)
            {
                if (line == string.Empty) //skip blank lines
                    continue;
                DialogueLine dl = DialogueParser.Parse(line); //parse each line, send to console
            }
        }
    }
}
