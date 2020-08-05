using System;
using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [NonSerialized] public Color selfColor;
    public SpriteRenderer selfImage;

    private bool canColor = true;

    private void Start()
    {
        selfImage.sprite = PaintController.Instance.numbers[PaintController.Instance.colors.IndexOf(selfColor)];
    }

    private void OnMouseDown()
    {
        StartCoroutine(ColoringTimer());
    }
    private void OnMouseUp()
    {
        if (!canColor) 
        { 
            return;
        }
        if (PaintController.Instance.currentColor == selfColor && selfImage.enabled)
        {
            selfImage.enabled = false;
            PaintController.Instance.cubeCount--;
            SoundManager.Instance?.OnPaintCube();
            if (PaintController.Instance.cubeCount == 0) { PaintController.OnPaintingEnd?.Invoke(); }
        }
        GetComponent<Renderer>().material.color = selfColor;
    }

    private IEnumerator ColoringTimer()
    {
        canColor = true;

        yield return new WaitForSeconds(0.2f);

        canColor = false;
    }
}
