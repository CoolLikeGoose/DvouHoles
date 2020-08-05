using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickImage : MonoBehaviour, IPointerClickHandler
{
    private Outline selfOutline;
    private Color selfColor;

    private void Start()
    {
        selfOutline = GetComponent<Outline>();
        selfColor = GetComponent<Image>().color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PaintController.Instance.currentOutline != null) { PaintController.Instance.currentOutline.enabled = false; }

        PaintController.Instance.currentColor = selfColor;
        PaintController.Instance.currentOutline = selfOutline;
        selfOutline.enabled = true;
    }
}
