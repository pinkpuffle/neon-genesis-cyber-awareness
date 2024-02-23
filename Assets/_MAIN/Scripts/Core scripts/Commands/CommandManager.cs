using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public class CommandManager : MonoBehaviour
{
    public static CommandManager instance { get; private set; } //singleton
    private static Coroutine process = null;
    public static bool isRunningProcess => process != null;
    private CommandDatabase database;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            database = new CommandDatabase();

            Assembly assembly = Assembly.GetExecutingAssembly(); //reference to where code executing
            Type[] extensionTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(CMDDatabaseExtension))).ToArray(); //every extension

            foreach(Type extension in extensionTypes)
            {
                MethodInfo extendMethod = extension.GetMethod("Extend"); //get Extend method
                extendMethod.Invoke(null, new object[] { database }); //null as object static, database passed in as object array
            }
        }
        else
            DestroyImmediate(gameObject);

    }

    public Coroutine Execute(string commandName, params string[] args) //independant strings compiled into array
    {
        Delegate command = database.GetCommand(commandName);

        if (command == null) //not proceed if null
            return null;

        return StartProcess(commandName, command, args);

        //if (command is Action) //if action, call it
            //command.DynamicInvoke();
        //else if (command is Action<string>) //if command expecting a string
            //command.DynamicInvoke(args[0]);
        //else if (command is Action<string[]>) //string with multiple arguments
            //command.DynamicInvoke((object)args);
    }

    private Coroutine StartProcess(string commandName, Delegate command, string[] args)
    {
        StopCurrentProcess();

        process = StartCoroutine(RunningProcess(command, args));

        return process;
    }

    private void StopCurrentProcess()
    {
        if (process != null)
            StopCoroutine(process);
        process = null;
    }

    private IEnumerator RunningProcess(Delegate process, string[] args)
    {

    }
}
