using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class simplot_cheakitem : MonoBehaviour
{
    List<Plotclass> plot;

    public int start, end, f_start, f_end, item_id;
    public float playspeed, UIdisapper_speed;

    public bool playerhaveitem = false;


    private float speed;
    private Text contentext, itemcontext;
    private PlayerBag An_bag;
    private GameStatus gameStatus;

    private GameObject i_dia, i_item, dia_text;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        An_bag = GameObject.Find("An").GetComponent<PlayerBag>();

        contentext = GameObject.Find("DialogBox").GetComponent<Text>();
        itemcontext = GameObject.Find("item_DialogBox").GetComponent<Text>();

        i_dia = GameObject.Find("I_Dialogbox");
        i_item = GameObject.Find("I_Itembox");
        dia_text = GameObject.Find("DialogBox");

        plot = Itemdateset.plot;
    }
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameStatus.status = GameStatus.Status.onPloting;

            if (An_bag.islight == false)
            {
                StartCoroutine(playplot());
            }
            else if (An_bag.islight == true)
            {                
                start = f_start;
                end = f_end;
                StartCoroutine(playplot());
                
            }
        }        
    }
    // Update is called once per frame
      
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

        Tween t3 = dia_text.transform.DOScaleX(0, UIdisapper_speed);
        Tween t2 = i_dia.transform.DOScaleX(0, UIdisapper_speed);

        contentext.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
        if (An_bag.islight == true)
        {
            Destroy(this.gameObject);
        }
    }
}
