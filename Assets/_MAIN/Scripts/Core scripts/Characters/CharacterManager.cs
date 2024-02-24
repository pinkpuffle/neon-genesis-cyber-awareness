using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance { get; private set; } //singleton
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();

        private void Awake()
        {
            instance = this;
        }
    }
}