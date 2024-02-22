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

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                DialogueLine dl = DialogueParser.Parse(line);

                for(int i = 0; i < dl.commandData.commands.Count; i++)
                {
                    DLCommandData.Command command dl.commandData.commands[i];
                    Debug.Log($"Command [{i}] '{command.name}' has arguments [{string.Join(", ", command.arguments)}]");
                }
            }


            //DialogueSys.instance.Say(lines);


            
        }
    }
}
