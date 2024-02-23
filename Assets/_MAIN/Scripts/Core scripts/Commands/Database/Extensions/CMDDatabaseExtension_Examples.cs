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

        //add lambda with no parameters
        database.AddCommand("lambda", new Action(() => { Debug.Log("Printing a default message to console from lambda command"); }));
        database.AddCommand("lambda_1p", new Action<string>((arg) => { Debug.Log($"Log user lambra message: '{arg}'"); }));
        database.AddCommand("lambda_mp", new Action<string[]>((args) => { Debug.Log(string.Join(", ", args)); }));

        //add coroutine with no parameters
        database.AddCommand("process", new Func<IEnumerator>(SimpleProcess)); //adds coroutine to database
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

    private static IEnumerator SimpleProcess()
    {
        for(int i = 1; i <= 5; i++)
        {
            Debug.Log($"Process running... [{i}]");
            yield return new WaitForSeconds(1);
        }
    }
}
