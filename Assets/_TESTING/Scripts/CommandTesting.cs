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
        CommandManager.instance.Execute("lambda_p1", "Hello lambda!");
        CommandManager.instance.Execute("lambda_m1", "lambda1", "lambda2", "lambda3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
