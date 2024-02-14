using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    public class DialogueSys : MonoBehaviour
    {
        public DialogueCont dialogueCont = new DialogueCont();
        private ConversationManager conversationManager;
        private TextArc arc;

        public static DialogueSys instance; //singleton

        public bool isRunningConversation => conversationManager.isRunning;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Initialise();
            }
            else
                DestroyImmediate(gameObject);
        }

        bool initialised = false;
        private void Initialise()
        {
            if (initialised)
                return;

            arc = new TextArc(dialogueCont.dialogueTxt);
            conversationManager = new ConversationManager(arc);
        }

        public void ShowSpeakerName(string speakerName = "") => dialogueCont.nameContainer.Show(speakerName);
        public void HideSpeakerName() => dialogueCont.nameContainer.Hide();

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
