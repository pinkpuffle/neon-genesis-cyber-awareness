using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDatabase : MonoBehaviour
{
    private Dictionary<string, Delegate> database = new Dictionary<string, Delegate>();

    public bool HasCommand(string commandName) => database.ContainsKey(commandName);
}
