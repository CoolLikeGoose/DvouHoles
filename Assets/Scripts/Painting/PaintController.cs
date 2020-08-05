using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaintController : MonoBehaviour
{
    public static PaintController Instance { get; private set; }

    [SerializeField] private GameObject gamePopup = null;
    [SerializeField] private GameObject winPopup = null;

    [SerializeField] private TextMeshProUGUI winCoinCounter = null;

    [SerializeField] private GameObject cubePrefab = null;

    [NonSerialized] public List<Color> colors;

    [NonSerialized] public Outline currentOutline;
    [NonSerialized] public Color currentColor;

    public Sprite[] numbers;

    [NonSerialized] public int cubeCount;
    private int constCubeCount;

    public static Action OnPaintingEnd;

    [NonSerialized] public float cameraPos;
    [NonSerialized] public float cameraSize;

    private void Awake()
    {
        Instance = this;

        colors = new List<Color>();
        Color[,] pixelArt = DataController.ReadImageByPixels(PlayerPrefs.GetString("CurrentArt"), out cameraPos, out cameraSize);

        for (int x = 0; x != pixelArt.GetLongLength(0); x++)
        {
            for (int y = 0; y != pixelArt.GetLongLength(1); y++)
            {
                if (pixelArt[x, y] == Color.clear) { continue; }
                Instantiate(cubePrefab, new Vector3(x, y, 0), Quaternion.identity).GetComponent<CubeController>().selfColor = pixelArt[x, y];
                colors.Add(pixelArt[x, y]);
            }
        }

        constCubeCount = cubeCount = colors.Count;
        colors = colors.Distinct().ToList();
    }

    private void Start()
    {
        OnPaintingEnd += () =>
        {
            gamePopup.SetActive(false);
            winPopup.SetActive(true);
            winCoinCounter.text = constCubeCount.ToString();
            PlayerPrefs.SetInt("Coins", constCubeCount);
        };
    }

    private void OnDestroy()
    {
        OnPaintingEnd = null;
    }
}
