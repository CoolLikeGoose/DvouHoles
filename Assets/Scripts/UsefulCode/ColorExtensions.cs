using System.Globalization;
using System.IO;
using UnityEngine;

public static class ColorExtensions
{
    static char[] deleThisShitPls = new char[] {'R', 'G', 'B', 'A', '(', ')' };
    public static Color ParseColor(string aCol)
    {
        aCol = aCol.Trim(deleThisShitPls);
        var strings = aCol.Split(',');
        Color output = Color.black;
        for (var i = 0; i < strings.Length; i++)
        {
            output[i] = float.Parse(strings[i], CultureInfo.InvariantCulture);
        }
        return output;
    }

    public static Color[] LoadMassive()
    {
        string path = Application.persistentDataPath + "/Colors.goose";
        Color[] colorsData = new Color[2];

        if (File.Exists(path))
        {
            StreamReader data = new StreamReader(path);

            for (int i = 0; i < 2; i++)
            {
                colorsData[i] = ParseColor(data.ReadLine());
                if (colorsData[i][3] == 0 && i == 0) { colorsData[i] = new Color(0.2830189f, 0.2816839f, 0.2816839f); }
                else if (colorsData[i][3] == 0) { colorsData[i] = new Color(1, 1, 1); }
            }
            data.Close();

            return colorsData;
        }
        return new Color[] { new Color(0.2830189f, 0.2816839f, 0.2816839f), new Color(1, 1, 1) };
    }

    public static void SaveColorMassive(Color[] massive)
    {
        string path = $"{Application.persistentDataPath}/Colors.goose";

        StreamWriter levelsData = new StreamWriter(path, false);

        foreach (Color levelId in massive)
        {
            levelsData.WriteLine(levelId);
        }
        levelsData.Close();
    }
}
