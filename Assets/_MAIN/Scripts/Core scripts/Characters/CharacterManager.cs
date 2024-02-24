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

        public Character CreateCharacter(string characterName)
        {
            if (characters.ContainsKey(characterName.ToLower())) //for dupe
            {
                Debug.LogWarning($"A character called '{characterName}' already exists. Did not create.");
                return null;
            }


            CharacterInfo info = GetCharacterInfo


            return null;
        }

        private CharacterInfo GetCharacterInfo(string characterName)
        {
            CharacterInfo result = new CharacterInfo();
            result.name = characterName;

            return result;
        }

        private class CharacterInfo
        {
            public string name = "";
            public CharacterConfigData config = null;
        }
    }
}