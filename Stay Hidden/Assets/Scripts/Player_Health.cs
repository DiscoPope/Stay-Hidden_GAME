using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{

    public float health;
    public float maxHealth = 10f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
