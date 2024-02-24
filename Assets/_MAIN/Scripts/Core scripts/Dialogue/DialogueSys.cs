using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    public class DialogueSys : MonoBehaviour
    {
        [SerializeField] private DialogueSystemConfigurationSO _config;
        public DialogueSystemConfigurationSO config => _config;
        public DialogueCont dialogueCont = new DialogueCont();
        private ConversationManager conversationManager;
        private TextArc arc;

        public static DialogueSys instance { get; private set; } //singleton

        public delegate void DialogueSystemEvent();
        public event DialogueSystemEvent onUserPromptNext;

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

        public void OnUserPromptNext()
        {
            onUserPromptNext?.Invoke();
        }

        public void ShowSpeakerName(string speakerName = "")
        {
            if (speakerName.ToLower() != "narrator") //ensure narrator name not output
                dialogueCont.nameContainer.Show(speakerName);
            else
                HideSpeakerName();
        }
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
