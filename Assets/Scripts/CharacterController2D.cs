using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    
    public static CharacterController2D chara;
    public float speed, jumpspeed ,jumpoutspeed;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    public float speed_X;
    public float slowdown;
    public playerAction playeraction;

    private BoxCollider2D bCol;
    public GameObject bow; 

    // 收集能量
    float energyMax = 100;
    float energyTotal;

    [Header("環境")]
    public LayerMask groundLaters;
    public float footOffset = 0.2f;
    public float footOffset_high;
    public float groundDistance = 0.55f; // 地板射線的長度
    public float headClearance = 0.3f;  // 頭頂射線的長度
    public float eyeHeight = 0.25f; // 眼睛射線的高度
    public float playHeight;
    public float grabDistance = 0.8f; // 判定懸掛的距離
    public float reachOffset = 0.9f; // 判定面對牆壁的距離
    public float falldown_value;

    [Header("狀態")]
    public bool isGrounded;
    public bool isJump;
    public bool isHeadBlocked;
    public bool isHanging;
    public bool isWall;
    bool isRope;

    public GameObject hangObj;
    public GameObject anObj;

    [Header("跳躍")]
    public float jumpForce = 4.5f;
    public float hangingJumpForce = 5f; // 懸掛後往前跳的力

    public bool isHided;
    public LayerMask hideLayers;

    public bool isClimb;
    public LayerMask climbLaters;

    public Animator playerAni;
    public Transform playerS;

    public bool isNPC;
    bool isItem;

    float xVelocity;
    Vector2 beforepos;

    bool CrouchDown = false;
    bool Climb = false;
    public bool Walk;
    public float climbspeed=2.5f;
    public float speed_Y = 2;

    public Collider2D An;
    [Header("任務")]
    public GameObject Npc;    
    public List<Quest_set> questlisting;

    private PlayerBag bg;
    public GameObject hit_item;
    public bool isitem;
    [Header("道具")]
    public interAction actobj;

    /*----------------------------------------------------------------------------------------*/
    private GameStatus gameStatus;
    

    private void Awake()
    {
        chara = this;
    }
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        playerAni =GameObject.Find("An(an)").GetComponent<Animator>();
        bg = GameObject.Find("GameController").GetComponent<PlayerBag>();

        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
    }

    void Update()
    {
        if (gameStatus.status == GameStatus.Status.onPlaying)
        {                    
            CrouchDown = false;

            // isground
            //isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x-0.5f, transform.position.y - 0.1f), new Vector2(transform.position.x+ 0.5f , transform.position.y + 0.85f), groundLaters);
            // ishide
            isHided = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.3f, transform.position.y), new Vector2(transform.position.x + 0.3f, transform.position.y), hideLayers);     

            jump();

            unhitch();
            walk();
            run();
            hide();
            obj_Interaction();

            crouchDown();
            climb();
            isfalldown();
            dialoging();

            print("energyTotal: " + energyTotal); // 能量

            //作弊鍵
            test_cheat();
        }
        beforepos = this.transform.position;
        if (gameStatus.status == GameStatus.Status.onPloting)
        {
            playerAni.SetBool("isplot", true);
        }
        else
        {
            playerAni.SetBool("isplot", false);
        }
    }

    private void FixedUpdate()
    {
        PhysicsCheck();
        //GroundMovement();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            playerAni.SetBool("Push", true);
        }

        // 收集能量
        if (collision.gameObject.tag == "energy")
        {
            if (energyTotal < energyMax)
            {
                energyTotal = energyTotal + 12.5f;
            }
            else if (energyTotal >= energyMax)
            {
                energyTotal = energyMax;
            }
        }

        // 東西是否在互動範圍內判定
        else if (collision.tag == "Npc")
        {
            isNPC = true;
            Npc = collision.gameObject;
        }
        if (collision.transform.tag == "stayflat" && isClimb == true)
        {
            print("i come");
            Physics2D.IgnoreCollision(An, collision.transform.GetComponent<Collider2D>(), true);
        }
        //使否接觸到道具
        if (collision.tag == "item")
        {
            isitem = true;
            hit_item = collision.gameObject;
            bg.hit_item = hit_item;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //推東西判定
        if (collision.gameObject.tag == "box")
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                playerAni.SetBool("Push", false);
                playerAni.SetBool("PushWalk", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAni.SetBool("Push", true);
                playerAni.SetBool("PushWalk", false);
            }
        }

        //攀爬繩索
        if (collision.gameObject.tag == "rope")
        {
            if (Input.GetKey(KeyCode.W) && isClimb ==false )
            {                
                Rigidbody.velocity = Vector3.zero;
                isClimb = true;
                this.gameObject.transform.position =new Vector3(collision.gameObject.transform.position.x, this.gameObject.transform.position.y);
                climb();
            }
            else if (Input.GetKey(KeyCode.S) && isClimb == false)
            {                
                Rigidbody.velocity = Vector3.zero;
                isClimb = true;
                this.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, this.gameObject.transform.position.y);
                climb();
            }
        }

        if (collision.transform.tag == "stayflat" && isClimb == true)
        {
            print("i come");
            Physics2D.IgnoreCollision(An, collision.transform.GetComponent<Collider2D>(), true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            playerAni.SetBool("Push", false);
            playerAni.SetBool("PushWalk", false);
        }

        else if (collision.tag == "Npc")
        {
            isNPC = false;
            Npc = null;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            isClimb = false;
        }
        if (collision.transform.tag == "stayflat" && isClimb == false)
        {
            print("i go");
            Physics2D.IgnoreCollision(An, collision.transform.GetComponent<Collider2D>(), false);
        }

        if (collision.tag == "item")
        {
            isitem = false;
            bg.hit_item = null;
        }
    }
    void obj_Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (playeraction) 
            {
                case (playerAction.isNormal):
                    {
                        break;
                    }
                case (playerAction.isActionobj):
                    {
                        actobj.interaction();
                        break;
                    }
                case (playerAction.isItemobj):
                    {
                        for (int i = 0; i < actobj.items.Count; i++)
                        {
                            PlayerBag.playerbag.getitem(actobj.items[i].id, actobj.items[i].count);                            
                        }
                        actobj.interaction();
                        break;
                    }
            }
        }
    }
    void walk()
    {
        if (isHanging) // 懸掛狀態
        {
            return;
        }

            if (Input.GetKey(KeyCode.D) && isGrounded == true && isClimb == false)
        {
            Walk = true;

            //playerS.localScale = new Vector2(0.1f, 0.1f);

            this.gameObject.transform.localScale = new Vector3(1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(20 * speed, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.A) && isGrounded == true && isClimb == false)
        {
            Walk = true;

            //playerS.localScale = new Vector2(-0.1f, 0.1f);

            this.gameObject.transform.localScale = new Vector3(-1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(-20 * speed, 0), ForceMode2D.Impulse);
        }

        //空中可以稍微轉向
        if (Input.GetKey(KeyCode.D) && isGrounded == false && isClimb == false && isWall == false)
        {
            this.gameObject.transform.localScale = new Vector3(1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(15 * speed, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.A) && isGrounded == false && isClimb == false && isWall == false)
        {
            this.gameObject.transform.localScale = new Vector3(-1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(-15 * speed, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            Walk = false;
        }


        if (Walk == true)
        { 
            playerAni.SetBool("Walk", true);
        }
        else
        {
            playerAni.SetBool("Walk", false);
        }
        // X軸速度限制
        if (Rigidbody.velocity.x > speed_X)
        {
            Rigidbody.velocity = new Vector2(speed_X, Rigidbody.velocity.y);
        }
        else if (Rigidbody.velocity.x < -speed_X)
        {
            Rigidbody.velocity = new Vector2(-speed_X, Rigidbody.velocity.y);
        }
    }
    void run()
    {
        //bool Run = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //speed_X = 16;
            //Run = true;
            playerAni.SetInteger("Run", 1);
        }
        else
        {
            //speed_X = 20;
            playerAni.SetInteger("Run", 0);
        }
    }
    void hide()
    {
        // Hide
        if (Input.GetKeyDown(KeyCode.DownArrow) && isHided == true)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isHided == true)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isClimb == false)
        {
            playerAni.SetBool("JumpUp", true);
            Rigidbody.AddForce(new Vector2(0, 10 * jumpspeed), ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isClimb == true)
        {
            isClimb = false;
            playerAni.SetBool("JumpUp", true);
            Rigidbody.AddForce(new Vector2(0, 10 * jumpspeed), ForceMode2D.Impulse);
        }
        if (isHanging)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anObj.GetComponent<SpriteRenderer>().enabled = true;
                hangObj.GetComponent<SpriteRenderer>().enabled = false;

                Rigidbody.bodyType = RigidbodyType2D.Dynamic;
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, hangingJumpForce);
                isHanging = false;
            }

            // 脫離懸掛狀態
            if (Input.GetKeyDown(KeyCode.S))
            {
                anObj.GetComponent<SpriteRenderer>().enabled = true;
                hangObj.GetComponent<SpriteRenderer>().enabled = false;

                Rigidbody.bodyType = RigidbodyType2D.Dynamic;
                isHanging = false;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isHanging)
        //{
        //    Rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        //    // Y軸速度限制
        //    if (Rigidbody.velocity.y > 5)
        //    {
        //        Rigidbody.velocity = new Vector2(0f, 5f);
        //    }
        //}
    }
    void PhysicsCheck()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset+0.8f, footOffset_high), Vector2.down, groundDistance, groundLaters);
        RaycastHit2D centerCheck = Raycast(new Vector2(0, footOffset_high), Vector2.down, groundDistance, groundLaters);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset-0.8f, footOffset_high), Vector2.down, groundDistance, groundLaters);

        if (leftCheck || rightCheck || centerCheck)
            isGrounded = true;
        else
            isGrounded = false;

        //RaycastHit2D headCheck = Raycast(new Vector2(0f, bCol.size.y - 1.5f), Vector2.up, headClearance, groundLaters);

        //if (headCheck)
        //    isHeadBlocked = true;
        //else
        //    isHeadBlocked = false;

        float direction = transform.localScale.x;
        Vector2 grabDir = new Vector2(direction, 0f);

        RaycastHit2D blockCheck = Raycast(new Vector2(footOffset * direction, playHeight), grabDir, grabDistance, groundLaters);
        RaycastHit2D wallCheck = Raycast(new Vector2(footOffset * direction, eyeHeight), grabDir, grabDistance, groundLaters);
        RaycastHit2D ledgeCheck = Raycast(new Vector2(reachOffset * direction, playHeight), Vector2.down, grabDistance - 0.5f, groundLaters);

        // 防卡牆射線
        RaycastHit2D wallCheckHead = Raycast(new Vector2((footOffset - 0.33f) * direction, playHeight), grabDir, grabDistance, groundLaters);
        RaycastHit2D wallCheckfoot = Raycast(new Vector2((footOffset - 0.33f) * direction, eyeHeight - 3.2f), grabDir, grabDistance, groundLaters);
        RaycastHit2D wallCheckEye = Raycast(new Vector2((footOffset - 0.33f) * direction, eyeHeight), grabDir, grabDistance, groundLaters);


        if (Input.GetKey(KeyCode.W))
        {
            if (!isGrounded && Rigidbody.velocity.y < 0f && ledgeCheck && wallCheck && !blockCheck)
            {
                anObj.GetComponent<SpriteRenderer>().enabled = false;
                hangObj.GetComponent<SpriteRenderer>().enabled = true;

                Vector3 pos = transform.position;

                pos.x += (wallCheck.distance - 0.15f) * direction;

                pos.y -= ledgeCheck.distance;

                transform.position = pos;

                Rigidbody.bodyType = RigidbodyType2D.Static;
                isHanging = true;
            }
        }

        // 防卡牆
        if ((wallCheckHead || wallCheckfoot || wallCheckEye) && !isGrounded)
        {
            isWall = true;
        }
        else if (wallCheckHead || wallCheckfoot || wallCheckEye && isGrounded)
        {
            isWall = false;
        }
        else if (!wallCheckHead && !wallCheckfoot && !wallCheckEye)
        {
            isWall = false;
        }
    }

    // 位移 , 射線方向 , 長度 , 類別
    RaycastHit2D Raycast(Vector2 offset, Vector2 ratDiraction, float length, LayerMask layer)
    {
        // 目前位置
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, ratDiraction, length, layer);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, ratDiraction * length, color);

        return hit;
    }
    //void GroundMovement()
    //{
    //    if (isHanging) // 懸掛狀態
    //        return;



    //    xVelocity = Input.GetAxis("Horizontal"); // -1f 1f

    //    Rigidbody.velocity = new Vector2(xVelocity * speed, Rigidbody.velocity.y);

    //    FlipDirction();
    //}

    //void FlipDirction()
    //{
    //    if (xVelocity < 0)
    //    {
    //        transform.localScale = new Vector2(-1.0f, 1.0f);
    //        //bow.localScale = new Vector2(-2, 2);
    //    }
    //    if (xVelocity > 0)
    //    {
    //        transform.localScale = new Vector2(1.0f, 1.0f);
    //        //bow.localScale = new Vector2(2, 2);
    //    }
    //}

    void crouchDown()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            CrouchDown = true;
        }

        if (CrouchDown)
        {
            if (playerAni.GetInteger(" CrouchDown") == 0)
                playerAni.SetInteger(" CrouchDown", 1);
        }
        else
        {
            if (playerAni.GetInteger(" CrouchDown") == 1)
                playerAni.SetInteger(" CrouchDown", 0);
        }
    }
    void unhitch()
    {
        if (Input.GetKeyUp(KeyCode.D) && isGrounded == true)
        {
            Rigidbody.velocity = new Vector2(0 , Rigidbody.velocity.y);
            Walk = false;
        }
        else if (Input.GetKeyUp(KeyCode.A) && isGrounded == true)
        {
            Rigidbody.velocity = new Vector2(0, Rigidbody.velocity.y);
            Walk = false;
        }
    }

    void climb()
    {
        // isclimb
        //isClimb = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.7f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.7f, transform.position.y - -0.5f), climbLaters);
        if ((Input.GetKey(KeyCode.S) && isClimb == true))
        {
            Rigidbody.velocity = new Vector2(0, -climbspeed);
            Rigidbody.gravityScale = 0;
        }
        else if (Input.GetKey(KeyCode.W) && isClimb == true) 
        {
            Rigidbody.velocity = new Vector2(0,climbspeed);
            Rigidbody.gravityScale = 0;            
        }
        if (Input.GetKeyUp(KeyCode.W) && isClimb == true)
        {
            Rigidbody.velocity = new Vector2(0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.S) && isClimb == true)
        {
            Rigidbody.velocity = new Vector2(0, 0);
        }

        // print(Rigidbody.velocity.y);

        if (isClimb) 
        {
            if (playerAni.GetInteger("Climb") == 0)
                playerAni.SetInteger("Climb", 1);
        }
        else
        {
            if (playerAni.GetInteger("Climb") == 1)
                playerAni.SetInteger("Climb", 0);
            Rigidbody.gravityScale = 10;
        }
    }
    void call_quest()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameStatus.status = GameStatus.Status.onQuestlist;

        }
    }   

    void dialoging()
    {
        if (Input.GetKeyDown(KeyCode.F) && isNPC == true)
        {
            Npc.GetComponent<Npc>().speak();
        }
    }

    void isfalldown()
    {
        if (isGrounded == false && this.transform.position.y - beforepos.y < 0)
        {
            playerAni.SetBool("JumpUp", false);
            if (this.transform.position.y - beforepos.y <= falldown_value)
            {
                playerAni.SetBool("Falldown", true);
            }            
        }
        else
        {
            playerAni.SetBool("Falldown", false);
        }
    }
    void test_cheat()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene("Well");
        }
    }
}
public enum playerAction
{
    isNormal,
    isActionobj,
    isItemobj
}


    
