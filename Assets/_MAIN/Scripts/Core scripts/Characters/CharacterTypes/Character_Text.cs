using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class Character_Text : Character
    {
        public Character_Text(string name) : base(name, prefab : null)
        {
            Debug.Log($"Created Text Character: '{name}'");
        }
    }
}