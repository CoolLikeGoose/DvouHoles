using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action OnRightCubeAbsorb;
    public static Action OnWrongCubeAbsorb;
    public static Action OnGameStart;
    public static Action OnGameEnd;
    public static Action OnLevelCompleted;

    private void Awake()
    {
        Color[] a = ColorExtensions.LoadMassive();
    }

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void OnClearPrefsBtn()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        OnRightCubeAbsorb = null;
        OnWrongCubeAbsorb = null;
        OnGameStart = null;
        OnGameEnd = null;
        OnLevelCompleted = null;
    }
}
