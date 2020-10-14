using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{    
    public float speed, jumpspeed ,jumpoutspeed;
    private Rigidbody2D Rigidbody;
    private Collider2D Collider;
    public float speed_X;

    public bool isGrounded;
    public LayerMask groundLaters;

    public bool isHided;
    public LayerMask hideLayers;

    public bool isClimb;
    public LayerMask climbLaters;

    public Animator playerAni;
    public Transform playerS;

    public bool isNPC;
    bool isItem;

    Vector2 beforepos;

    bool CrouchDown = false;
    bool Climb = false;
    bool shot = false;
    public bool Walk;
    public float climbspeed=2.5f;
    public float speed_Y = 2;
    public GameObject sh  , Npc;
    public List<Quest_set> questlisting;

    /*----------------------------------------------------------------------------------------*/
    private GameStatus gameStatus;
    void Start()
    {
        Rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        playerAni =GameObject.Find("An(an)").GetComponent<Animator>();

        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
    }

    void Update()
    {
        if (gameStatus.status == GameStatus.Status.onPlaying)
        {            
            CrouchDown = false;

            // isground
            isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 1.0f), new Vector2(transform.position.x + 0.5f, transform.position.y - -1.1f), groundLaters);

            // ishide
            isHided = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.3f, transform.position.y), new Vector2(transform.position.x + 0.3f, transform.position.y), hideLayers);     

            jump();

            unhitch();
            walk();
            run();
            hide();            
            
            crouchDown();
            climb();
            isfalldown();

            shotting();
            dialoging();
            

            //作弊鍵
            test_cheat();
        }
        beforepos = this.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            playerAni.SetBool("Push", true);
        }

        // 東西是否在互動範圍內判定
        else if (collision.tag == "Npc")
        {
            isNPC = true;
            Npc = collision.gameObject;
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
            if (Input.GetKey(KeyCode.W) && isClimb ==false)
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
    }
    void walk()
    {        
        if (Input.GetKey(KeyCode.D) && isGrounded == true)
        {
            Walk = true;

            //playerS.localScale = new Vector2(0.1f, 0.1f);

            this.gameObject.transform.localScale = new Vector3(1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(20 * speed, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.A) && isGrounded == true)
        {
            Walk = true;

            //playerS.localScale = new Vector2(-0.1f, 0.1f);

            this.gameObject.transform.localScale = new Vector3(-1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(-20 * speed, 0), ForceMode2D.Impulse);
        }

        //空中可以稍微轉向
        if (Input.GetKey(KeyCode.D) && isGrounded == false && isClimb == false)
        {
            this.gameObject.transform.localScale = new Vector3(1f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            Rigidbody.AddForce(new Vector2(15 * speed, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.A) && isGrounded == false && isClimb == false)
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
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

        //if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow) && isGrounded == true)
        //{
        //    playerAni.SetBool("Jump", true);
        //}
        //else
        //{
        //    playerAni.SetBool("Jump", false);
        //}

    }

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
            Rigidbody.AddForce(new Vector2(-(speed_X - 1.5f), 0), ForceMode2D.Impulse);
            Walk = false;
        }
        else if (Input.GetKeyUp(KeyCode.A) && isGrounded == true)
        {
            Rigidbody.AddForce(new Vector2(speed_X - 1.5f, 0), ForceMode2D.Impulse);
            Walk = false;
        }
    }

    void climb()
    {
        // isclimb
        //isClimb = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.7f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.7f, transform.position.y - -0.5f), climbLaters);
        if ((Input.GetKeyDown(KeyCode.S) && isClimb == true))
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
    void shotting()
    {
        if (Input.GetMouseButtonDown(1) && shot == false)
        {
            sh.SetActive(true);
            shot = true;
        }
        else if (Input.GetMouseButtonDown(1) && shot == true)
        {
            sh.SetActive(false);
            shot = false;
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
            playerAni.SetBool("Falldown", true);
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


    
