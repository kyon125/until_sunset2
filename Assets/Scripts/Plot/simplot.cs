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

    IEnumerator playplot(int start, int end)
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
            yield return new WaitForSeconds(stoptime);
        }

        closediabox();
    }
    //播放任務劇情
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
            yield return new WaitForSeconds(stoptime);
        }

        contentext.text = "";
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
}
