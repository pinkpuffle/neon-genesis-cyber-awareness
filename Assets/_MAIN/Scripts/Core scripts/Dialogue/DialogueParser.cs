using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class DialogueParser
    {
        public static DialogueLine Prase(string rawLine)
        {
            Debug.Log($"Parsing line: '{rawLine}'");

            (string speaker, string dialogue, string commands) = RipContent(rawLine);

            return new DialogueLine(speaker, dialogue, commands);
        }

        private static (string, string, string) RipContent(string rawLine)
        {
            string speaker = "", dialogue = "", commands = "";

            return (speaker, dialogue, commands);
        }
    }
}