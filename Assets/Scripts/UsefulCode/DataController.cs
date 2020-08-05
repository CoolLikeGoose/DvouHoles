using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

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

    public static Color[,] ReadImageByPixels(string name, out float cameraPos, out float cameraSize)
    {
        Texture2D image = (Texture2D)Resources.Load($"PixelArts/{name}");

        Color[,] output = new Color[image.width, image.height];

        for (int x = 0; x != image.width; x++)
        {
            for (int y = 0; y != image.height; y++)
            {
                output[x, y] = image.GetPixel(x, y);
            }
        }

        cameraPos = (image.width - 1) / 2f;
        cameraSize = image.width;

        return output;
     }

    public static int FilesAvaible(string directoryName)
    {
        string path = $"{Application.dataPath}/Resources/{directoryName}";
        int count = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length;

        return count /= 2;
    }
}
