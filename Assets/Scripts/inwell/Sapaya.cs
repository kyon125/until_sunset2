using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapaya : MonoBehaviour
{
    // Start is called before the first frame update
    bool isplayer;
    Status status = new Status();
    public int s, s1, e, e1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cheak();
        if (isplayer == true && Input.GetKeyDown(KeyCode.F)&& GameStatus.gameStatus.status == GameStatus.Status.onPlaying)
        {
            switch (status)
            {
                case (Status.start):
                    {
                        firstsee();
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
    void cheak()
    {
        for (int i = 0; i < PlayerBag.playerbag.bg.I_item.Count; i++)
        {
            if (PlayerBag.playerbag.bg.I_item[i].id == 1 && status == Status.start)
            {
                status = Status.complete;
            }
        }
    }
    void firstsee()
    {
        simplot.plotPlay.playdia(s, e);        
    }
    void complete()
    {
        simplot.plotPlay.playdia(s1, e1);
        PlayerBag.playerbag.removeitem(1, 1);
        PlayerBag.playerbag.getitem(9, 1);
        GameStatus.gameStatus.mainquest = GameStatus.MainQuest.wellend;
        status = Status.normal;
    }
    void normal()
    {
        simplot.plotPlay.playdia(s, e);
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
    public enum Status
    {
        start, 
        complete,
        normal
    }
}
