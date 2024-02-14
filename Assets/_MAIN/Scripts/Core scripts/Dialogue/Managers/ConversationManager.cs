using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class ConversationManager
    {
        private DialogueSys dialogueSys => DialogueSys.instance;
        private Coroutine process = null;
        public bool isRunning => process != null;

        public void StartConversation(List<string> conversation)
        {
            StopConversation();

            process = dialogueSys.StartCoroutine(RunningConversation(conversation));
        }

        public void StopConversation()
        {
            if (!isRunning)
                return;

            dialogueSys.StopCoroutine(process);
            process = null;

        }

        IEnumerator RunningConversation(List<string> conversation)
        {
            for(int i = -0; i < conversation.Count; i++) //don't show or run blank lines
            {
                if (conversation[i] == string.Empty)
                    continue;
                DialogueLine line = DialogueParser.Parse(conversation[i]); //get full line

                if (line.hasDialogue) //show dialogue
                {

                }

                if (line.hasCommands) //run commands
                {

                }

                
            }
        }

    }
}
