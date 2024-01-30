using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestArc : MonoBehaviour
    {
        DialogueSys ds;
        TextArc arc;

        string[] lines = new string[6]
        {
            "Some dialogue.",
            "Like fr dialogue fr.",
            "Why are you reading this.",
            "Life is kinda scary sometimes but that's ok.",
            "Lmao.",
            "Trans rights."
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSys.instance;
            arc = new TextArc(ds.dialogueCont.dialogueTxt);
            arc.buildMethod = TextArc.BuildMethod.instant;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                arc.Build(lines[Random.Range(0, lines.Length)]);
        }
    }
}