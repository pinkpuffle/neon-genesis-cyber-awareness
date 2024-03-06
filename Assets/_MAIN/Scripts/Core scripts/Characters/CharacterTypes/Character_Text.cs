using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class Character_Text : Character
    {
        public Character_Text(string name, CharacterConfigData config) : base(name, prefab : null, config)
        {
            Debug.Log($"Created Text Character: '{name}'");
        }
    }
}