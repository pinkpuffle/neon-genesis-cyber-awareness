using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CommandManager.instance.Execute("print");
        CommandManager.instance.Execute("print_1p", "Hello world!");
        CommandManager.instance.Execute("print_mp", "Line1", "Line2", "Line3");

        CommandManager.instance.Execute("lambda");
        CommandManager.instance.Execute("lambda_1p", "Hello lambda!");
        CommandManager.instance.Execute("lambda_mp", "lambda1", "lambda2", "lambda3");

        CommandManager.instance.Execute("process");
        CommandManager.instance.Execute("process_1p", "3");
        CommandManager.instance.Execute("process_mp", "Process line 1", "Process line 2", "Process line 3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
