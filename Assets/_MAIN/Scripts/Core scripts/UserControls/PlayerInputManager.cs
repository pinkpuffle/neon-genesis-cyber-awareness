using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class PlayerInputManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) //on space and enter
                PromptAdvance();
        }

        public void PromptAdvance()
        {
            DialogueSys.instance.OnUserPromptNext();
        }
    }
}
