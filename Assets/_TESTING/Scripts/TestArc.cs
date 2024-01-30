using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestArc : MonoBehaviour
    {
        DialogueSys ds;
        TextArc arc;

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSys.instance;
            arc = new TextArc(ds.dialogueCont.dialogueTxt);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}