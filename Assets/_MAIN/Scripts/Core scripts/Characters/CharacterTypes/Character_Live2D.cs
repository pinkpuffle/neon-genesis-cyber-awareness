using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class Character_Live2D : Character
    {
        public Character_Live2D(string name) : base(name)
        {
            Debug.Log($"Created Live2D Character: '{name}'");
        }
    }
}