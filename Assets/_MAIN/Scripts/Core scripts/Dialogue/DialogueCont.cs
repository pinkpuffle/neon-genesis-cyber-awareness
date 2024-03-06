using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    [System.Serializable]
    public class DialogueCont
    {
        public GameObject root;
        public NameContainer nameContainer;
        public TextMeshProUGUI dialogueTxt;

        public void SetDialogueColour(Color colour) => dialogueTxt.color = colour;
        public void SetDialogueFont(TMP_FontAsset font) => dialogueTxt.font = font;
    }
}
