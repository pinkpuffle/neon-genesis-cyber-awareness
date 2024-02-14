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

        DialogueSys.instance.Say(lines);
    }
}
}
