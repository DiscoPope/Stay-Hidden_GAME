using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool hasItem = false;
    public ParticleSystem Particles;
    public Deposite depo;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && depo.deposited == false)
        {
            Destroy(gameObject);
            Particles.Play();
            Debug.Log("Item Taken");
            hasItem = true;
        }
        else
        {
            hasItem = false;
        }
    }
}
