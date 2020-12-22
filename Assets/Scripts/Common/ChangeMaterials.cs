using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeMaterials : MonoBehaviour
{
    // Start is called before the first frame update
    public int cheakitem , s1,s2 ,e1 ,e2 ;
 
    public Convey convey;
    bool haskey ,isplayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isplayer == true && convey.isuse == false)
        {
            cheackitem();
            dia();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            isplayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            isplayer = false;
        }
    }
    void dia()
    {
        if (haskey == false)
        {
            simplot.plotPlay.playdia(s1, e1);
        }
        else if (haskey == true)
        {
            //simplot.plotPlay.playdia(s2, e2);
        }        
    }
    void cheackitem()
    {
        StartCoroutine(use());
    }
    IEnumerator use()
    {
        for (int i = 0; i < PlayerBag.playerbag.bg.I_item.Count; i++)
        {
            if (PlayerBag.playerbag.bg.I_item[i].id == cheakitem)
            {
                haskey = true;
                convey.isuse = true;
                GameStatus.gameStatus.status = GameStatus.Status.onPloting;
                yield return StartCoroutine(simplot.plotPlay.playplot(s2, e2));                
                convey.go();
            }
        }
    }
}
