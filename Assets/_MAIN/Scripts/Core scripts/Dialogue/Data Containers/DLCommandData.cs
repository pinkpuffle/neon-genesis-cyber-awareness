using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCommandData
{
    public List<Command> commands;
    private const char commandSplitterID = ',';
    private const char argumentsContainerID = '(';

    public struct Command
    {
        public string name;
        public string[] arguments;
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
            
        }
    }
}
