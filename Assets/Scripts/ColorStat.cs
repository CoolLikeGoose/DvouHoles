using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorStat : MonoBehaviour
{
    [SerializeField] private Image cubeImage;
    [SerializeField] private TextMeshProUGUI cubeCounter;

    [NonSerialized] public Color selfColor;
    [NonSerialized] public string selfString = "Eta herna ne rabotaet";

    private void Start()
    {
        cubeImage.color = selfColor;
        cubeCounter.text = selfString;
    }
}
