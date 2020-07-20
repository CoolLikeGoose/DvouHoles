using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class UI_spawner : MonoBehaviour
{
    public Button[] kraska_buttons;
    Vector3 startPos = new Vector3(100, -90, 0);
    int CSGO = 0;
    public Transform RoditelKnopok;


    public void LateStart()
    {
        for (char i = '1'; i < '9'; i++)
        {
            for (int g = 0; g < lvls.code.Length; g++)
            {
                if (i == lvls.code[g])
                {
                    RoditelKnopok.GetComponent<RectTransform>().sizeDelta = new Vector2(RoditelKnopok.GetComponent<RectTransform>().sizeDelta.x + 156.25f, RoditelKnopok.GetComponent<RectTransform>().sizeDelta.y);
                    break;
                }
            }
        }
        for (char i = '1'; i < '9'; i++)
        {
            for (int g = 0; g < lvls.code.Length; g++)
            {
                if (i == lvls.code[g])
                {
                    Button uiSpawned = Instantiate(kraska_buttons[(i - '0') - 1], startPos, Quaternion.identity, RoditelKnopok);
                    uiSpawned.transform.localPosition = startPos;
                    //Debug.Log(i + " + " + uiSpawned.transform.localPosition);
                    startPos.x += 150f;
                    break;
                }
            }
        }
    }


} //<---- Друг народа
// Саня лох