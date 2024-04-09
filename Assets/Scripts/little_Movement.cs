using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class little_Movement : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float distanceToGround = 0.25f;
    public float gravity = 0.1f;
    public float jumpForce = 100.0f;

    float p2Velocity;

    LayerMask groundMask;

    bool isGrounded()
    {
        bool returnbool = false;

        //RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundMask);
        RaycastHit2D rayHitleft = Physics2D.Raycast(transform.position + new Vector3(0.2f, 0, 0), Vector2.down, distanceToGround, groundMask);
        RaycastHit2D rayHitright = Physics2D.Raycast(transform.position + new Vector3(-0.2f, 0, 0), Vector2.down, distanceToGround, groundMask);

        if ((rayHitleft.collider != null) || (rayHitright.collider != null))
            returnbool = true;
        return returnbool;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        groundMask = LayerMask.GetMask("Ground");
    }

    void FixedUpdate()
    {
        if(isGrounded() && Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0, jumpForce*10));
        }
        else if (!isGrounded())
        {
            rb.AddForce(new Vector2(0, -gravity));
        }

    }

    void Update()
    {
        p2Velocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            p2Velocity = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            p2Velocity = moveSpeed;
        }

        rb.velocity = new Vector2(p2Velocity, rb.velocity.y);
    }
}
