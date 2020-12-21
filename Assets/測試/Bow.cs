using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public static Bow bowset;
    bool shot = false;
    bool canRotate;
    Vector3 mousePosition;

    public Camera camera;
    public GameObject shotPos;

    public GameObject arrow;
    public GameObject arrowBridge;

    public float launchForce;
    public Transform shotPoint;

    public GameObject bow;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    public GameObject player;

    // hide
    public GameObject an;
    public GameObject hair;
    public GameObject body;
    public GameObject bow_h;
    public GameObject leg;

    // throwhook
    public GameObject hook;
    public bool ropeActive;
    GameObject curHook;

    public LineRenderer lineRenderer;

    public  bowstatus status;

    private void Awake()
    {
        bowset = this;
    }
    void Start()
    {

        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity , an.transform);
        }

        StartCoroutine("hidePoints");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameStatus.gameStatus.status = GameStatus.Status.onBowing;
            status = bowstatus.normal;
            StartCoroutine("bowUse");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {            
            GameStatus.gameStatus.status = GameStatus.Status.onRope;
        }

        if (GameStatus.gameStatus.status == GameStatus.Status.onRope)
        {
            for (int i = 0; i < numberOfPoints; i++)
                points[i].GetComponent<SpriteRenderer>().enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                shotHook();
            }
            else if (ropeActive == true && Input.GetKeyDown(KeyCode.Space))
            {
                GameStatus.gameStatus.status = GameStatus.Status.onPlaying;

                Destroy(curHook);
                Rigidbody2D playerVel = player.GetComponent<Rigidbody2D>();

                playerVel.velocity = new Vector2(playerVel.velocity.x, 50);

                ropeActive = false;
            }
            else if (ropeActive == true && Input.GetKeyDown(KeyCode.S))
            {
                GameStatus.gameStatus.status = GameStatus.Status.onPlaying;

                Destroy(curHook);

                ropeActive = false;
            }
        }
        
        if (GameStatus.gameStatus.status == GameStatus.Status.onBowing)
        {
            faceMouse();
            rotateLim();

           
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (status == bowstatus.normal)
                {
                    status = bowstatus.bridge;
                }
                else if (status == bowstatus.bridge)
                {
                    Destroy(GameObject.Find("Collider"));
                    lineRenderer.SetPosition(0, new Vector2(0, 0));
                    lineRenderer.SetPosition(1, new Vector2(0, 0));

                    status = bowstatus.normal;
                }                  
            }

            if ((player.transform.localScale.x > 0 && direction.x < 2) || (player.transform.localScale.x < 0 && direction.x > -2))
            {
                canRotate = false;

                for (int i = 0; i < numberOfPoints; i++)
                    points[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                canRotate = true;
            }

            if (canRotate == true && shot == true)
            {
                shotPos.transform.position = mousePosition;

                if (status == bowstatus.normal)
                    Shoot(arrow);
                else if (status == bowstatus.bridge)
                    Shoot(arrowBridge);

                // 畫預判線
                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].GetComponent<SpriteRenderer>().enabled = true;

                    points[i].transform.position = PonitPosition(i * spaceBetweenPoints);
                }
            }
        }       
        //print(direction);
    }

    void faceMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.right = direction;
    }

    private void Shoot(GameObject arrow)
    {
        if (Input.GetMouseButtonDown(0) && shot)
        {

            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

        }
    }

    private void rotateLim()
    {
        // bow校正
        if (player.transform.localScale.x > 0)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        // bow校正
        else if (player.transform.localScale.x < 0)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void shotHook()
    {
        Vector2 destiny = camera.ScreenToWorldPoint(Input.mousePosition);

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point);

            if (hitInfo.collider.gameObject.tag == "box")
            {
                Debug.Log("hook");

                if (ropeActive == false)
                {
                    curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

                    curHook.GetComponent<RopeScript>().destiny = destiny;

                    ropeActive = true;
                }
            }
        }

        else
        {
            GameStatus.gameStatus.status = GameStatus.Status.onPlaying;

            Destroy(curHook);

            ropeActive = false;
        }       
    }

    Vector2 PonitPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }


    IEnumerator bowUse()
    {
        yield return null;

        if (shot == false)
        {
            shot = true;
            bow.SetActive(true);
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].GetComponent<SpriteRenderer>().enabled = true;
            }

            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            an.GetComponent<SpriteRenderer>().enabled = false;
            bow_h.GetComponent<SpriteRenderer>().enabled = true;
            body.GetComponent<SpriteRenderer>().enabled = true;
            leg.GetComponent<SpriteRenderer>().enabled = true;
            hair.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (shot == true)
        {
            GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
            shot = false;
            bow.SetActive(false);
            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].GetComponent<SpriteRenderer>().enabled = false;
            }

            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            an.GetComponent<SpriteRenderer>().enabled = true;
            bow_h.GetComponent<SpriteRenderer>().enabled = false;
            body.GetComponent<SpriteRenderer>().enabled = false;
            leg.GetComponent<SpriteRenderer>().enabled = false;
            hair.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator hidePoints()
    {
        yield return (0.5f);

        for (int i = 0; i < numberOfPoints; i++)
            points[i].GetComponent<SpriteRenderer>().enabled = false;
    }
    public enum bowstatus
    {
        normal,
        bridge
    }
}