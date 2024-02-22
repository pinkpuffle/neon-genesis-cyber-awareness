using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public class CommandManager : MonoBehaviour
{
    public static CommandManager instance { get; private set; } //singleton
    private CommandDatabase database;

    private void Awake()
    {
        if (instance != null)
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
}
