using UnityEngine;

public class SkinController : MonoBehaviour
{
    public SpriteRenderer leftHole;
    public SpriteRenderer rightHole;
    void Start()
    {
        Debug.Log("a"+PlayerPrefs.GetString("RightHole", "NoneSkin")+"a");
        //rightHole.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Skins/{PlayerPrefs.GetString("RightHole", "NoneSkin")}");
        leftHole.sprite = Resources.Load<Sprite>($"Skins/{PlayerPrefs.GetString("LeftHole", "NoneSkin")}");
        rightHole.sprite = Resources.Load<Sprite>($"Skins/{PlayerPrefs.GetString("RightHole", "NoneSkin")}");
    }
}
