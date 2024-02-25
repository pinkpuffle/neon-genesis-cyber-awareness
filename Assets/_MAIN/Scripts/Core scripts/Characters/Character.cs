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

        protected CharacterManager manager => CharacterManager.instance;
        public DialogueSys dialogueSys => DialogueSys.instance;

        protected Coroutine coRevealing, coHiding;
        public bool isRevealing => coRevealing != null;
        public bool isHiding => coHiding != null;
        public virtual bool isVisible => false;

        public Character(string name, GameObject prefab)
        {
            this.name = name;
            displayName = name;
            this.config = config;

            if(prefab != null)
            {
                GameObject ob = Object.Instantiate(prefab, )
            }
        }

        public Coroutine Say(string dialogue) => Say(new List<string> { dialogue });

        public Coroutine Say(List<string> dialogue)
        {
            dialogueSys.ShowSpeakerName(displayName);
            return dialogueSys.Say(dialogue);
        }

        public virtual Coroutine Show()
        {
            if (isRevealing)
                return coRevealing;

            if (isHiding)
                manager.StopCoroutine(coHiding);

            coRevealing = manager.StartCoroutine(ShowingOrHiding(true));
#
            return coRevealing;
        }

        public virtual Coroutine Hide()
        {
            if (isHiding)
                return coHiding;

            if (isRevealing)
                manager.StopCoroutine(coRevealing);

            coHiding = manager.StartCoroutine(ShowingOrHiding(false));
#
            return coHiding;
        }

        public virtual IEnumerator ShowingOrHiding(bool show)
        {
            Debug.Log("Show/Hide cannot be called from base character type");
            yield return null;
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