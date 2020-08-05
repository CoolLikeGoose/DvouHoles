using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragPanel : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab = null;

    [SerializeField] private Transform scrollViewContent = null;

    private void Start()
    {
        List<Color> colors = PaintController.Instance.colors;

        for (int i = 0; i != colors.Count; ++i)
        {
            GameObject dragObject = Instantiate(cubePrefab, scrollViewContent);
            Image dragObjectImage = dragObject.GetComponent<Image>();
            dragObjectImage.color = colors[i];
            dragObjectImage.sprite = PaintController.Instance.numbers[i];
        }

        //Initialize start color
        Transform firstChild = scrollViewContent.GetChild(0);

        Color selfColor = firstChild.GetComponent<Image>().color;
        Outline selfOutline = firstChild.GetComponentInChildren<Outline>();
        selfOutline.enabled = true;

        PaintController.Instance.currentColor = selfColor;
        PaintController.Instance.currentOutline = selfOutline;
    }
}
