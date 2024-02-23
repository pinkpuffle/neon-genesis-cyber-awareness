using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CMDDatabaseExtension_Examples : CMDDatabaseExtension
{
    new public static void Extend(CommandDatabase database)
    {
        //add command with no parameters
        database.AddCommand("print", new Action(PrintDefaultMessage));
        database.AddCommand("print_1p", new Action<string>(printUserMessage)); //one param
        database.AddCommand("print_mp", new Action<string[]>(PrintLines)); //multi param
    }

    private static void PrintDefaultMessage()
    {
        Debug.Log("Printing a default message to console");
    }

    private static void printUserMessage(string message)
    {
        Debug.Log($"User message: '{message}");
    }

    private static void PrintLines(string[] lines)
    {
        int i = 1;
        foreach(string line in lines)
        {
            Debug.Log($"{i++}. '{line}'");
        }
    }
}
