using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class interAction : MonoBehaviour
{
    Material m;
    [HideInInspector]
    public int start, end, itemnum;
    public GameObject UI;
    Vector3 t_scale;
    [HideInInspector]
    public bool hasItem;
    [SerializeField]
    public List<item> items = new List<item>();
    [HideInInspector]
    public int get_start, get_end;

    // Start is called before the first frame update
    private void Awake()
    {
        print(get_start);
    }
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
        if (CharacterController2D.chara.playeraction == playerAction.isActionobj && Input.GetKeyDown(KeyCode.F)) 
        {
            if (GameStatus.gameStatus.status != GameStatus.Status.onPloting)
            {
                simplot.plotPlay.playdia(start, end);
            }            
        }        
    }
    public void  interaction()
    {
        if (GameStatus.gameStatus.status != GameStatus.Status.onPloting)
        {
            switch (CharacterController2D.chara.playeraction)
            {
                case (playerAction.isActionobj):
                    {
                        simplot.plotPlay.playdia(start, end);
                        break;
                    }
                case (playerAction.isItemobj):
                    {
                        simplot.plotPlay.playdia(get_start, get_end);
                        break;
                    }
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
            if (hasItem == true)
            {
                CharacterController2D.chara.playeraction = playerAction.isItemobj;
                CharacterController2D.chara.actobj = this;
            }
            else
            {
                CharacterController2D.chara.playeraction = playerAction.isActionobj;
                CharacterController2D.chara.actobj = this;
            }            
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController2D.chara.playeraction = playerAction.isNormal;
            CharacterController2D.chara.actobj = null;
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
[System.Serializable]
public class item
{
    [Header("道具ID")]
    public int id;
    [Header("道具數量")]
    public int count;
}
