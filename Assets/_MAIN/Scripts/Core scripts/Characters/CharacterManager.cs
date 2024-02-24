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

            Character character = CreateCharacterFromInfo(info);

            characters.Add(characterName.ToLower(), character);
            return character;
        }

        private CharacterInfo GetCharacterInfo(string characterName)
        {
            CharacterInfo result = new CharacterInfo();
            result.name = characterName;

            result.config = config.GetConfig(characterName);

            return result;
        }

        private Character CreateCharacterFromInfo(CharacterInfo info)
        {
            CharacterConfigData config = info.config;
            if (config.characterType == Character.CharacterType.Text)
                return new Character_Text(info.name);

            if (config.characterType == Character.CharacterType.Sprite || config.characterType == Character.CharacterType.SpriteSheet)
                return new Character_Sprite(info.name);

            if (config.characterType == Character.CharacterType.Live2D)
                return new Character_Live2D(info.name);

            if (config.characterType == Character.CharacterType.Model3D)
                return new Character_Model3D(info.name);

            return null; 
        }

        private class CharacterInfo
        {
            public string name = "";
            public CharacterConfigData config = null;
        }
    }
}