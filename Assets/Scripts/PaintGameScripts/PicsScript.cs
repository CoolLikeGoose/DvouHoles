using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PicsScript : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;
    int money;
    public Button[] buttons;
    public Sprite[] Sprites;
    int[] prices = { 0, 10, 50, 100 };
    
    public void Click(int id)
    {
        switch (PlayerPrefs.GetInt("Pic" + id, 0))
        {
            case 0:
                if (PlayerPrefs.GetInt("Coins", 0) > prices[id])
                {
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - prices[id]);
                    PlayerPrefs.SetInt("Pic" + id, 1);
                    //результаты: 0 - нету картинки (не куплена)
                    //1 - куплена, но не раскрашена
                    //2 - раскрашена
                }
                break;
            case 1:
            case 2:
                PlayerPrefs.SetInt("Number", id + 1);
                SceneManager.LoadScene(3); //Тут переходим на сцену с рисуночками(мне лень было смотреть на айди)
                //Создаем объект, который донтдестрой он лоад или пишем в плеер префс айди. 
                //Затем на сцене с пиксартами считываем айди и рисуем ту картиночку по этому айди
                break;
            default:
                Debug.LogError("Кто даун и запихал в плеер префс парашу какую-то???? Параша: " + PlayerPrefs.GetInt("Pic" + id) + "Кнопка: " + id);
                break;
        }

    }
    void Start()
    {
        PlayerPrefs.SetInt("Pic0", 2);
        PlayerPrefs.SetInt("Pic1", 1);
        PlayerPrefs.SetInt("Pic2", 1);
        PlayerPrefs.SetInt("Pic3", 1);
        if (PlayerPrefs.HasKey("Coins"))
        {
            money = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            PlayerPrefs.SetInt("Coins", 0);
            money = 0;
        }
        CoinsText.text = money.ToString();
        for (int i = 0; i < buttons.Length; i++) //Проверка раскрасил чел эту картинку или нет (через плеер префс делать надо, если будет надо напиши)
        {

            if (PlayerPrefs.HasKey("Pic" + i))
            {
                //результаты: 0 - нету картинки (не куплена)
                //1 - куплена, но не раскрашена
                //2 - раскрашена
                switch (PlayerPrefs.GetInt("Pic" + i))
                {
                    case 0:
                        //..Debug.Log("Картинка не куплена" + i);
                        //buttons[i].image = //Спрайт не купленной и не раскрашенной картинки, даже сюда можно ничего не писать, просто подефолту поставить такой спрайт;
                    break;
                    case 1:
                        //Debug.Log("Картинка куплена, но не раскрашена" + i);
                        //buttons[i].image = //Спрайт не раскрашенной картинки;
                    break;
                    case 2:
                        Debug.Log("Картинка и куплена, и раскрашена" + 1);
                        buttons[i].GetComponent<Image>().sprite = Sprites[i];
                    break;
                    default:
                        Debug.LogError("Кто даун и запихал в плеер префс парашу какую-то???? Параша: " + PlayerPrefs.GetInt("Pic" + i) + "Кнопка: " + i);
                        break;
                }

            }
            else
            {
                PlayerPrefs.SetInt("Pic" + i, 0);
            }
        }
    }


}
