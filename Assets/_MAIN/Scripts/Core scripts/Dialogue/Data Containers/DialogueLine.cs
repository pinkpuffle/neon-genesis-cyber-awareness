using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{

    public class DialogueLine
    {
        public DLSpeakerData speakerData;
        public DLDialogueData dialogueData;
        public DLCommandData commandData;

        public bool hasSpeaker => speakerData != null;
        public bool hasDialogue => dialogueData != null;
        public bool hasCommands => commandData != null;

        public DialogueLine(string speaker, string dialogue, string commands)
        {
            this.speakerData = (string.IsNullOrWhiteSpace(speaker) ? null : new DLSpeakerData(speaker));
            this.dialogueData = (string.IsNullOrWhiteSpace(commands) ? null : new DLDialogueData(dialogue));
            this.commandData = (string.IsNullOrWhiteSpace(commands) ? null : new DLCommandData(commands));
        }
    }
}
