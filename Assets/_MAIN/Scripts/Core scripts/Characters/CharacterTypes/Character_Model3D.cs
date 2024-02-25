using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class Character_Model3D : Character
    {
        public Character_Model3D(string name, GameObject prefab) : base(name, prefab)
        {
            Debug.Log($"Created Model3D Character: '{name}'");
        }
    }
}