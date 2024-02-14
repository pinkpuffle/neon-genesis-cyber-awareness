using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
///  box that holds name text on screen
/// </summary>

public class NameContainer : MonoBehaviour
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
}
