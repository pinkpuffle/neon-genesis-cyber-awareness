using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    public class DialogueSys : MonoBehaviour
    {
        public DialogueCont dialogueCont = new DialogueCont();
        private ConversationManager conversationManager = new ConversationManager();

        public static DialogueSys instance; //singleton

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                DestroyImmediate(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
