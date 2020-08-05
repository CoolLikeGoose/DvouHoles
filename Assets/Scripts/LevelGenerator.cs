using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //that massive
    //public int[] thatMassive = new int[2] { 1, 2 };
    private List<int> lvlOrder;

    private void Awake()
    {
        int levelAvaible = DataController.FilesAvaible("Levels");
        Debug.Log(levelAvaible);

        GameManager.OnLevelCompleted += () =>
        {
            if (PlayerPrefs.GetInt("LocalLvl", 0) == levelAvaible-1)
            {
                DataController.Shuffle(lvlOrder);
                DataController.SaveMassive(lvlOrder, "levelsOrder");
                PlayerPrefs.SetInt("LocalLvl", 0);
            }
            PlayerPrefs.SetInt("GlobalLvl", PlayerPrefs.GetInt("GlobalLvl", 1) + 1);
        };

        lvlOrder = DataController.LoadMassive("levelsOrder");

        if (lvlOrder == null || lvlOrder.Count != levelAvaible)
        {
            Debug.Log("a");
            lvlOrder = new List<int>();

            for (int i = 1; i != levelAvaible+1; i++)
            {
                lvlOrder.Add(i);
            }

            DataController.Shuffle(lvlOrder);
            DataController.SaveMassive(lvlOrder, "levelsOrder");
        }

        //Debug.Log(lvlOrder.Count);
        //Debug.Log(PlayerPrefs.GetInt("LocalLvl", 0));
        //Debug.Log("lvl " + PlayerPrefs.GetInt("LocalLvl", 0));
        Instantiate(Resources.Load("Levels/" + lvlOrder[PlayerPrefs.GetInt("LocalLvl", 0)].ToString()));
    }
}
