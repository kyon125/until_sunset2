using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanBranch : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    public Sprite s;
    bool isplayer;
    bool hasbranch = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasbranch == true && isplayer == true && Input.GetKeyDown(KeyCode.F))
        {
            GameStatus.gameStatus.status = GameStatus.Status.onPloting;
            hasbranch = false;
            S2_plot2.sp2.cleanunm++;
            StartCoroutine(simplot.plotPlay.playplot(409, 409));
            sr.sprite = s;
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
}
