using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class DLSpeakerData
{
    public string name, castName;
    public Vector2 castPosition;
    public List<(int layer, string expression)> CastExpressions { get; set; }

    public DLSpeakerData(string rawSpeaker)
    {
        string pattern = @" as |  at | \[";
        MatchCollection matches = Regex.Matches(rawSpeaker, pattern);

        if(matches.Count == 0) //no match - empty
        {
            name = rawSpeaker;
            castName = "";
            castPosition = Vector2.zero;
            CastExpressions = new List<(int layer, string expression)>();
        }
    }
}
