using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDatabase : MonoBehaviour
{
    private Dictionary<string, Delegate> database = new Dictionary<string, Delegate>();

    public bool HasCommand(string commandName) => database.ContainsKey(commandName);

    public void AddCommand(string commandName, Delegate command)
    {
        if (!database.ContainsKey(commandName)) //if not already in
        {
            database.Add(commandName, command);
        }
        else
        {
            Debug.LogError($"Command already exists in database '{commandName}'");
        }
    }
}
