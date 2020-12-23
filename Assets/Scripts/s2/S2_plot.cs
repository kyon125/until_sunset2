using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class S2_plot : MonoBehaviour
{
    // Start is called before the first frame update
    public static S2_plot2 sp2;
    public int s, e , s2 , e2;
    public SpriteRenderer Sp;
    bool isplayer;
    bool start = true;
    public bool another;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer == true && start == true && another == false)
        {
            start = false;
            StartCoroutine(plot());
        }
        else if (isplayer == true && start == true && another == true)
        {
            start = false;
            simplot.plotPlay.playdia(s,e);
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

    IEnumerator plot()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        UIcotroller.uicotroller.blackscreenOpen();
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(simplot.plotPlay.playplot(s, e));
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        Sp.DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        GameStatus.gameStatus.energyController(5);
        yield return StartCoroutine(simplot.plotPlay.playplot(s2, e2));
        UIcotroller.uicotroller.blackscreenClose();
    }

}
