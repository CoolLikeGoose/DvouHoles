using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //that massive
    //public int[] thatMassive = new int[2] { 1, 2 };
    private List<int> lvlOrder;

    [Range(1, 10000)]
    [SerializeField] private int levelAvaible;

    private void Awake()
    {
        GameManager.OnLevelCompleted += () =>
        {
            if (PlayerPrefs.GetInt("LocalLvl", 0) == levelAvaible)
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
            lvlOrder = new List<int>();

            for (int i = 1; i != levelAvaible+1; i++)
            {
                lvlOrder.Add(i);
            }

            DataController.Shuffle(lvlOrder);
            DataController.SaveMassive(lvlOrder, "levelsOrder");
        }

        //Debug.Log("lvl " + lvlOrder[PlayerPrefs.GetInt("LocalLvl", 0)]);
        Instantiate(Resources.Load(lvlOrder[PlayerPrefs.GetInt("LocalLvl", 0)].ToString()));
    }
}
