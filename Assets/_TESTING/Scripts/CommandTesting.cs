using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CommandManager.instance.Execute("print");
        CommandManager.instance.Execute("print_1p");
        CommandManager.instance.Execute("print_mp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
