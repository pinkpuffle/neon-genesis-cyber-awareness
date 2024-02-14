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

        private TextArc arc = null;
        public ConversationManager(TextArc arc)
        {
            this.arc = arc;
        }

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
                if (string.IsNullOrWhiteSpace(conversation[i])) //account for empty and white spaces
                    continue;

                DialogueLine line = DialogueParser.Parse(conversation[i]); //get full line

                if (line.hasDialogue) //show dialogue
                {
                    yield return LineRunDialogue(line);
                }

                if (line.hasCommands) //run commands
                {
                    yield return LineRunCommands(line);
                }

                
            }
        }

        IEnumerator LineRunDialogue(DialogueLine line)
        {
            if (line.hasSpeaker) //show or hide speaker name if present
                dialogueSys.ShowSpeakerName(line.speaker);
            else
                dialogueSys.HideSpeakerName();

            yield return null;
        }

        IEnumerator LineRunCommands(DialogueLine line)
        {
            yield return null;
        }

    }
}
