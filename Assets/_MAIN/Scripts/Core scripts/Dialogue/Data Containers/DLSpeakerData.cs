using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class DLSpeakerData
{
    public string name, castName;
    public Vector2 castPosition;
    public List<(int layer, string expression)> CastExpressions { get; set; }

    private const string nameCastID = " as ";
    private const string positionCastID = " at ";
    private const string expressionCastID = @" \[";

    public DLSpeakerData(string rawSpeaker)
    {
        string pattern = @$"{nameCastID}|{positionCastID}|{expressionCastID}";
        MatchCollection matches = Regex.Matches(rawSpeaker, pattern);

        //populate to avoid null values
        castName = "";
        castPosition = Vector2.zero;
        CastExpressions = new List<(int layer, string expression)>();

        if (matches.Count == 0) //no match - entire line speaker name
        {
            name = rawSpeaker;
            return;
        }

        //if match - isolate speaker name
        int index = matches[0].Index;
        name = rawSpeaker.Substring(0, index);

        for(int i = 0; i < matches.Count; i++)
        {
            Match match = matches[i];
            if(match.Value == nameCastID)
            {

            }
        }


    }
}
