﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class simplot2 : MonoBehaviour
{
    List<Plotclass> plot;

    public int start, end , i_start , i_end , f_start, f_end , item_id , item_num;
    public float playspeed , UIdisapper_speed;
    public GameObject reactionUI;
    public Material mA, mB;
    public Vector3 UIscale;
    public bool ishaveitem = true;


    private float speed;
    private Text contentext , itemcontext;
    private PlayerBag An_bag;
    private GameStatus gameStatus;
    private Vector3 _uiscale;

    private GameObject i_dia , i_item , dia_text;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();

        contentext = GameObject.Find("DialogBox").GetComponent<Text>();
        itemcontext = GameObject.Find("item_DialogBox").GetComponent<Text>();


        i_dia = GameObject.Find("I_Dialogbox");
        i_item = GameObject.Find("I_Itembox");
        dia_text = GameObject.Find("DialogBox");

        _uiscale = new Vector3 (0,0,1);        

        plot = Itemdateset.plot;
    }

    // Update is called once per frame
    void Update()
    {
        print(i_item.transform.position);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().material = mA;
        Tween u = reactionUI.transform.DOScale(_uiscale, 0.2f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().material = mB;
        Tween u = reactionUI.transform.DOScale(UIscale, 0.2f);

        if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player" && ishaveitem ==true)
        {
            gameStatus.status = GameStatus.Status.onPloting;
            StartCoroutine(playplot());            
        }

        else if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player" && ishaveitem == false)
        {
            gameStatus.status = GameStatus.Status.onPloting;
            start = f_start;
            end = f_end;
            StartCoroutine(playplot());
        }
    }
   IEnumerator playplot()
    {
        Tween t4 = dia_text.transform.DOScaleX(1, UIdisapper_speed);
        Tween t = i_dia.transform.DOScaleX(1, UIdisapper_speed);

        for (int a = start; a <= end; a++)
        {
            if (plot[a].target != "An")
            {
                contentext.text = plot[a].target + ":" + plot[a].content;
                speed = 1f + plot[a].content.Length * playspeed;
            }
            else
            {
                contentext.text = plot[a].content;
                speed = 1f + plot[a].content.Length * playspeed;
                speed = 1f + plot[a].content.Length * playspeed;
            }
            yield return new WaitForSeconds(speed);
        }

        if (ishaveitem == true)
        {
            Tween i1 = i_item.transform.DOMoveX(1893F, 0.3f);
            StartCoroutine(playgetitem());
        }

        Tween t3 = dia_text.transform.DOScaleX(0, UIdisapper_speed);
        Tween t2 = i_dia.transform.DOScaleX(0, UIdisapper_speed);

        contentext.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
    }
    IEnumerator playgetitem()
    {
        ishaveitem = false;
        for (int a = i_start; a <= i_end; a++)
        {
            if (plot[a].target != "An")
            {
                itemcontext.text = plot[a].target + ":" + plot[a].content;
                speed = 1f + plot[a].content.Length * playspeed;
            }
            else
            {
                itemcontext.text = plot[a].content;
                speed = 1f + plot[a].content.Length * playspeed;
            }
            yield return new WaitForSeconds(speed);
        }

        yield return new WaitForSeconds(2f);
        itemcontext.text = "";
        Tween i2 = i_item.transform.DOMoveX(2153.8F, 0.3f);        
    }
}