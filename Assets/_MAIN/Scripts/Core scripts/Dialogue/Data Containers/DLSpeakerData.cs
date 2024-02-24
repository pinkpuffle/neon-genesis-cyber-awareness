using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

namespace DIALOGUE
{
    public class DLSpeakerData
    {
        public string name, castName;
        public string displayName => castName != string.Empty ? castName : name; //name that will display in dialogue box
        public Vector2 castPosition;
        public List<(int layer, string expression)> CastExpressions { get; set; }

        private const string nameCastID = " as ";
        private const string positionCastID = " at ";
        private const string expressionCastID = " [";
        private const char axisDelimiter = ':';
        private const char expressionLayerJoiner = ','; //joins expression casting 
        private const char expressionLayerDelimiter = ':'; //separate layer from expression

        public DLSpeakerData(string rawSpeaker)
        {
            string pattern = @$"{nameCastID}|{positionCastID}|{expressionCastID.Insert(expressionCastID.Length - 1, @"\")}";
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

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                int startIndex = 0, endIndex = 0;

                if (match.Value == nameCastID) // " as "
                {
                    startIndex = match.Index + nameCastID.Length;
                    endIndex = i < matches.Count - 1 ? matches[i + 1].Index : rawSpeaker.Length;
                    castName = rawSpeaker.Substring(startIndex, endIndex - startIndex);
                }
                else if (match.Value == positionCastID) //" at "
                {
                    startIndex = match.Index + positionCastID.Length;
                    endIndex = i < matches.Count - 1 ? matches[i + 1].Index : rawSpeaker.Length;
                    string castPos = rawSpeaker.Substring(startIndex, endIndex - startIndex);

                    string[] axis = castPos.Split(axisDelimiter, System.StringSplitOptions.RemoveEmptyEntries);

                    float.TryParse(axis[0], out castPosition.x);

                    if (axis.Length > 1)
                        float.TryParse(axis[1], out castPosition.y);
                }
                else if (match.Value == expressionCastID) //" ["
                {
                    startIndex = match.Index + expressionCastID.Length;
                    endIndex = i < matches.Count - 1 ? matches[i + 1].Index : rawSpeaker.Length;
                    string castExp = rawSpeaker.Substring(startIndex, endIndex - (startIndex + 1));

                    CastExpressions = castExp.Split(expressionLayerJoiner)
                        .Select(x => //split into array, each item split - integer for layer, name for expression
                        {
                            var parts = x.Trim().Split(expressionLayerDelimiter);
                            return (int.Parse(parts[0]), parts[1]);
                        }).ToList();
                }
            }


        }
    }
}