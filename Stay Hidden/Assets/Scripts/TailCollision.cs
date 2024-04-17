using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailCollision : MonoBehaviour
{
    public ParticleSystem Particles;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Destroyable")
        {
            Particles.Play();
        }
    }
}
