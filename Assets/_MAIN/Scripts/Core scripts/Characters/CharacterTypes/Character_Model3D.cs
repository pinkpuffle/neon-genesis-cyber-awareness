using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class Character_Model3D : Character
    {
        public Character_Model3D(string name, GameObject prefab, CharacterConfigData config) : base(name, prefab, config)
        {
            Debug.Log($"Created Model3D Character: '{name}'");
        }
    }
}