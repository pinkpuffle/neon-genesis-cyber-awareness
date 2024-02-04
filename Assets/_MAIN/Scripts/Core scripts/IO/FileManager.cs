using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager
{
    public static List<string> ReadTxtFile(string filePath, bool includeBlankLines = true) //reference absolute path
    {
        if (!filePath.StartsWith('/')) //if not absolute path
            filePath = FilePaths.root + filePath;

        List<string> lines = new List<string>();
        try
        {
            using(StreamReader sr = new StreamReader(filePath))
            {
                while(!sr.EndOfStream) //still lines to read
                {
                    string line = sr.ReadLine();
                    if (includeBlankLines || !string.IsNullOrWhiteSpace(line))
                        lines.Add(line);
                }
            }
        }
        catch(FileNotFoundException ex)
        {
            Debug.LogError($"File not found: '{ex.FileName}'");
        }

        return lines;
    }

    public static List<string> ReadTxtAsset(string filePath, bool includeBlankLines = true) //reference within resources
    {
        return null;
    }
}
