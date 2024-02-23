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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
