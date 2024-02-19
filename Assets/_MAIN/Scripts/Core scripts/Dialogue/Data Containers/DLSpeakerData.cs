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
    private const char axisDelimiterID = ':';

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
            int startIndex = 0, endIndex = 0;

            if(match.Value == nameCastID)
            {
                startIndex = match.Index + nameCastID.Length;
                endIndex = (i < matches.Count - 1) ? matches[i + 1].Index : rawSpeaker.Length;
                castName = rawSpeaker.Substring(startIndex, endIndex - startIndex);
            }
            else if(match.Value == positionCastID)
            {
                startIndex = match.Index + positionCastID.Length;
                endIndex = (i < matches.Count - 1) ? matches[i + 1].Index : rawSpeaker.Length;
                string castPos = rawSpeaker.Substring(startIndex, endIndex - startIndex);

                string[] axis = castPos.Split(axisDelimiterID, System.StringSplitOptions.RemoveEmptyEntries);

                float.TryParse(axis[0], out castPosition.X);

                if (axis.Length > 1)
                    float.TryParse(axis[1], out castPosition.y);
            }
        }


    }
}
