using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{

    public class DialogueLine
    {
        public DLSpeakerData speaker;
        public DLDialogueData dialogue;
        public string commands;

        public bool hasSpeaker => speaker != null;
        public bool hasDialogue => dialogue.hasDialogue;
        public bool hasCommands => commands != string.Empty;

        public DialogueLine(string speaker, string dialogue, string commands)
        {
            this.speaker = (string.IsNullOrWhiteSpace(speaker) ? null : new DLSpeakerData(speaker));
            this.dialogue = new DLDialogueData(dialogue);
            this.commands = commands;
        }
    }
}
