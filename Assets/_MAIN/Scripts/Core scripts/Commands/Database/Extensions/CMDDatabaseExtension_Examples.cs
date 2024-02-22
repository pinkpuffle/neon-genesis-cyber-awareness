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
    }

    private static void PrintDefaultMessage()
    {
        Debug.Log("Printing a default message to console");
    }
}
