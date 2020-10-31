using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bCol;

    [Header("移動")]
    public float speed = 5f;

    [Header("跳躍")]
    public float jumpForce = 4.5f;
    public float hangingJumpForce = 5f; // 懸掛後往前跳的力


    float xVelocity;


    void Start()
    {
        bCol = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        GroundMovement();
        Jump();

        print(bCol.size.y);
    }

    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            // Y軸速度限制
            if (rb.velocity.y > 5)
            {
                rb.velocity = new Vector2(0f, 5f);
            }
        }
    }

    void GroundMovement()
    {

        xVelocity = Input.GetAxis("Horizontal"); // -1f 1f

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

        FlipDirction();
    }

    void FlipDirction()
    {
        if (xVelocity < 0)
        {
            transform.localScale = new Vector2(-1, 0.5f);
        }
        if (xVelocity > 0)
        {
            transform.localScale = new Vector2(1, 0.5f);
        }
    }
}
