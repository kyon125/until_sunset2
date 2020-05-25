using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotController : MonoBehaviour
{
    // Start is called before the first frame update
    List<Plotclass> plot = new List<Plotclass>();
    public float playspeed;
    public int start, end;
    public string plotname;

    private GameStatus gameStatus;
    private Text text;
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        text = GameObject.Find("DialogBox").GetComponent<Text>();
        initial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initial()
    {
        TextAsset data = Resources.Load<TextAsset>(plotname);

        string [] p = data.text.Split(new char[] { '\n' });

        for (int a = 0; a < p.Length - 1; a++)
        {
            string [] row = p[a].Split(new char [] { ','});

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
        for (int a = start; a <= end ; a++)
        {
            text.text = plot[a].content;
            yield return new WaitForSeconds(playspeed);
        }
        text.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
        Destroy(this.gameObject);
    }
}

