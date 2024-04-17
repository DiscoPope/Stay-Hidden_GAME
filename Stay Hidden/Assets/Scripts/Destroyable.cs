using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public ParticleSystem Particles;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tail")
        {
            Destroy(gameObject);
            Particles.Play();
            Debug.Log("destroyed");
        }
    }
}
