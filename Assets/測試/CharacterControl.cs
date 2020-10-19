using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bCol;
    public Transform bow; // 弓轉向用

    [Header("移動")]
    public float speed = 5f;

    [Header("跳躍")]
    public float jumpForce = 4.5f;
    public float hangingJumpForce = 5f; // 懸掛後往前跳的力

    [Header("狀態")]
    public bool isGrounded;
    public bool isJump;
    public bool isHeadBlocked;
    public bool isHanging;

    [Header("環境")]
    public LayerMask groundLaters;
    public float footOffset = 0.2f;
    public float groundDistance = 0.55f; // 地板射線的長度
    public float headClearance = 0.3f;  // 頭頂射線的長度
    public float eyeHeight = 0.25f; // 眼睛射線的高度
    public float playHeight;
    public float grabDistance = 0.8f; // 判定懸掛的距離
    public float reachOffset = 0.9f; // 判定面對牆壁的距離


    float xVelocity;


    void Start()
    {
        bCol = GetComponent<BoxCollider2D>();//目前取名為AN
        rb = GetComponent<Rigidbody2D>();//目前取名為Rigibody

        playHeight = bCol.size.y-1.5f;
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
        GroundMovement();
        Jump();

        print(bCol.size.y);
    }

    void Jump()
    {
        if(isHanging)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = new Vector2(rb.velocity.x, hangingJumpForce);
                isHanging = false;
            }

            // 脫離懸掛狀態
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                isHanging = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isHanging) 
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
        if (isHanging) // 懸掛狀態
            return;

        

        xVelocity = Input.GetAxis("Horizontal"); // -1f 1f

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

        FlipDirction();
    }

    void FlipDirction()
    {
        if (xVelocity < 0)
        {
            transform.localScale = new Vector2(-0.5f, 0.5f);
            bow.localScale = new Vector2(-2, 2);
        }
        if (xVelocity > 0)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
            bow.localScale = new Vector2(2, 2);
        }
    }

    void PhysicsCheck()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundDistance, groundLaters);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundDistance, groundLaters);

        if (leftCheck || rightCheck) 
            isGrounded = true;
        else
            isGrounded = false;

        RaycastHit2D headCheck = Raycast(new Vector2(0f, bCol.size.y-1.5f), Vector2.up, headClearance, groundLaters);

        if (headCheck)
            isHeadBlocked = true;
        else
            isHeadBlocked = false;

        float direction = transform.localScale.x;
        Vector2 grabDir = new Vector2(direction, 0f);

        RaycastHit2D blockCheck = Raycast(new Vector2(footOffset * direction, playHeight), grabDir, grabDistance, groundLaters);
        RaycastHit2D wallCheck = Raycast(new Vector2(footOffset * direction, eyeHeight), grabDir, grabDistance, groundLaters);
        RaycastHit2D ledgeCheck = Raycast(new Vector2(reachOffset * direction, playHeight), Vector2.down, grabDistance - 0.5f, groundLaters);
        
        if (!isGrounded && rb.velocity.y < 0f && ledgeCheck && wallCheck && !blockCheck) 
        {
            Vector3 pos = transform.position;

            pos.x += (wallCheck.distance-0.15f) * direction;

            pos.y -= ledgeCheck.distance;

            transform.position=pos;

            rb.bodyType = RigidbodyType2D.Static;
            isHanging = true;
        }
    }

    // 位移 , 射線方向 , 長度 , 類別
    RaycastHit2D Raycast(Vector2 offset,Vector2 ratDiraction,float length,LayerMask layer)
    {
        // 目前位置
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, ratDiraction, length, layer);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, ratDiraction * length, color);

        return hit;
    }
}
