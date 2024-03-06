using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class Character_Sprite : Character
    {
        public Character_Sprite(string name, GameObject prefab, CharacterConfigData config) : base(name, prefab, config)
        {
            Debug.Log($"Created Sprite Character: '{name}'");
        }
    }
}