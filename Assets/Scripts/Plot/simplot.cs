using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class simplot : MonoBehaviour
{
    
    List<Plotclass> plot;

    public int start, end;
    public float playspeed, UIdisapper_speed, stoptime;
    public bool play = false;

    private Text contentext, itemcontext;
    private GameStatus gameStatus;

    private GameObject i_dia, i_item, dia_text, quest;
    public static simplot plotPlay;
    // Start is called before the first frame update
    void Start()
    {
        plotPlay = this;
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();

        contentext = GameObject.Find("DialogBox").GetComponent<Text>();
        itemcontext = GameObject.Find("item_DialogBox").GetComponent<Text>();

        i_dia = GameObject.Find("I_Dialogbox");
        i_item = GameObject.Find("I_Itembox");
        dia_text = GameObject.Find("DialogBox");
        quest = GameObject.Find("Questlist");

        plot = Itemdateset.plot;
    }
    void Update()
    {
        continuedia();
    }
    public void playdia(int a, int b)
    {
        gameStatus.status = GameStatus.Status.onPloting;
        StartCoroutine(playplot(a, b));
    }

    public void playquestdia(int a, int b)
    {
        gameStatus.status = GameStatus.Status.onPloting;
        StartCoroutine(playquestplot(a, b));
    }
    public void playquestingdia(int a, int b, bool haveitem, int id, int num)
    {
        gameStatus.status = GameStatus.Status.onPloting;
        StartCoroutine(playquestingplot(a, b , haveitem , id ,num));
    }
    public void playgetitem(string a, int b)
    {
        StartCoroutine(getitem(a, b));
    }

    public IEnumerator playplot(int start, int end)
    {
        opnediabox();

        for (int a = start; a <= end; a++)
        {
            if (plot[a].target != "An")
            {
                string speaktext = plot[a].target + ":" + plot[a].content;

                foreach (char letter in speaktext.ToCharArray())
                {
                    contentext.text += letter;
                    yield return new WaitForSeconds(playspeed);
                }                
            }
            else
            {
                string speaktext = plot[a].content;

                foreach (char letter in speaktext.ToCharArray())
                {
                    contentext.text += letter;
                    yield return new WaitForSeconds(playspeed);
                }                
            }
            yield return new WaitUntil(() => { return play; });
            contentext.text = "";
            play = false;            
        }

        closediabox();
    }
    //接取任務
    IEnumerator playquestplot(int start, int end)
    {
        opnediabox();

        for (int a = start; a <= end; a++)
        {
            if (plot[a].target != "An")
            {
                string speaktext = plot[a].target + ":" + plot[a].content;

                foreach (char letter in speaktext.ToCharArray())
                {
                    contentext.text += letter;
                    yield return new WaitForSeconds(playspeed);                    
                }             
            }
            else
            {
                string speaktext = plot[a].content;

                foreach (char letter in speaktext.ToCharArray())
                {
                    contentext.text += letter;
                    yield return new WaitForSeconds(playspeed);                    
                }
            }    
            yield return new WaitUntil(() => { return play; });
            contentext.text = "";
            play = false;            
        }       

        showquest();
    }
    //接取任務中
    IEnumerator playquestingplot(int start, int end ,bool haveitem , int id, int num)
    {
        opnediabox();

        for (int a = start; a <= end; a++)
        {
            if (plot[a].target != "An")
            {
                string speaktext = plot[a].target + ":" + plot[a].content;

                foreach (char letter in speaktext.ToCharArray())
                {
                    contentext.text += letter;
                    yield return new WaitForSeconds(playspeed);
                }                
            }
            else
            {
                string speaktext = plot[a].content;

                foreach (char letter in speaktext.ToCharArray())
                {
                    contentext.text += letter;
                    yield return new WaitForSeconds(playspeed);
                }                
            }
            yield return new WaitUntil(() => { return play; });
            contentext.text = "";
            play = false;            
        }
        PlayerBag.playerbag.getitem(id, num);

        closediabox();
        //opnediabox();

        //for (int a = start; a <= end; a++)
        //{
        //    if (plot[a].target != "An")
        //    {
        //        string speaktext = plot[a].target + ":" + plot[a].content;

        //        foreach (char letter in speaktext.ToCharArray())
        //        {
        //            contentext.text += letter;
        //            yield return new WaitForSeconds(playspeed);
        //        }
        //    }
        //    else
        //    {
        //        string speaktext = plot[a].content;

        //        foreach (char letter in speaktext.ToCharArray())
        //        {
        //            contentext.text += letter;
        //            yield return new WaitForSeconds(playspeed);
        //        }
        //    }
        //    yield return new WaitUntil(() => { return play; });
        //    play = false;
        //    contentext.text = "";
        //}
        //closediabox();
        //是否接受任務
        //open_cheakquest();
    }
    IEnumerator getitem(string itemName , int itemNum)
    {
        Tween i = i_item.transform.DOMoveX(1870F, 0.3f);
        //gameStatus.status = GameStatus.Status.onPlaying;

        itemcontext.text = "獲得了" + itemName + " * " + itemNum;
        float speed = 1f + itemcontext.text.Length * playspeed;
        yield return new WaitForSeconds(1.5f +speed);

        itemcontext.text = "";
        Tween i2 = i_item.transform.DOMoveX(2153.8F, 0.3f);

    }

    public void opnediabox()
    {
        Tween t = dia_text.transform.DOScaleX(1, UIdisapper_speed);
        Tween t2 = i_dia.transform.DOScaleX(1, UIdisapper_speed);
    }
    public void closediabox()
    {
        Tween t = dia_text.transform.DOScaleX(0, UIdisapper_speed);
        Tween t2 = i_dia.transform.DOScaleX(0, UIdisapper_speed);

        contentext.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
    }

    public void showquest()
    {
        Tween t = quest.transform.DOScaleX(1, UIdisapper_speed);
        gameStatus.status = GameStatus.Status.onQuestchoose;
    }
    public void closequest()
    {
        Tween t = quest.transform.DOScaleX(0, UIdisapper_speed);
    }

    public void open_cheakquest()
    {
        Tween t = GameObject.Find("Choosebox").transform.DOScaleX(1, UIdisapper_speed);
        gameStatus.status = GameStatus.Status.onQuestchoose;
    }
    public void close_cheakquest()
    {
        Tween t = GameObject.Find("Choosebox").transform.DOScaleX(0, UIdisapper_speed);
        gameStatus.status = GameStatus.Status.onQuestchoose;
    }

    public void continuedia()
    {
        if (Input.GetMouseButtonDown(0) && gameStatus.status == GameStatus.Status.onPloting)
        {
            play = true;
        }
    }
}
