using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace CHARACTERS
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance { get; private set; } //singleton
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();

        private CharacterConfigSO config => DialogueSys.instance.config.characterConfigurationAsset;

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


            CharacterInfo info = GetCharacterInfo(characterName);


            return null;
        }

        private CharacterInfo GetCharacterInfo(string characterName)
        {
            CharacterInfo result = new CharacterInfo();
            result.name = characterName;

            result.config = config.GetConfig(characterName);

            return result;
        }

        private class CharacterInfo
        {
            public string name = "";
            public CharacterConfigData config = null;
        }
    }
}