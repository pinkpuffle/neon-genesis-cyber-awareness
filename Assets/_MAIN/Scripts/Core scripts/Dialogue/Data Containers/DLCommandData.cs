using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DLCommandData
{
    public List<Command> commands;
    private const char commandSplitterID = ',';
    private const char argumentsContainerID = '(';
    private const string waitCommandID = "[wait]";

    public struct Command
    {
        public string name;
        public string[] arguments;
        public bool waitForCompletion;
    }

    public DLCommandData(string rawCommands)
    {
        commands = RipCommands(rawCommands);
    }

    private List<Command> RipCommands(string rawCommands)
    {
        string[] data = rawCommands.Split(commandSplitterID, System.StringSplitOptions.RemoveEmptyEntries);
        List<Command> result = new List<Command>();

        foreach(string cmd in data)
        {
            Command command = new Command();
            int index = cmd.IndexOf(argumentsContainerID); //index of parenthesis
            command.name = cmd.Substring(0, index).Trim();

            if (command.name.StartsWith(waitCommandID))
            {
                command.name = command.name.ToLower().Substring(waitCommandID.Length);
                command.waitForCompletion = true;
            }
            else
                command.waitForCompletion = false;

            command.arguments = GetArgs(cmd.Substring(index + 1, cmd.Length - index - 2));
            result.Add(command);
        }
        return result;
    }

    private string[] GetArgs(string args)
    {
        List<string> argList = new List<string>();
        StringBuilder currentArg = new StringBuilder(); //build upon
        bool inQuotes = false;

        for(int i = 0; i < args.Length; i++)
        {
            if(args[i] == '"') //quotation mark
            {
                inQuotes = !inQuotes;
                continue;
            }

            if(!inQuotes && args[i] == ' ')
            {
                argList.Add(currentArg.ToString()); //save argument
                currentArg.Clear();
                continue;
            }

            currentArg.Append(args[i]);
        }

        if(currentArg.Length > 0)
            argList.Add(currentArg.ToString()); //add last argument

        return argList.ToArray();
    }
}
