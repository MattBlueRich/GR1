using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class little_Movement : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 1f;
    public float distanceToGround = 0.25f;
    public float gravity = 0.1f;
    public float jumpForce = 100.0f;

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

        groundMask = LayerMask.NameToLayer("Ground");
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

        //move left
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position -= new Vector3(moveSpeed, 0, 0);
        }

        //move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position -= new Vector3(-moveSpeed, 0, 0);
        }
    }
}
