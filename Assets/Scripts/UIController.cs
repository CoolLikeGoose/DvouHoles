using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounter = null;

    [SerializeField] private GameObject menuPopup = null;
    [SerializeField] private GameObject settingsPopup = null;
    [SerializeField] private GameObject gamePopup = null;
    [SerializeField] private GameObject losePopup = null;
    [SerializeField] private GameObject winPopup = null;

    [SerializeField] private Image ObjMusicMuteIcon = null;
    [SerializeField] private Image ObjFXmuteIcon = null;

    [SerializeField] private TextMeshProUGUI coinsCounter = null;

    [SerializeField] private Sprite muteIcon = null;
    [SerializeField] private Sprite unMuteIcon = null;
    //private GameObject currentpopup;

    private int score = 0;
    private int coins = 0;

    private bool isGameStarted;

    //control the progress bar
    [SerializeField] private Image progressBar = null;
    [SerializeField] private TextMeshProUGUI nowLvl = null;
    [SerializeField] private TextMeshProUGUI futureLvl = null;

    //[NonSerialized] public List<GameObject> cubeStorages;
    private int cubesOnTheMap;

    [SerializeField] private TextMeshProUGUI warmText = null;
    [SerializeField] private TextMeshProUGUI coldText = null;

    [SerializeField] private Image warmSprite = null;
    [SerializeField] private Image coldSprite = null;

    private void Awake()
    {
        int lvl = PlayerPrefs.GetInt("GlobalLvl", 1);
        nowLvl.text = lvl.ToString();
        futureLvl.text = (lvl + 1).ToString();
    }

    private void Start()
    {
        StartCoroutine(WaitUntilCubesCount());

        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsCounter.text = coins.ToString();

        SubscribeToAllActions();

        OnFXMute(PlayerPrefs.GetInt("fxMuted", 1));
        OnMusicMute(PlayerPrefs.GetInt("musicMuted", 1));
    }

    private IEnumerator WaitUntilCubesCount()
    {
        yield return new WaitUntil(() => CubeConfiguration.Instance.cubesOnTheMap != 0);

        cubesOnTheMap = CubeConfiguration.Instance.cubesOnTheMap;
    }

    private void FillProgressBar()
    {
        progressBar.fillAmount += 1 / (float)cubesOnTheMap;
        if (progressBar.fillAmount > 0.999f) { GameManager.OnLevelCompleted(); }
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
            losePopup.SetActive(true);
            gamePopup.SetActive(false);
            PlayerPrefs.SetInt("Coins", coins);
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
        GameManager.OnLevelCompleted += LevelComplete;
        GameManager.OnCoinCollected += () =>
        {
            coins++;
            coinsCounter.text = coins.ToString();
        };
    }

    private void LevelComplete()
    {
        PlayerPrefs.SetInt("LocalLvl", PlayerPrefs.GetInt("LocalLvl") + 1);

        PlayerPrefs.SetInt("Coins", coins);

        gamePopup.SetActive(false);

        winPopup.SetActive(true);

        string warmColorName = CubeConfiguration.Instance.colors[0].ToString();
        string coldColorName = CubeConfiguration.Instance.colors[1].ToString();

        PlayerPrefs.SetInt(warmColorName, PlayerPrefs.GetInt(warmColorName) + CubeConfiguration.Instance.warmCubes);
        PlayerPrefs.SetInt(coldColorName, PlayerPrefs.GetInt(coldColorName) + CubeConfiguration.Instance.coldCubes);

        warmSprite.color = CubeConfiguration.Instance.colors[0];
        coldSprite.color = CubeConfiguration.Instance.colors[1];

        warmText.text = "x" + CubeConfiguration.Instance.warmCubes.ToString();
        coldText.text = "x" + CubeConfiguration.Instance.coldCubes.ToString();
    }
    /// <summary>
    /// Mute music and display that on GUI
    /// 
    /// </summary>
    /// <param name="state">0 equal false(OFF); 1 equal true(ON); 2 to get current state from audio source</param>
    public void OnMusicMute(int state)
    {

        Sprite nowSprite = muteIcon;

        if (state == 2)
        {
            if (SoundManager.Instance.musicMute) { state = 1; }
            else { state = 0; }
        }
        if (state == 1)
        {
            nowSprite = unMuteIcon;
            SoundManager.Instance.musicMute = false;
        }
        else
        {
            SoundManager.Instance.musicMute = true;
        }

        ObjMusicMuteIcon.sprite = nowSprite;

        PlayerPrefs.SetInt("musicMuted", state);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Mute sound FX and display that on GUI
    /// </summary>
    /// <param name="state">0 equal false(OFF; 1 equal true(ON); 2 to get current state from audio source</param>
    public void OnFXMute(int state)
    {

        Sprite nowSprite = muteIcon;

        if (state == 2)
        {
            if (SoundManager.Instance.soundFXMute) { state = 1; }
            else { state = 0; }
        }

        if (state == 1)
        {
            nowSprite = unMuteIcon;
            SoundManager.Instance.soundFXMute = false;
        }
        else
        {
            SoundManager.Instance.soundFXMute = true;
        }

        ObjFXmuteIcon.sprite = nowSprite;

        PlayerPrefs.SetInt("fxMuted", state);
        PlayerPrefs.Save();
    }
}
