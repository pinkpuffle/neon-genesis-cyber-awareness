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

        private const string characterNameID = "<charname>";
        private string characterRootPath => $"Characters/{characterNameID}";
        private string characterPrefabPath => $"{characterRootPath}/Character - [{characterNameID}]"; //to get prefab

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

            result.prefab = GetPrefabForCharacter(characterName);

            return result;
        }

        private GameObject GetPrefabForCharacter(string characterName)
        {
            string prefabPath = FormatCharacterPath(characterPrefabPath, characterName);
            return Resources.Load<GameObject>(prefabPath);
        }

        private string FormatCharacterPath(string path, string characterName) => path.Replace(characterNameID, characterName);

        private Character CreateCharacterFromInfo(CharacterInfo info)
        {
            CharacterConfigData config = info.config;

            switch (config.characterType)
            {
                case Character.CharacterType.Text:
                    return new Character_Text(info.name);

                case Character.CharacterType.Sprite:
                case Character.CharacterType.SpriteSheet:
                    return new Character_Sprite(info.name);

                //probably not gonna use these
                case Character.CharacterType.Live2D:
                    return new Character_Live2D(info.name);

                case Character.CharacterType.Model3D:
                    return new Character_Model3D(info.name);

                default:
                    return null;
            }
        }

        private class CharacterInfo
        {
            public string name = "";
            public CharacterConfigData config = null;

            public GameObject prefab = null;
        }
    }
}