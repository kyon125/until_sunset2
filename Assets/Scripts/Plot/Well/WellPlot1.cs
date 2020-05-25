using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WellPlot1 : MonoBehaviour
{
    // Start is called before the first frame update
    List<Plotclass> plot = new List<Plotclass>();
    public float playspeed;
    public int start, end;
    public string plotname;

    private float speed;
    private GameStatus gameStatus;
    private Text contentext;
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        contentext = GameObject.Find("DialogBox").GetComponent<Text>();
        
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
            gameStatus.status = GameStatus.Status.onPloting;
            StartCoroutine(playplot());
        }
    }
    IEnumerator playplot()
    {
        yield return new WaitForSeconds(2f);

        GameObject an = GameObject.FindWithTag("Player");
        an.transform.GetChild(0).GetComponent<Animator>().SetInteger("Walk", 1);
        Tween tw = an.transform.DOMoveX(77.9F, 2.5f);

        yield return new WaitForSeconds(2.5f);
        an.transform.GetChild(0).GetComponent<Animator>().SetInteger("Walk", 0);

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
        GameObject.Find("mid_straw").GetComponent<SpriteRenderer>().sortingOrder = 1;
        GameObject.Find("mid_straw2").GetComponent<SpriteRenderer>().sortingOrder = 1;
        Destroy(this.gameObject);
    }
}
