using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class interAction : MonoBehaviour
{
    Material m;
    public int start, end;
    public GameObject UI;
    Vector3 t_scale;
    // Start is called before the first frame update
    void Start()
    {
        t_scale =UI.transform.localScale;
        print(t_scale);
        UI.transform.DOScale(new Vector3( 0, 0, 0) , 0.3f);
        m = transform.GetComponent<SpriteRenderer>().material;
        m.SetFloat("_outLine", 0);
        m.SetTexture("_MainTex", this.transform.GetComponent<SpriteRenderer>().sprite.texture);
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterController2D.chara.playeraction == playerAction.iscolliderobj && Input.GetKeyDown(KeyCode.F)) 
        {
            if (GameStatus.gameStatus.status != GameStatus.Status.onPloting)
            {
                simplot.plotPlay.playdia(start, end);
            }            
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerEnter();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController2D.chara.playeraction = playerAction.iscolliderobj;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController2D.chara.playeraction = playerAction.isnormal;
            playerLeave();
        }
    }

    void playerEnter()
    {
        UI.transform.DOScale(t_scale, 0.3f);
        m.SetFloat("outLine", 1);
    }
    void playerLeave()
    {
        UI.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        m.SetFloat("outLine", 0);
    }
}
