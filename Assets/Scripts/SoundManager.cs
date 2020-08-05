using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource soundSource = null;
    [SerializeField] private AudioSource musicSource = null;

    [SerializeField] private AudioClip winSound = null;
    [SerializeField] private AudioClip loseSound = null;
    [SerializeField] private AudioClip paintingSound = null;
    [SerializeField] private AudioClip buyingSound = null;
    //[SerializeField] private AudioClip winClip = null;

    private bool losePlaying = false;

    public bool musicMute
    {
        get { return musicSource.mute; }
        set { musicSource.mute = value; }
    }
    /// <summary>
    /// Property for mute sound FX
    /// </summary>
    public bool soundFXMute
    {
        get { return soundSource.mute; }
        set { soundSource.mute = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameManager.OnLevelCompleted += () =>
        {
            //Дебаг не убирать, без него не работает 
            //А теперь работает, но все равно оставлю его здесь
            //Debug.Log("sound");
            soundSource.PlayOneShot(winSound);
        };
        GameManager.OnWrongCubeAbsorb += () =>
        {
            if (losePlaying) { return; }
            soundSource.PlayOneShot(loseSound);
            losePlaying = true;
        };

    }
    public void OnPaintCube()
    {
        soundSource.PlayOneShot(paintingSound);
    }
    public void OnBuyingProcess()
    {
        soundSource.PlayOneShot(buyingSound);
    }
}
