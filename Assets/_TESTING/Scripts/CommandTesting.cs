using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CommandManager.instance.Execute("print");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
