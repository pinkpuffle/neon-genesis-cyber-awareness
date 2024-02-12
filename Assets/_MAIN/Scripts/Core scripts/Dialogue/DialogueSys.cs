using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    public class DialogueSys : MonoBehaviour
    {
        public DialogueCont dialogueCont = new DialogueCont();
        private ConversationManager conversationManager = new ConversationManager();

        public static DialogueSys instance; //singleton

        public bool isRunningConversation => conversationManager.isRunning;
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                DestroyImmediate(gameObject);
        }

        //list of strings to say
        public void Say(string speaker, string dialogue) 
        {
            List<string> conversation = new List<string>() { $"{speaker} \"{dialogue}\"" };
            Say(conversation);
        }

        public void Say(List<string> conversation) 
        {
            conversationManager.StartConversation(conversation); //conversation to start
        }
    }
}
