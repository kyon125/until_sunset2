using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_plotman : MonoBehaviour
{
    // Start is called before the first frame update
    public int s, s1, s2, s3, e, e1, e2, e3;
    bool isplayer;
    Status status = new Status();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cheak();
        if (Input.GetKeyDown(KeyCode.F) && GameStatus.gameStatus.status == GameStatus.Status.onPlaying && isplayer == true)
        {
            switch (status)
            {
                case (Status.start):
                    {
                        firstsee();
                        break;
                    }
                case (Status.waitforwell):
                    {
                        wait();
                        break;
                    }
                case (Status.completed):
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = true;
        }
    }
    void firstsee()
    {
        simplot.plotPlay.playdia(s, e);
        status = Status.waitforwell;
        PlayerBag.playerbag.getitem(1, 1);
        GameStatus.gameStatus.mainquest = GameStatus.MainQuest.Viliage3;
    }
    void wait()
    {
        simplot.plotPlay.playdia(s1, e1);
    }
    void complete()
    {
        simplot.plotPlay.playdia(s2, e2);
        PlayerBag.playerbag.removeitem(6, 1);
        GameStatus.gameStatus.mainquest = GameStatus.MainQuest.frost1;
        status = Status.normal;
    }
    void normal()
    {
        simplot.plotPlay.playdia(s3, e3);
    }
    void cheak()
    {
        for (int i = 0; i < PlayerBag.playerbag.bg.I_item.Count; i++)
        {
            if (PlayerBag.playerbag.bg.I_item[i].id == 6 && status != Status.normal)
            {
                status = Status.completed;
            }
        }
    }

    public enum Status
    {
        start,
        waitforwell,
        completed,
        normal
    }
}
