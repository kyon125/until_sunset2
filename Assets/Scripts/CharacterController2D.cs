using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{    
    public float speed, jumpspeed;
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

    bool CrouchDown = false;
    bool Climb = false;
    bool shot = false;
    private float climbspeed=2.5f;
    public float speed_Y = 2;
    public GameObject sh , pack;

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
            Climb = false;

            // isground
            isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 1.0f), new Vector2(transform.position.x + 0.5f, transform.position.y - -1.1f), groundLaters);

            // ishide
            isHided = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.3f, transform.position.y), new Vector2(transform.position.x + 0.3f, transform.position.y), hideLayers);     
            
            walk();
            run();
            hide();
            jump();
            unhitch();
            crouchDown();
            climb();
            callpack();
            shotting();
            test_cheat();
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            playerAni.SetBool("Push", true);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            playerAni.SetBool("Push", false);
            playerAni.SetBool("PushWalk", false);
        }
    }
    void walk()
    {
        bool Walk = false;
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

        if (Walk)
        {
            if (playerAni.GetInteger("Walk") == 0)
                playerAni.SetInteger("Walk", 1);
        }
        else
        {
            if (playerAni.GetInteger("Walk") == 1)
                playerAni.SetInteger("Walk", 0);
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
            speed_X = 12;
            //Run = true;
            playerAni.SetInteger("Run", 1);
        }
        else
        {
            speed_X = 8;
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
        else
        {
            playerAni.SetBool("JumpUp", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow) && isGrounded == true)
        {
            playerAni.SetBool("Jump", true);
        }
        else
        {
            playerAni.SetBool("Jump", false);
        }

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
        }
        else if (Input.GetKeyUp(KeyCode.A) && isGrounded == true)
        {
            Rigidbody.AddForce(new Vector2(speed_X - 1.5f, 0), ForceMode2D.Impulse);
        }
    }

    void climb()
    {
        // isclimb
        isClimb = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.7f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.7f, transform.position.y - -0.5f), climbLaters);
        if ((Input.GetKeyDown(KeyCode.S) && isClimb == true))
        {
            Rigidbody.Sleep();
            Rigidbody.WakeUp();
        }
        if (Input.GetKey(KeyCode.W) && isClimb == true) 
        {
            Climb = true;
            Rigidbody.AddForce(new Vector2(0, 0.25f * climbspeed), ForceMode2D.Impulse);
            Rigidbody.gravityScale = 0;
            

            // Y軸速度限制
            if (Rigidbody.velocity.y > speed_Y)
            {
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, speed_Y);
            }
        }
       
       // print(Rigidbody.velocity.y);

        if (Climb) 
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
    void callpack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gameStatus.status == GameStatus.Status.onPlaying)
        {
            gameStatus.status = GameStatus.Status.onBaging;
            this.gameObject.GetComponent<PlayerBag>().creatitem();

            Tween t = pack.transform.DOScaleX(1, 0.2f).SetEase(Ease.OutBack);
            Tween t2 = pack.transform.DOScaleY(1, 0.2f).SetEase(Ease.OutBack);
        }
    }

    void test_cheat()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            SceneManager.LoadScene("Viliage");
        }
    }
}


    
