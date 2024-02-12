using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{

    public class DialogueLine
    {
        public string speaker;
        public string dialogue;
        public string commands;

        public DialogueLine(string speaker, string dialogue, string commands)
        {
            this.speaker = speaker;
            this.dialogue = dialogue;
            this.commands = commands;
        }
    }
}
