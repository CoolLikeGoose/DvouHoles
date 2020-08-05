using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    [SerializeField] private float speed = 0;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(CoinRotator());
    }

    private IEnumerator CoinRotator()
    {
        while (true)
        {
            if (!rb.isKinematic) { break; }

            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * speed));

            yield return null;
        }
    }
}
