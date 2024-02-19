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
        private bool userPrompt = false;
        public ConversationManager(TextArc arc)
        {
            this.arc = arc;
            dialogueSys.onUserPromptNext += OnUserPromptNext;
        }

        private void OnUserPromptNext()
        {
            userPrompt = true;
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
            for (int i = 0; i < conversation.Count; i++) //don't show or run blank lines
            {
                if (string.IsNullOrWhiteSpace(conversation[i])) //account for empty and white spaces
                    continue;

                DialogueLine line = DialogueParser.Parse(conversation[i]); //get full line

                if (line.hasDialogue) //show dialogue
                    yield return LineRunDialogue(line);

                if (line.hasCommands) //run commands
                    yield return LineRunCommands(line);
            }
        }

        IEnumerator LineRunDialogue(DialogueLine line)
        {
            if (line.hasSpeaker) //show or hide speaker name if present
                dialogueSys.ShowSpeakerName(line.speaker.displayName);

            //build dialogue
            yield return BuildLineSegments(line.dialogue);

            //wait for user input
            yield return WaitForUserInput();
        }

        IEnumerator LineRunCommands(DialogueLine line)
        {
            Debug.Log(line.commands); //to see if working
            yield return null;
        }

        IEnumerator BuildLineSegments(DLDialogueData line)
        {
            for(int i = 0; i < line.segments.Count; i++)
            {
                DLDialogueData.DialogueSegment segment = line.segments[i];

                yield return WaitForDialogueSegmentSignalToBeTriggered(segment);

                yield return BuildDialogue(segment.dialogue, segment.appendText);
            }
        }

        IEnumerator WaitForDialogueSegmentSignalToBeTriggered(DLDialogueData.DialogueSegment segment)
        {
            switch (segment.startSignal)
            {
                case DLDialogueData.DialogueSegment.StartSignal.C:
                case DLDialogueData.DialogueSegment.StartSignal.A:
                    yield return WaitForUserInput();
                    break;
                case DLDialogueData.DialogueSegment.StartSignal.WC:
                case DLDialogueData.DialogueSegment.StartSignal.WA:
                    yield return new WaitForSeconds(segment.signalDelay);
                    break;
                default:
                    break;

            }
        }

        IEnumerator BuildDialogue(string dialogue, bool append = false)
        {
            //build dialogue
            if (!append)
                arc.Build(dialogue);
            else
                arc.Append(dialogue);

            //wait for dialogue to complete
            while (arc.isBuilding)
            {
                if (userPrompt)
                {
                    if (!arc.speedUp)
                        arc.speedUp = true;
                    else
                        arc.ForceComplete();

                    userPrompt = false;
                }
                yield return null;

            }
        }

        IEnumerator WaitForUserInput()
        {
            while (!userPrompt)
                yield return null;

            userPrompt = false;
        }

    }
}
