using System.Collections;
using UnityEngine;
using TMPro;

public class TextArc
{
    private TextMeshProUGUI tMProUI;
    private TextMeshPro tMProWorld;
    public TMP_Text tMPro => tMProUI != null ? tMProUI : tMProWorld;

    public string currentTxt => tMPro.text;
    public string targetTxt { get; private set; } = "";
    public string preTxt { get; private set; } = "";
    private int preTxtLength = 0;

    public string fullTargetTxt => preTxt + targetTxt;

    public enum BuildMethod { instant, typewriter, fade}
    public BuildMethod buildMethod = BuildMethod.typewriter;

    public Color txtColour { get { return tMPro.color; } set { tMPro.color = value; } }

    public float speed { get { return baseSpeed * speedMultiplier; } set { speedMultiplier = value; } }
    private const float baseSpeed = 1;
    private float speedMultiplier = 1;
}
