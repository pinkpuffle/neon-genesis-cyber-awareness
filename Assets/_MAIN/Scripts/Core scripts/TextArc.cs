using System.Collections;
using UnityEngine;
using TMPro;

public class TextArc
{
    //text types
    private TextMeshProUGUI tMProUI;
    private TextMeshPro tMProWorld;
    public TMP_Text tMPro => tMProUI != null ? tMProUI : tMProWorld;

    public string currentTxt => tMPro.text;
    public string targetTxt { get; private set; } = "";
    public string preTxt { get; private set; } = "";
    private int preTxtLength = 0;

    public string fullTargetTxt => preTxt + targetTxt;

    //select type
    public enum BuildMethod { instant, typewriter, fade}
    public BuildMethod buildMethod = BuildMethod.typewriter;

    //control colour
    public Color txtColour { get { return tMPro.color; } set { tMPro.color = value; } }

    //control speed
    public float speed { get { return baseSpeed * speedMultiplier; } set { speedMultiplier = value; } }
    private const float baseSpeed = 1;
    private float speedMultiplier = 1;

    public int charactersPerCycle { get { return speed <= 2f ? characterMultiplier : speed <= 2.5f ? characterMultiplier * 2 : characterMultiplier * 3; } } //variable speed
    private int characterMultiplier = 1;

    public bool speedUp = false;

    public TextArc(TextMeshProUGUI tMProUI)
    {
        this.tMProUI = tMProUI;
    }
    public TextArc(TextMeshPro tMProWorld)
    {
        this.tMProWorld = tMProWorld;
    }

    //build text
    public Coroutine Build(string txt)
    {
        preTxt = "";
        targetTxt = txt;

        Stop();

        buildProcess = tMPro.StartCoroutine(Building());
        return buildProcess;
    }

    //append text to already built
    public Coroutine Append(string txt)
    {
        preTxt = tMPro.text;
        targetTxt = txt;

        Stop();

        buildProcess = tMPro.StartCoroutine(Building());
        return buildProcess;
    }


    private Coroutine buildProcess = null;
    public bool isBuilding => buildProcess != null;

    public void Stop()
    {
        if (!isBuilding)
            return;

        tMPro.StopCoroutine(buildProcess);
        buildProcess = null;
    }

    //building process
    IEnumerator Building()
    {
        Prepare();

        switch (buildMethod)
        {
            case BuildMethod.typewriter:
                yield return BuildTypewriter();
                break;
            case BuildMethod.fade:
                yield return BuildFade();
                break;
        }


    }

    private void Oncomplete()
    {
        buildProcess = null;
    }

    //prepare based on build method
    private void Prepare()
    {
        switch (buildMethod)
        {
            case BuildMethod.instant:
                PrepareInstant();
                break;
            case BuildMethod.typewriter:
                PrepareTypewriter();
                break;
            case BuildMethod.fade:
                PrepareFade();
                break;
        }
    }

    private void PrepareInstant()
    {
        tMPro.color = tMPro.color; //reinitilize
        tMPro.text = fullTargetTxt;
        tMPro.ForceMeshUpdate(); //force update
        tMPro.maxVisibleCharacters = tMPro.textInfo.characterCount; //every char visible
    }
    private void PrepareTypewriter()
    {

    }

    private void PrepareFade()
    {

    }


    private IEnumerator BuildTypewriter()
    {
        yield return null;
    }

    private IEnumerator BuildFade()
    {
        yield return null;
    }
}
