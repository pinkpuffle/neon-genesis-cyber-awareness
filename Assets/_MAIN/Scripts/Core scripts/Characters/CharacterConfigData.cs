using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CHARACTERS
{
    [System.Serializable]
    public class CharacterConfigData
    {
        public string name;
        public string alias;
        public Character.CharacterType characterType;

        public Color nameColour;
        public Color dialogueColour;

        public TMP_FontAsset nameFont;
        public TMP_FontAsset dialogueFont;

        public CharacterConfigData Copy()
        {
            CharacterConfigData result = new CharacterConfigData();

            result.name = name;
            result.alias = alias;
            result.characterType = characterType;
            result.nameFont = nameFont;
            result.dialogueFont = dialogueFont;
            result.nameColour = new Color(nameColour.r, nameColour.g, nameColour.b, nameColour.a);
            result.dialogueColour = new Color(dialogueColour.r, dialogueColour.g, dialogueColour.b, dialogueColour.a);

            return result;
        }

         public static CharacterConfigData Default
        {
            get
            {
                CharacterConfigData result = new CharacterConfigData();

                result.name = "";
                result.alias = "";
                result.characterType = Character.CharacterType.Text;
                result.nameFont = ;
                result.dialogueFont = dialogueFont;
                result.nameColour = new Color(nameColour.r, nameColour.g, nameColour.b, nameColour.a);
                result.dialogueColour = new Color(dialogueColour.r, dialogueColour.g, dialogueColour.b, dialogueColour.a);
            }
        }
    }
}