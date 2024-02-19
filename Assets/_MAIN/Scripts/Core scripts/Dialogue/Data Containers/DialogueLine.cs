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

        public bool hasSpeaker => false; // speaker != string.Empty;
        public bool hasDialogue => dialogue.hasDialogue;
        public bool hasCommands => commands != string.Empty;

        public DialogueLine(string speaker, string dialogue, string commands)
        {
            this.speaker = new DLSpeakerData(speaker);
            this.dialogue = new DLDialogueData(dialogue);
            this.commands = commands;
        }
    }
}
