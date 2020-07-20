using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KraskaManager : MonoBehaviour
{
    static public Color[] colorMassiv = new Color[9];
    static public int PickedColor;
    static public bool[] KraskaDone = { false, false, false, false, false, false, false, false, false, false };
    // 1 - черный,  2 - красный, 3 - синий, 4 - зеленый, 5 - желтый, 6 - оранжевый, 7 - голубой, 8 - розовый.
    private void Start()
    {
        colorMassiv[1] = Color.black;
        colorMassiv[2] = Color.red;
        colorMassiv[3] = Color.blue;
        colorMassiv[4] = Color.green;
        colorMassiv[5] = Color.yellow;
        colorMassiv[6] = new Color(255, 165, 0, 255); //orange
        colorMassiv[7] = Color.cyan;
        colorMassiv[8] = Color.magenta;

        for (char i = '1'; i < '9'; i++)
        {
            
            if (GameObject.Find(i+"b(Clone)"))
            {
                PickedColor = i - '0';
                break;
            }
        }
        
    }
    
}
