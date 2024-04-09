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

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround, groundMask);

        if (rayHit.collider != null)
            returnbool = true;

        Debug.Log("grounded: " + returnbool);
        return returnbool;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        groundMask = LayerMask.NameToLayer("ground");
    }

    void FixedUpdate()
    {
        if(isGrounded() && Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("jump");
            rb.AddForce(new Vector2(0, jumpForce*10));
        }
        else if (!isGrounded())
        {
            rb.AddForce(new Vector2(0, -gravity));
        }

        //move left
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left");
            gameObject.transform.position -= new Vector3(moveSpeed, 0, 0);
        }

        //move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right");
            gameObject.transform.position -= new Vector3(-moveSpeed, 0, 0);
        }
    }
}
