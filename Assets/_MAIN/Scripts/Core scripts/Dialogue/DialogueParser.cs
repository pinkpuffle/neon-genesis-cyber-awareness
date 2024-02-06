using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace DIALOGUE
{
    public class DialogueParser
    {

        //dialogue line format
        //{n{as cn}{ at x{:y}}{ [l:e{ + l:e}]} "d"} {c(a){, c(a)}}

        //command pattern
        private const string commandRegexPattern = "\\w*[^\\s]\\("; //word of any length as long as not proceeded by white space

        public static DialogueLine Prase(string rawLine)
        {
            Debug.Log($"Parsing line: '{rawLine}'");

            (string speaker, string dialogue, string commands) = RipContent(rawLine);

            return new DialogueLine(speaker, dialogue, commands);
        }

        private static (string, string, string) RipContent(string rawLine) //parses
        {
            string speaker = "", dialogue = "", commands = "";

            int dialogueStart = -1;
            int dialogueEnd = -1;
            bool isEscaped = false;

            for(int i = 0; i< rawLine.Length; i++ ) //find where dialogue
            {
                char current = rawLine[i]; //current char working on
                if (current == '\\') //if \
                    isEscaped = !isEscaped;
                else if (current == '"' && !isEscaped) //start or end
                {
                    if (dialogueStart == -1)
                        dialogueStart = i;
                    else if (dialogueEnd == -1)
                        dialogueEnd = i;
                }
                else
                    isEscaped = false;
            }

            //Debug.Log(rawLine.Substring(dialogueStart + 1, (dialogueEnd - dialogueStart) - 1));

            //identify command
            Regex commandRegex = new Regex(commandRegexPattern);
            Match match = commandRegex.Match(rawLine);
            int commandStart = -1;
            if (match.Success)
            {
                commandStart = match.Index;
                return ("", "", rawLine.Trim()); //return empty speaker + dialogue, just command
            }

            //if here, have dialogue or multi word argument in command. FIgure out if dialogue
            if (dialogueStart != -1 && dialogueEnd != -1 && (commandStart == -1 || commandStart > dialogueEnd)) //if found dialogue AND no command or the start of command is greater than end = dialogue
            {
                //valid dialogue

            }
            else if (commandStart != -1 && dialogueStart > commandStart) //command line
                commands = rawLine;
            else //just a speaker
                speaker = rawLine;



            return (speaker, dialogue, commands);
        }
    }
}