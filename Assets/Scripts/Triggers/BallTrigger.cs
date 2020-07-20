using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 9;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = 0;
    }
}
