using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMoveScript : MonoBehaviour
{
    bool lockedPos = false;

    Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            Vector3 direct = transform.position - collision.gameObject.transform.position;
            gameObject.GetComponent<Rigidbody2D>().AddForce(-direct);
        }
        else if(collision.gameObject.tag == "Player2")
        {
            lockedPos = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            lockedPos = false;
        }
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        if (lockedPos)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
