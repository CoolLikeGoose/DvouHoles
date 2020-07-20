using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Zakraska : MonoBehaviour
{
    int id_butt;
    int id_kraska;
   
    public Sprite pustota;
   
    public void OnMouseDown()
    {
        id_butt = int.Parse(this.tag);
        Debug.Log(id_butt);
        id_kraska = KraskaManager.PickedColor;
        if (id_kraska == id_butt)
        {
            lvls.KolvoKnopok[id_kraska]--;
            
            if (lvls.KolvoKnopok[id_kraska]==0)
            {
                Debug.Log(GameObject.Find(id_kraska.ToString() + "b(Clone)"));
                KraskaManager.KraskaDone[id_kraska] = true;
                //смена цвета
                Button b = GameObject.Find(id_kraska.ToString() + "b(Clone)").GetComponent<Button>();
                
                ColorBlock cb = b.colors;
                cb.normalColor = new Color32(142, 142, 142, 255);
                b.colors = cb;
                
            }
            this.GetComponent<SpriteRenderer>().sprite = pustota;
            Debug.Log(KraskaManager.colorMassiv[id_kraska]);
            this.GetComponent<SpriteRenderer>().color = KraskaManager.colorMassiv[id_kraska];
            
        }
        else
        {
            lvls.KolvoKnopok[id_butt]++;
            this.GetComponent<SpriteRenderer>().color = new Color(KraskaManager.colorMassiv[id_kraska].r, KraskaManager.colorMassiv[id_kraska].g, KraskaManager.colorMassiv[id_kraska].b, 0.5f);
            
        }
    }
}
