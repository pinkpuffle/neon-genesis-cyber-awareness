using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public abstract class Character
    {
        public string name = "";
        public RectTransform root = null;

        public Character(string name)
        {
            this.name = name;
        }

        public void Say(string dialogue) => Say(new List<string> { dialogue });

        public void Say(List<string> dialogue)
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