using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFiles : MonoBehaviour
{
    private string fileName = "testFile.txt";


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        List<string> lines = FileManager.ReadTxtFile(fileName, true);

        foreach (string line in lines) //for each line log to console
            Debug.Log(line);

        yield return null;
    }

}
