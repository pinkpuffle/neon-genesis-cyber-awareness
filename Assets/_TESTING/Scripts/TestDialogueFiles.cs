using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

public class TestConversation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartConversation();
    }

    void StartConversation()
    {
        List<string> lines = FileManager.ReadTxtAsset("testFile");

        foreach (string line in lines)
        {
            if (line == string.Empty) //skip blank lines
                continue;
            DialogueLine dl = DialogueParser.Parse(line); //parse each line, send to console
        }
    }
}
}
