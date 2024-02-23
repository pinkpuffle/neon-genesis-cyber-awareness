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
        private const string commandRegexPattern = @"[\w\[\]]*[^\s]\("; //word or bracket of any length as long as not proceeded by white space

        public static DialogueLine Parse(string rawLine)
        {
            Debug.Log($"Parsing line: '{rawLine}'");

            (string speaker, string dialogue, string commands) = RipContent(rawLine);

            Debug.Log($"Speaker = '{speaker}'\nDialogue = '{dialogue}'\nCommands = '{commands}'");

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
            MatchCollection matches = commandRegex.Matches(rawLine);
            int commandStart = -1;
            foreach(Match match in matches)
            {
                if (match.Index < dialogueStart || match.Index > dialogueEnd) //not contained within dialogue (valid)
                {
                    commandStart = match.Index;
                    break;
                }
            }

            if (commandStart != -1 && (dialogueStart == -1 && dialogueEnd == -1))
                return ("", "", rawLine.Trim()); //just command

            //if here, have dialogue or multi word argument in command. FIgure out if dialogue
            if (dialogueStart != -1 && dialogueEnd != -1 && (commandStart == -1 || commandStart > dialogueEnd)) //if found dialogue AND no command or the start of command is greater than end = dialogue
            {
                //valid dialogue
                speaker = rawLine.Substring(0, dialogueStart).Trim();
                dialogue = rawLine.Substring(dialogueStart + 1, dialogueEnd - dialogueStart - 1).Replace("\\\"","\""); //bypass quotation mark, replace \ with "
                if (commandStart != -1) //commands
                    commands = rawLine.Substring(commandStart).Trim();
            }
            else if (commandStart != -1 && dialogueStart > commandStart) //command line
                commands = rawLine;
            else //just unformatted dialogue
                dialogue = rawLine;



            return (speaker, dialogue, commands);
        }
    }
}