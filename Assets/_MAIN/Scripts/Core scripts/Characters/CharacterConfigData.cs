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
    }
}