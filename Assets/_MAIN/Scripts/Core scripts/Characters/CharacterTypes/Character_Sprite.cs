using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class Character_Sprite : Character
    {
        public Character_Sprite(string name) : base(name)
        {
            Debug.Log($"Created Sprite Character: '{name}'");
        }
    }
}