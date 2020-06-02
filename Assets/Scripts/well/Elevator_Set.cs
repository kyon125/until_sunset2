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
    private PlayerBag An_bag;
    private float g;
    private bool top = true;
    private simplot plot;

    public GameObject ele_block;
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        
        g = GameObject.Find("An").GetComponent<Rigidbody2D>().gravityScale;

        An_bag = GameObject.Find("An").GetComponent<PlayerBag>();

        plot = GameObject.Find("PlotController").GetComponent<simplot>();

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
                if (An_bag.bg.I_item.Contains(Itemdateset.itemdate[5]))
                {
                    if (top == false)
                    {

                        gameStatus.status = GameStatus.Status.onPloting;

                        GameObject.Find("An").GetComponent<Rigidbody2D>().velocity = new Vector2(0, GameObject.Find("An").GetComponent<Rigidbody2D>().velocity.y);

                        StartCoroutine(elevator_up());
                        StartCoroutine(player_up());

                    }
                    else
                    {
                        gameStatus.status = GameStatus.Status.onPloting;

                        GameObject.Find("An").GetComponent<Rigidbody2D>().velocity = new Vector2(0, GameObject.Find("An").GetComponent<Rigidbody2D>().velocity.y);

                        StartCoroutine(elevator_down());
                        StartCoroutine(player_down());
                    }
                }
                else
                {
                    plot.start = 46;
                    plot.end = 46;
                    plot.playdia();
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
