using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    [CreateAssetMenu(fileName = "CharacterConfigurationAsset", menuName = "Dialogue System/Character Configuration Asset")]
    public class CharacterConfigSO : ScriptableObject //as own asset
    {
        public CharacterConfigData[] characters;

        public CharacterConfigData GetConfig(string characterName)
        {
            characterName = characterName.ToLower();

            for(int i = 0; i < characters.Length; i++)
            {
                CharacterConfigData data = characters[i];

                if (string.Equals(characterName, data.name.ToLower()) || string.Equals(characterName, data.alias.ToLower())) //match
                    return data.Copy();
            }
            return CharacterConfigData.Default; //default values
        }
    }
}