using System.Collections;
using UnityEngine;
using TMPro;

public class TextArc
{
    private TextMeshProUGUI tMProUI;
    private TextMeshPro tMProWorld;
    public TMP_Text tMPro => tMProUI != null ? tMProUI : tMProWorld;
}
