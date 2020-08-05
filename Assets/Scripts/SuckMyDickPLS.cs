using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SuckMyDickPLS : MonoBehaviour, IPointerClickHandler
{
    public int price;
    public Button butt;
    public Text priceT;

    void Start()
    {
        butt.enabled = false;
        priceT.text = $"{price}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerPrefs.GetInt("Coins") >= price)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - price);
            butt.enabled = true;
            SoundManager.Instance.OnBuyingProcess();
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(ShopController.Instance.WarningAnim());
        }
    }
}
