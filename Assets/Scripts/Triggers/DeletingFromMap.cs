using UnityEngine;

public class DeletingFromMap : MonoBehaviour
{
    public ParticleSystem[] particles;

    private void OnTriggerExit(Collider other)
    {
        //Particle System
        Color cubeColor = other.gameObject.GetComponent<Renderer>().material.color;
        foreach (ParticleSystem ps in particles)
        {
            if (!ps.gameObject.activeSelf)
            {
                ParticleSystemRenderer psR = ps.GetComponent<ParticleSystemRenderer>();
                psR.material.color = cubeColor;
                ps.gameObject.SetActive(true);
                break;
            }
        }

        //Check if right cube drop in this hole
        if (other.CompareTag(gameObject.tag)) { GameManager.OnRightCubeAbsorb(); }
        else { GameManager.OnWrongCubeAbsorb(); }

        Destroy(other.gameObject);
    }
}
