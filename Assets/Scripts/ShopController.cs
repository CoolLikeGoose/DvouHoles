using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance { get; private set; }

    public Image[] buttons; //0 - ColorsShopButton, 1 - HoleSkinsShopButton, 2 - PaintingsShopButton
    public GameObject[] panels; //0 - ColorsShopPanel, 1 - HoleSkinsShopPanel, 2 - PaintingsShopPanel
    public Image[] checkMarks;
    public GameObject[] buyUI;
    public Text coinsNow;
    public Text warning;
    Vector2 warningTextStartPos;
    Image[] currentCheckMarks = new Image[4]; //0 - Warm, 1 - Cold, 2 - Left, 3 = Right
    Color[] saveColors = new Color[2]; //0 - warm color, 1 - cold color

    private void Awake()
    {
        Instance = this;
        LoadLocks();
    }
    void Start()
    {
        warningTextStartPos = warning.transform.position;
        saveColors = ColorExtensions.LoadMassive();
        LoadCheckMarks();

        buttons[0].color = Color.gray;
        buttons[1].color = Color.white;
        panels[0].SetActive(true);
        panels[1].SetActive(false);
    }

    private void Update()
    {
        coinsNow.text = $"{PlayerPrefs.GetInt("Coins")}";
    }

    public void SaveAll()
    {
        SaveCheckMark();
        SaveLocks();
    }

    public void Shop(int thisButtonNumber)
    {
        buttons[thisButtonNumber].color = Color.gray;
        panels[thisButtonNumber].SetActive(true);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i != thisButtonNumber)
            {
                buttons[i].color = Color.white;
                panels[i].SetActive(false);
            }
            else 
                continue;
            
        }
    }

    public void ShopSkin(string holePosition)
    {
        Transform _transform = EventSystem.current.currentSelectedGameObject.transform;
        PlayerPrefs.SetString($"{holePosition}Hole", EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Image>().sprite.name);
        if (holePosition == "Left")
        {
            if(currentCheckMarks[2] != null)
                currentCheckMarks[2].enabled = false;/*.SetActive(false);*/
            currentCheckMarks[2] = _transform.GetChild(0).GetComponent<Image>();/*.gameObject;*/
            currentCheckMarks[2].enabled = true;//*.SetActive(true);*/;
        }
        else
        {
            if (currentCheckMarks[3] != null)
                currentCheckMarks[3].enabled = false;/*?.SetActive(false);*/
            currentCheckMarks[3] = _transform.GetChild(0).GetComponent<Image>();
            currentCheckMarks[3].enabled = true;/*.SetActive(true)*/;
        }
    }

    public void CheatMoney()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 15);
    }

    public IEnumerator WarningAnim()
    {
        warning.color = new Color(warning.color.r, warning.color.g, warning.color.b, 1);
        while (warning.color.a > 0) 
        {
            warning.color = new Color(warning.color.r, warning.color.g, warning.color.b, warning.color.a - 0.01f);
            warning.transform.position = new Vector2(warning.transform.position.x, warning.transform.position.y + 0.01f);
            yield return null;
        }

        warning.transform.position = warningTextStartPos;
    }
    
   public void SaveColor(int massIndex)
   {
        Transform _transform = EventSystem.current.currentSelectedGameObject.transform;
        saveColors[massIndex] = _transform.GetChild(0).GetComponent<Image>().color;
        if (massIndex == 0)
        {
            if (currentCheckMarks[0] != null)
                currentCheckMarks[0].enabled = false;/*?.SetActive(false);*/
            currentCheckMarks[0] = _transform.GetChild(1).GetComponent<Image>();/*.gameObject;*/
            currentCheckMarks[0].enabled = true;/*.SetActive(true);*/
        }
        else
        {
            if(currentCheckMarks[1] != null)
            currentCheckMarks[1].enabled = false/*?.SetActive(false)*/;
            currentCheckMarks[1] = _transform.GetChild(1).GetComponent<Image>();/*.gameObject;*/
            currentCheckMarks[1].enabled = true;/*.SetActive(true);*/
        }
        ColorExtensions.SaveColorMassive(saveColors);
   }

    public void SaveLocks()
    {
        string path = Application.persistentDataPath + "/Locks.goose";

        StreamWriter sw = new StreamWriter(path, false);

        for (int i = 0; i < buyUI.Length; i++)
        {
            if (buyUI[i] == null)
            {
                sw.WriteLine($"{i}");
            }
        }
        sw.Close();
    }

    void LoadLocks()
    {
        string path = Application.persistentDataPath + "/Locks.goose";

        int j;

        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);

            for (int i = 0; i < File.ReadAllLines(path).Length; i++)
            {
                j = int.Parse(sr.ReadLine());
                Destroy(buyUI[j]);
            }
            sr.Close();
        }
    }

    void SaveCheckMark()
    {
        string path = Application.persistentDataPath + "/CheckMarksIndex.goose";

        StreamWriter sw = new StreamWriter(path, false);

        for (int i = 0; i < checkMarks.Length; i++)
        {
            if (checkMarks[i].enabled/*.gameObject.activeSelf*/)
            {
                sw.WriteLine($"{i}");
            }
        }
        sw.Close();
    }

    void LoadCheckMarks()
    {
        string path = Application.persistentDataPath + "/CheckMarksIndex.goose";

        int j;

        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);

            for (int i = 0; i < 4; i++)
            {
                j = int.Parse(sr.ReadLine());
                checkMarks[j].enabled = true;
                currentCheckMarks[i] = checkMarks[j];
            }
            sr.Close();
        }
        else
        {
            checkMarks[0].enabled = true;
            checkMarks[7].enabled = true;
            checkMarks[14].enabled = true;
            checkMarks[16].enabled = true;
            currentCheckMarks[0] = checkMarks[0];
            currentCheckMarks[1] = checkMarks[7];
            currentCheckMarks[2] = checkMarks[14];
            currentCheckMarks[3] = checkMarks[16];
        }
    }

}

