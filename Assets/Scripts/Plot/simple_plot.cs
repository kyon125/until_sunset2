using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class simple_plot : MonoBehaviour
{
    List<Plotclass> plot;

    public int Item_id;
    public int start, end;
    public float playspeed;
    public GameObject A, B;


    private float speed;
    private Text contentext;
    private PlayerBag An_bag;
    private GameStatus gameStatus;
    private bool hasget = false;

    public GameObject i_dia , b_switch;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        contentext = GameObject.Find("DialogBox").GetComponent<Text>();
        An_bag = GameObject.Find("An").GetComponent<PlayerBag>();
        

        plot = Itemdateset.plot;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F)&& collision.tag =="Player")
        {
            i_dia.SetActive(true);
            StartCoroutine(playplot());
            selected();
            b_switch.GetComponent<simplot2>().ready = true;
        }
    }
    
    void selected()
    {
        if (An_bag.bg.I_item.Contains(Itemdateset.itemdate[Item_id]) == true)
        {
            int num = An_bag.bg.I_item.IndexOf(Itemdateset.itemdate[Item_id]);
            An_bag.bg.I_num[num]++;

            gameStatus.status = GameStatus.Status.onPloting;
            StartCoroutine(playplot());
        }
        else if (An_bag.bg.I_item.Contains(Itemdateset.itemdate[Item_id]) == false)
        {
            An_bag.bg.I_item.Add(Itemdateset.itemdate[Item_id]);
            An_bag.bg.I_num.Add(1);

            gameStatus.status = GameStatus.Status.onPloting;
            StartCoroutine(playplot());
        }

        hasget = true;
    }
    IEnumerator playplot()
    {
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
            }
            yield return new WaitForSeconds(speed);
        }

        i_dia.SetActive(false);
        GameObject.Find("An").transform.position = new Vector3(292.1f, 130.25f, 0);
        A.SetActive(false);
        B.SetActive(true);

        contentext.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
    }
}
