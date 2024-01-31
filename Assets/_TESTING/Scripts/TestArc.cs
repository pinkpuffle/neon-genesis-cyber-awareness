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
            arc.buildMethod = TextArc.BuildMethod.typewriter;
            arc.speed = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            string longLine = "This is a very long line to test the speed of the VN. What a fun time for be alive like frfr. So how was your day? Mine wasn't too bad. Thanks for asking. Ok that will do methinks.";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (arc.isBuilding)
                {
                    if (!arc.speedUp)
                        arc.speedUp = true;
                    else
                        arc.ForceComplete();
                }
                arc.Build(longLine);
                //arc.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                arc.Append(longLine);
                //arc.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}