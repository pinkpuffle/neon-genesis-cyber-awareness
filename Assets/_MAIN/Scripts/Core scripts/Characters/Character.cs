using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace CHARACTERS
{
    public abstract class Character
    {
        public string name = "";
        public string displayName = "";
        public RectTransform root = null;

        public DialogueSys dialogueSys => DialogueSys.instance;

        protected Coroutine coRevealing, coHiding;
        public bool isRevealing => coRevealing != null;

        public Character(string name)
        {
            this.name = name;
            displayName = name;
        }

        public Coroutine Say(string dialogue) => Say(new List<string> { dialogue });

        public Coroutine Say(List<string> dialogue)
        {
            dialogueSys.ShowSpeakerName(displayName);
            return dialogueSys.Say(dialogue);
        }

        public virtual Coroutine Show()
        {

        }

        public virtual Coroutine Hide()
        {

        }

        public virtual IEnumerator ShowingOrHiding()
        {

        }

        public enum CharacterType //most of these are optional
        {
            Text,
            Sprite,
            SpriteSheet,
            Live2D,
            Model3D
        }
    }
}