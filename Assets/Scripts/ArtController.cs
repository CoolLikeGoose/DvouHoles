using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArtController : MonoBehaviour
{
    private bool canColor;

    private void OnMouseDown()
    {
        StartCoroutine(ColoringTimer());
    }

    private void OnMouseUp()
    {
        if (GetComponent<Image>().sprite.name == "14")
        {
            PlayerPrefs.SetInt("RGBA(0.835, 0.996, 0.000, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(1.000, 1.000, 0.000, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.353, 0.859, 0.016, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.000, 0.576, 0.867, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(1.000, 0.867, 0.000, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.996, 0.600, 0.000, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.000, 0.000, 0.996, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.424, 0.000, 0.816, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.996, 0.349, 0.000, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.867, 0.071, 0.482, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(1.000, 1.000, 1.000, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.996, 0.000, 0.000, 1.000)", 600);
            PlayerPrefs.SetInt("RGBA(0.282, 0.282, 0.282, 1.000)", 600);
            PlayerPrefs.SetInt("Coins", 300);
        }
        if (!canColor || PaintChooser.Instance.isChoosing)
        {
            return;
        }
        PlayerPrefs.SetString("CurrentArt", GetComponent<Image>().sprite.name);
        PaintChooser.Instance.OnArtClicked();
    }
        
    private IEnumerator ColoringTimer()
    {
        canColor = true;

        yield return new WaitForSeconds(0.15f);

        canColor = false;
    }

    //public IEnumerator WarningAnim()
    //{
    //    warning.color = new Color(warning.color.r, warning.color.g, warning.color.b, 1);
    //    while (warning.color.a > 0)
    //    {
    //        warning.color = new Color(warning.color.r, warning.color.g, warning.color.b, warning.color.a - 0.01f);
    //        warning.transform.position = new Vector2(warning.transform.position.x, warning.transform.position.y + 0.01f);
    //        yield return null;
    //    }

    //    warning.transform.position = warningTextStartPos;
    //}
}
