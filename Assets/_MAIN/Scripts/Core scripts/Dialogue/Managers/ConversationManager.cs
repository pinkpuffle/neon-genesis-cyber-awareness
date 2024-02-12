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

            
        }

        public void StopConversation()
        {
            if (!isRunning)
                return;

            dialogueSys.StopCoroutine(process);
            process = null;

        }

        IEnumerator RunningConversation()
        {

        }

    }
}
