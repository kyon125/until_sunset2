using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class Elevator_Set : MonoBehaviour
{
    // Start is called before the first frame update
    public float ele_start_y, ele_end_y , player_start_y , player_end_y , time;
    public GameObject elevator;
    private GameStatus gameStatus;
    private float g;
    private bool top = false;

    public GameObject cam ,cam2 , ele_block;
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        CinemachineVirtualCamera cam2 = cam.GetComponent<CinemachineVirtualCamera>();
        g = GameObject.Find("An").GetComponent<Rigidbody2D>().gravityScale;

        ele_block.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameObject.Find("An").GetComponent<CharacterController2D>().isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player")
            {
                if (top == false)
                {
                    
                    gameStatus.status = GameStatus.Status.onPloting;

                    GameObject.Find("An").GetComponent<Rigidbody2D>().velocity = new Vector2(0 , GameObject.Find("An").GetComponent<Rigidbody2D>().velocity.y);

                    StartCoroutine(elevator_up());
                    StartCoroutine(player_up());

                    ele_block.SetActive(true);
                    cam.SetActive(false);
                    cam2.SetActive(true);
                }
                else
                {
                    gameStatus.status = GameStatus.Status.onPloting;

                    GameObject.Find("An").GetComponent<Rigidbody2D>().velocity = new Vector2(0, GameObject.Find("An").GetComponent<Rigidbody2D>().velocity.y);

                    StartCoroutine(elevator_down());
                    StartCoroutine(player_down());

                    ele_block.SetActive(false);
                    cam2.SetActive(false);
                    cam.SetActive(true);
                }
            }
        }
    }

    IEnumerator elevator_up()
    {
        Tween t = elevator.transform.DOMoveY(ele_end_y, time);
        yield return new WaitForSeconds(time);
        top = true;
        gameStatus.status = GameStatus.Status.onPlaying;
    }
    IEnumerator elevator_down()
    {
        Rigidbody2D an = GameObject.Find("An").GetComponent<Rigidbody2D>();
        an.gravityScale = 0;

        Tween t = elevator.transform.DOMoveY(ele_start_y, time);
        yield return new WaitForSeconds(time);

        an.gravityScale = g;
        top = false;
        gameStatus.status = GameStatus.Status.onPlaying;
    }
    IEnumerator player_up()
    {
        Tween t = GameObject.Find("An").transform.DOMoveY(player_end_y, time);
        yield return new WaitForSeconds(time);
        top = true;
        gameStatus.status = GameStatus.Status.onPlaying;
    }
    IEnumerator player_down()
    {
        Rigidbody2D an = GameObject.Find("An").GetComponent<Rigidbody2D>();
        an.gravityScale = 0;

        Tween t = GameObject.Find("An").transform.DOMoveY(player_start_y, time);
        yield return new WaitForSeconds(time);

        an.gravityScale = g;
        top = false;
        gameStatus.status = GameStatus.Status.onPlaying;
    }
}
