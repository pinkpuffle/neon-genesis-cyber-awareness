using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestFiles : MonoBehaviour
    {
        [SerializeField] private TextAsset fileName;


        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Run());
        }

        IEnumerator Run()
        {
            List<string> lines = FileManager.ReadTxtAsset(fileName, false);

            foreach (string line in lines) //for each line log to console
                Debug.Log(line);

            yield return null;
        }

    }
}