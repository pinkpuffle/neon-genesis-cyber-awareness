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
}
