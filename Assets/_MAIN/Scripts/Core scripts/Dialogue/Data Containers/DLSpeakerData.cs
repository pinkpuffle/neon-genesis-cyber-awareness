using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLSpeakerData
{
    public string name, castName;
    public Vector2 castPosition;
    public List<(int layer, string expression)> CastExpressions { get; set; }

    public DLSpeakerData(string rawSpeaker)
    {

    }
}
