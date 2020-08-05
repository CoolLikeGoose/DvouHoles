using System;
using UnityEngine;

public class SmallThingsRandomizer : MonoBehaviour
{
    [Range(0, 1f)]
    [SerializeField] private float savePercent = 0.5f;

    private void Start()
    {
        //int childsToSave = Random.Range(1, transform.childCount);
        int childsToSave = Convert.ToInt32(transform.childCount * savePercent);

        while (transform.childCount > childsToSave)
        {
            Transform childToDestroy = transform.GetChild(UnityEngine.Random.Range(0, transform.childCount));
            DestroyImmediate(childToDestroy.gameObject);
        }
    }
}
