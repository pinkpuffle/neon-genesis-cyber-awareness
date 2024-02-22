using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public static CommandManager instance { get; private set; } //singleton
    private CommandDatabase database;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
        else
            DestroyImmediate(gameObject);

    }
}
