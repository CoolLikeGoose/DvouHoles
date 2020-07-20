using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public static class DataController
{
    /// <summary>
    /// levelsOrder
    /// Colors
    /// </summary>
    public static List<int> LoadMassive(string fileName)
    {
        string path = $"{Application.persistentDataPath}/{fileName}.goose";
        List<int> levelsData = new List<int>();

        if (File.Exists(path))
        {
            StreamReader data = new StreamReader(path);
            string line;
            while ((line = data.ReadLine()) != null)
            {
                levelsData.Add(Convert.ToInt32(line));
            }
            data.Close();

            return levelsData;
        }
        return null;
    }

    /// <summary>
    /// levelsOrder
    /// Colors
    /// </summary>
    public static void SaveMassive(List<int> massive, string fileName)
    {
        string path = $"{Application.persistentDataPath}/{fileName}.goose";

        StreamWriter levelsData = new StreamWriter(path, false);

        foreach (int levelId in massive)
        {
            levelsData.WriteLine(levelId);
        }
        levelsData.Close();
    }

    public static void Shuffle(List<int> levelsOrder)
    {
        for (int t = 0; t < levelsOrder.Count; t++)
        {
            int tmp = levelsOrder[t];
            int r = UnityEngine.Random.Range(t, levelsOrder.Count);
            levelsOrder[t] = levelsOrder[r];
            levelsOrder[r] = tmp;
        }
    }
}
