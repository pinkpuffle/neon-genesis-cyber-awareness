using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CHARACTERS;

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

        public void ApplySpeakerDataToDialogueContainer(string speakerName)
        {
            Character character = CharacterManager.instance.GetCharacter(speakerName); //retrieve char
            CharacterConfigData config = character != null ? character.config : CharacterManager.instance.GetCharacterConfig(speakerName); //get config

            dialogueCont.SetDialogueColour(config.dialogueColour);
            dialogueCont.SetDialogueFont(config.dialogueFont);
            dialogueCont.nameContainer.SetNameColour(config.nameColour);
            dialogueCont.nameContainer.SetNameFont(config.nameFont);
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
        public Coroutine Say(string speaker, string dialogue) 
        {
            List<string> conversation = new List<string>() { $"{speaker} \"{dialogue}\"" };
            return Say(conversation);
        }

        public Coroutine Say(List<string> conversation) 
        {
            return conversationManager.StartConversation(conversation); //conversation to start
        }
    }
}
