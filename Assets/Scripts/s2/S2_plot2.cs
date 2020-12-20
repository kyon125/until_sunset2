using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_plot2 : MonoBehaviour
{
    public static S2_plot2 sp2;
    public int s, s1, s2,s3, e, e1, e2,e3;
    public GameObject col;
    // Start is called before the first frame update
    bool isplayer;
    bool ok;
    public int cleanunm;
    Status status = new Status();
    void Start()
    {
        sp2 = this;
    }

    // Update is called once per frame
    void Update()
    {
        cheak();
        if (Input.GetKeyDown(KeyCode.F)  && GameStatus.gameStatus.status == GameStatus.Status.onPlaying && isplayer == true)
        {
            switch (status)
            {
                case (Status.start):
                    {
                        firstsee();
                        break;
                    }
                case (Status.clean):
                    {
                        inclean();
                        break;
                    }
                case (Status.complete):
                    {
                        complete();
                        break;
                    }
                case (Status.normal):
                    {
                        normal();
                        break;
                    }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = false;
        }
    }
    void firstsee()
    {
        simplot.plotPlay.playdia(s, e);
        status = Status.clean;
    }
    void inclean()
    {
        simplot.plotPlay.playdia(s1, e1);
        GameStatus.gameStatus.energyController(5);
    }
    void cheak()
    {
        if (cleanunm == 6 && ok ==false)
        {
            ok = true;
            status = Status.complete;
        }
    }
    void complete()
    {
        StartCoroutine(Completed());
    }
    void normal()
    {
        simplot.plotPlay.playdia(s3, e3);
    }
    IEnumerator Completed()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        yield return StartCoroutine(simplot.plotPlay.playplot(s2, e2));
        PlayerBag.playerbag.getitem(8, 2);
        Destroy(col);
        status = Status.normal;
    }
    public enum Status
    {
        start,
        clean,
        complete,
        normal
    }
}
