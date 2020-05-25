using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class WellPlot3 : MonoBehaviour
{
    // Start is called before the first frame update
    List<Plotclass> plot = new List<Plotclass>();
    public float playspeed;
    public int start, end;
    public string plotname;

    private GameStatus gameStatus;
    private float speed;
    private Text contentext;
    private PlayerBag An_bag;
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        contentext = GameObject.Find("DialogBox").GetComponent<Text>();
        An_bag = GameObject.Find("An").GetComponent<PlayerBag>();

        initial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void initial()
    {
        TextAsset data = Resources.Load<TextAsset>(plotname);

        string[] p = data.text.Split(new char[] { '\n' });

        for (int a = 0; a < p.Length - 1; a++)
        {
            string[] row = p[a].Split(new char[] { ',' });

            Plotclass step = new Plotclass();
            step.id = row[0];
            step.target = row[1];
            step.content = row[2];

            plot.Add(step);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && gameStatus.status != GameStatus.Status.onPloting)
        {
            selected();
        }
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
        contentext.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
    }
    IEnumerator getsimple_fire()
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

        GameObject an = GameObject.FindWithTag("Player");
        an.transform.localScale = new Vector3(-1f, an.transform.localScale.y, an.transform.localScale.z);
        an.transform.GetChild(0).GetComponent<Animator>().SetInteger("Walk", 1);
        Tween tw = an.transform.DOMoveX(75.18F, 2.5f);
        yield return new WaitForSeconds(1f);
        an.transform.GetChild(0).GetComponent<Animator>().SetInteger("Walk", 0);


        contentext.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
    }
    void selected()
    {
        if (An_bag.bg.I_item.Contains(Itemdateset.itemdate[3]) == true)
        {
            gameStatus.status = GameStatus.Status.onPloting;
            start = 28;
            end = 28;
            StartCoroutine(playplot());
        }
        else if (An_bag.bg.I_item.Contains(Itemdateset.itemdate[3]) == false)
        {
            gameStatus.status = GameStatus.Status.onPloting;
            start = 26;
            end = 26;
            StartCoroutine(getsimple_fire());
        }
    }
}
