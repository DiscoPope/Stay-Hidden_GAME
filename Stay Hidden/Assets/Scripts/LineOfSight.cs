using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public bool isChasing = false;
    public bool lost = false;
    void OnTriggerEnter2D(Collider2D playerDetect)
    {
        if (playerDetect.gameObject.tag == "Player")
        {
            isChasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D playerExit)
    {
        if (playerExit.gameObject.tag == "Player")
        {
            isChasing = false;
            lost = true;
        }
    }

}
