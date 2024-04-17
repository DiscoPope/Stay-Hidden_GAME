using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposite : MonoBehaviour
{
    public ParticleSystem Particles;
    public GameObject item;
    public Transform depositePosition;
    public Item iTM;
    public bool deposited = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && iTM.hasItem == true)
        {
            Particles.Play();
            Instantiate(item, depositePosition.position, depositePosition.rotation);
            deposited = true;
        }
    }
}
