using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounter;

    [SerializeField] private GameObject menuPopup;
    [SerializeField] private GameObject settingsPopup;
    [SerializeField] private GameObject gamePopup;
    [SerializeField] private GameObject losePopup;
    [SerializeField] private GameObject winPopup;
    //private GameObject currentpopup;

    private int score = 0;

    private bool isGameStarted;

    //control the progress bar
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI nowLvl;
    [SerializeField] private TextMeshProUGUI futureLvl;

    //[NonSerialized] public List<GameObject> cubeStorages;
    private int cubesOnTheMap;

    private void Awake()
    {
        int lvl = PlayerPrefs.GetInt("GlobalLvl", 1);
        nowLvl.text = lvl.ToString();
        futureLvl.text = (lvl + 1).ToString();
    }

    private void Start()
    {
        StartCoroutine(WaitUntilCubesCount());

        SubscribeToAllActions();
    }

    private IEnumerator WaitUntilCubesCount()
    {
        yield return new WaitUntil(() => CubeConfiguration.Instance.cubesOnTheMap != 0);

        cubesOnTheMap = CubeConfiguration.Instance.cubesOnTheMap;
    }

    private void FillProgressBar()
    {
        progressBar.fillAmount += 1 / (float)cubesOnTheMap;
        if (progressBar.fillAmount > 0.999f) { GameManager.OnGameEnd(); }
    }

    public void TurnSettingsPopup()
    {
        settingsPopup.SetActive(!settingsPopup.activeSelf);
        //fix this shit later
        menuPopup.SetActive(!menuPopup.activeSelf);
    }
    
    private void SubscribeToAllActions()
    {
        GameManager.OnRightCubeAbsorb += () =>
        {
            score += 10;
            scoreCounter.text = score.ToString();
            FillProgressBar();
        };
        GameManager.OnWrongCubeAbsorb += () =>
        {
            score -= 100;
            scoreCounter.text = score.ToString();
            FillProgressBar();
        };
        GameManager.OnGameStart += () =>
        {
            if (!isGameStarted)
            {
                menuPopup.SetActive(false);
                gamePopup.SetActive(true);
                isGameStarted = true;
            }
        };
        GameManager.OnGameEnd += () =>
        {
            if (score < 0) { losePopup.SetActive(true); }
            else
            {
                winPopup.SetActive(true);
                PlayerPrefs.SetInt("LocalLvl", PlayerPrefs.GetInt("LocalLvl") + 1);
                GameManager.OnLevelCompleted();
            }
            gamePopup.SetActive(false);
        };
    }
}
