using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMechanic : MonoBehaviour
{
    public GameObject tail;
    public Player_Movement pM;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            tail.SetActive(true);
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }
        else
        {
            tail.SetActive(false);
        }
        Flip();
    }

    void Flip()
    {
        if(pM.isFacingRight == false)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
