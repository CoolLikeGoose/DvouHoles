using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Button[] buttons; //0 - ColorsShopButton, 1 - HoleSkinsShopButton, 2 - PaintingsShopButton
    public GameObject[] panels; //0 - ColorsShopPanel, 1 - HoleSkinsShopPanel, 2 - PaintingsShopPanel
    //public Image[] checkMarks;
    Color[] saveColors = new Color[2]; //0 - warm color, 1 - cold color

    void Start()
    {
        saveColors = ColorExtensions.LoadMassive();

        buttons[0].GetComponent<Image>().color = Color.gray;
        buttons[1].GetComponent<Image>().color = Color.white;
        buttons[2].GetComponent<Image>().color = Color.white;
        panels[0].SetActive(true);
        panels[1].SetActive(false);
        panels[2].SetActive(false);
    }

    public void Shop(int thisButtonNumber)
    {
        buttons[thisButtonNumber].GetComponent<Image>().color = Color.gray;
        panels[thisButtonNumber].SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == thisButtonNumber)
                continue;
            else
            {
                buttons[i].GetComponent<Image>().color = Color.white;
                panels[i].SetActive(false);
            }
        }
    }

    public void ShopSkin(string holePosition)
    {
        PlayerPrefs.SetString($"{holePosition}Hole", EventSystem.current.currentSelectedGameObject.name);
    }

    //public void SaveCheckMark()
    //{
    //    for (int i = 0; i < checkMarks.Length; i++)
    //    {
    //        if (checkMarks[i].gameObject.activeSelf)
    //        {
    //            PlayerPrefs.SetInt($"ActiveCheckMars{i}", i);
    //        }
    //    }
    //}

    //void LoadCheckMarks()
    //{
    //    for (int i = 0; i < checkMarks.Length; i++)
    //    {
    //        if (PlayerPrefs.GetInt($"ActiveCheckMars{i}") == i)
    //            checkMarks[i].gameObject.SetActive(true);
    //    }
    //}

    public void SaveColor(int massIndex)
    {
        saveColors[massIndex] = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().color;
        ColorExtensions.SaveColorMassive(saveColors);
    }
}
