using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBarryP1 : MonoBehaviour
{
    
    public float p1Speed = 5;
    public float jumpForce = 50;

    public static int IgnoreRaycastLayer = 6;

    float p1Velocity;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        LayerMask layerMask = LayerMask.GetMask("Ground");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, layerMask);
        Debug.DrawRay(transform.position, -Vector3.up, Color.white);

        if (hit.collider != null)
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        p1Velocity = 0;

        if (Input.GetKey(KeyCode.A))
        {
            p1Velocity = -p1Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            p1Velocity = p1Speed;
        }

        rb.velocity = new Vector2(p1Velocity, rb.velocity.y);
    }

    
}
