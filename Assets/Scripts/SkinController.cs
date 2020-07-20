using UnityEngine;

public class SkinController : MonoBehaviour
{
    public SpriteRenderer leftHole;
    public SpriteRenderer rightHole;
    void Start()
    {
        leftHole.sprite = Resources.Load<Sprite>($"Skins/{PlayerPrefs.GetString("LeftHole", "NoneSkin")}");
        rightHole.sprite = Resources.Load<Sprite>($"Skins/{PlayerPrefs.GetString("RightHole", "NoneSkin")}");
    }
}
