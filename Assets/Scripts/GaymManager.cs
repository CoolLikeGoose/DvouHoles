using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GaymManager : MonoBehaviour
{
    ////А зачем нужен этот скрипт когда есть MenuController 
    ////Он лежит рядом и делает тоже самое
    ////я его сделал для меню + он был первый (если чо), кста щас он нужен уже
    //public Button[] buttons;
    //public Sprite[] sprites;
    //public GameObject Cases, Alert, Skins;
    //int CountCases;
    //private int[] SkinsCost = { 0, 10, 100 };
    //private void Start()
    //{
    //    CountCases = 0;
    //    /*for(int i = 0; i < Skins.length; i++){
    //        if(PlayerPrefs.GetInt("Skin" + id) == 1){
    //            //Если надо, то показываем, что скин куплен
    //        }
    //    */
    //}
    //public void Buy(int id)
    //{
    //    //PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", ammount) - SkinsCost[id]);
    //    Debug.Log("Bought skin");
    //    //PlayerPrefs.SetInt("Skin" + id, 1);
    //}
    //public void OnCases(bool a)
    //{
    //    if (!a)
    //    {
    //        foreach (Button btn in buttons)
    //        {
    //            btn.GetComponent<Image>().sprite = sprites[0];
    //        }
    //        Alert.SetActive(false);
    //        CountCases = 0;
    //    }
    //    Cases.SetActive(a);
    //}
    //public void ChangeSkin(int id)
    //{
    //    if (CountCases < 3)
    //    {
    //        buttons[id].GetComponent<Image>().sprite = sprites[1];
    //        CountCases++;
    //        if (CountCases == 3)
    //            Alert.SetActive(true);
    //    }
    //    else
    //    {
    //        Debug.Log("soufg");
    //    }
    //}
    //public void LoadScene(int id) //id сцены, которую загружать
    //{
    //    SceneManager.LoadScene(id);
    //}
    //public void Quit()
    //{
    //    Application.Quit();
    //}
}
