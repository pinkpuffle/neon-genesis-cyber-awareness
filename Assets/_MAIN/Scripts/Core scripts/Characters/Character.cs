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
        public Animator animator;
        public CharacterConfigData config;

        protected CharacterManager manager => CharacterManager.instance;
        public DialogueSys dialogueSys => DialogueSys.instance;

        protected Coroutine coRevealing, coHiding;
        public bool isRevealing => coRevealing != null;
        public bool isHiding => coHiding != null;
        public virtual bool isVisible => false;

        public Character(string name, GameObject prefab, CharacterConfigData config)
        {
            this.name = name;
            displayName = name;
            this.config = config;

            if(prefab != null)
            {
                GameObject ob = Object.Instantiate(prefab, manager.characterPanel);
                ob.SetActive(true);
                root = ob.GetComponent<RectTransform>();
                animator = root.GetComponentInChildren<Animator>();
            }
        }

        public Coroutine Say(string dialogue) => Say(new List<string> { dialogue });

        public Coroutine Say(List<string> dialogue)
        {
            dialogueSys.ShowSpeakerName(displayName);
            dialogueSys.ApplySpeakerDataToDialogueContainer(config);
            return dialogueSys.Say(dialogue);
        }

        public virtual Coroutine Show()
        {
            if (isRevealing)
                return coRevealing;

            if (isHiding)
                manager.StopCoroutine(coHiding);

            coRevealing = manager.StartCoroutine(ShowingOrHiding(true));

            return coRevealing;
        }

        public virtual Coroutine Hide()
        {
            if (isHiding)
                return coHiding;

            if (isRevealing)
                manager.StopCoroutine(coRevealing);

            coHiding = manager.StartCoroutine(ShowingOrHiding(false));

            return coHiding;
        }

        public virtual IEnumerator ShowingOrHiding(bool show)
        {
            Debug.Log("Show/Hide cannot be called from base character type");
            yield return null;
        }

        public virtual void SetPosition(Vector2 position)
        {
            (Vector2 minAnchorTarget, Vector2 maxAnrchorTarget) = ConvertUITargetPositionToRelativeCharacterAnchorTargets(position);

            root.anchorMin = minAnchorTarget;
            root.anchorMax = maxAnrchorTarget;
        }

        protected(Vector2, Vector2) ConvertUITargetPositionToRelativeCharacterAnchorTargets(Vector2 position)
        {
            Vector2 padding = root.anchorMax - root.anchorMin;

            float maxX = 1f - padding.x;
            float maxY = 1f - padding.y;

            Vector2 minAnchorTarget = new Vector2(maxX * position.x, maxY * position.y);
            Vector2 maxAnchorTarget = minAnchorTarget + padding;

            return (minAnchorTarget, maxAnchorTarget);
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