using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    [System.Serializable]

    /// <summary>
    ///  box that holds name text on screen
    /// </summary>

    public class NameContainer
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI nameTxt;
        public void Show(string nameToShow = "")
        {
            root.SetActive(true);

            if (nameToShow != string.Empty)
                nameTxt.text = nameToShow;
        }

        public void Hide()
        {
            root.SetActive(false);
        }

        public void SetNameColour(Color colour) => nameTxt.color = colour;
        public void SetNameFont(TMP_FontAsset font) => nameTxt.font = font;
    }
}
