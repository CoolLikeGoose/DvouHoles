using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action OnRightCubeAbsorb;
    public static Action OnWrongCubeAbsorb;
    public static Action OnGameStart;
    public static Action OnLevelCompleted;
    public static Action OnCoinCollected;

    private void Awake()
    {
        Color[] a = ColorExtensions.LoadMassive();
    }

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void DeleteAll()
    {
        string[] gooseFiles = System.IO.Directory.GetFiles(Application.persistentDataPath, "*.goose");
        foreach (string path in gooseFiles)
            System.IO.File.Delete(path);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        OnRightCubeAbsorb = null;
        OnWrongCubeAbsorb = null;
        OnGameStart = null;
        OnLevelCompleted = null;
        OnCoinCollected = null;
    }
}
