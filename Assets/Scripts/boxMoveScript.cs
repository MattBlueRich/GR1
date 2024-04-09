using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMoveScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            Vector3 direct = transform.position - collision.gameObject.transform.position;
            gameObject.GetComponent<Rigidbody2D>().AddForce(-direct);
        }
    }
}
