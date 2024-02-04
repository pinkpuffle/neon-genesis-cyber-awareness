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

        }
        catch(FileNotFoundException ex)
        {
            Debug.LogError($"File not found: '{ex.FileName}'");
        }

        return lunesl
    }

    public static List<string> ReadTxtAsset(string filePath, bool includeBlankLines = true) //reference within resources
    {
        return null;
    }
}
