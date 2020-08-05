using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaintChooser : MonoBehaviour
{
    public static PaintChooser Instance { get; private set; }

    [SerializeField] private GameObject cubePrefab = null;
    [SerializeField] private Transform scrollViewContent = null;

    [SerializeField] private GameObject artChoosingPopup = null;
    [SerializeField] private Image currentSprite = null;
    [SerializeField] private GameObject viewPrefab = null;
    [SerializeField] private Transform scrollViewCubes = null;
 
    [NonSerialized] public bool isChoosing = false;
    private bool canColor = true;

    private List<Color> colorsId;
    private List<int> minusColor;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int avaiblePixelArts = DataController.FilesAvaible("PixelArts");

        for (int i = 0; i != avaiblePixelArts; i++)
        {
            Instantiate(cubePrefab, scrollViewContent).GetComponent<Image>().sprite = Resources.Load<Sprite>($"PixelArts/{i}");
        }
    }

    public void OnArtClicked()
    {
        canColor = true;

        isChoosing = true;
        artChoosingPopup.SetActive(true);

        currentSprite.sprite = Resources.Load<Sprite>($"PixelArts/{PlayerPrefs.GetString("CurrentArt")}");

        List<Color> colors = new List<Color>();
        float v; float c;
        Color[,] pixelArt = DataController.ReadImageByPixels(PlayerPrefs.GetString("CurrentArt"), out v, out c);

        for (int x = 0; x != pixelArt.GetLongLength(0); x++)
        {
            for (int y = 0; y != pixelArt.GetLongLength(1); y++)
            {
                if (pixelArt[x, y] == Color.clear) { continue; }
                colors.Add(pixelArt[x, y]);
            }
        }

        colorsId = colors.Distinct().ToList();
        minusColor = new List<int>();

        for (int i = 0; i != colorsId.Count; i++)
        {
            ColorStat go = Instantiate(viewPrefab, scrollViewCubes).GetComponent<ColorStat>();
            go.selfColor = colorsId[i];

            int colorsToColor = colors.FindAll(x => x == colorsId[i]).Count;
            int nowHave = PlayerPrefs.GetInt(colorsId[i].ToString());
            minusColor.Add(colorsToColor);
            if (nowHave < colorsToColor) { canColor = false; }

            go.selfString = $"{nowHave}/{colorsToColor}";
        }
    }

    public void OnColorBtn()
    {
        if (canColor)
        {
            for (int i = 0; i != colorsId.Count; i++)
            {
                PlayerPrefs.SetInt(colorsId[i].ToString(), PlayerPrefs.GetInt(colorsId[i].ToString()) - minusColor[i]);
            }

            SceneManager.LoadScene(3);
        }
    }

    public void OnCancelBtn()
    {
        isChoosing = false;
        artChoosingPopup.SetActive(false);

        for(int i = 0; i != scrollViewCubes.childCount; i++)
        {
            Destroy(scrollViewCubes.GetChild(i).gameObject);
        }
    }
}
