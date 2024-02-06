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
            string line = "Speaker \"Dialogue \\\"goes in\\\" here\" Command(arguments here)";

            DialogueParser.Prase(line);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
