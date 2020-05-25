using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Itemset_Plot : MonoBehaviour
{
    public bool get;
    public int plotstart, plotend, plotplayspeed , Item_id;

    private PlayerBag An;
    private Animator animator;
    private Itemdateset date;
    private GameStatus gameStatus;
    private Text contentext;

    // Start is called before the first frame update
    void Start()
    {
        An = GameObject.Find("An").GetComponent<PlayerBag>();
        animator = this.gameObject.GetComponent<Animator>();
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        contentext = GameObject.Find("DialogBox").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void plotplay()
    {
        gameStatus.status = GameStatus.Status.onPloting;
        StartCoroutine(playplot());
    }

    void con_animation()
    {
        //播放道具動畫
    }

    void getitem()
    {
        if (get == true)
        {
            //得到道具
            if (An.bg.I_item.Contains(Itemdateset.itemdate[Item_id]) == true)
            {
                int num = An.bg.I_item.IndexOf(Itemdateset.itemdate[Item_id]);
                An.bg.I_num[num]++;
            }
            else if (An.bg.I_item.Contains(Itemdateset.itemdate[Item_id]) == false)
            {
                An.bg.I_item.Add(Itemdateset.itemdate[Item_id]);
                An.bg.I_num.Add(1);
            }
        }
    }
    IEnumerator playplot()
    {
        float speed;
        for (int a = plotstart; a <= plotend; a++)
        {
            if (Itemdateset.plot[a].target != "An")
            {
                contentext.text = Itemdateset.plot[a].target + ":" + Itemdateset.plot[a].content;
                speed = 1f + Itemdateset.plot[a].content.Length * plotplayspeed;
            }
            else
            {
                contentext.text = Itemdateset.plot[a].content;
                speed = 1f + Itemdateset.plot[a].content.Length * plotplayspeed;
            }
            yield return new WaitForSeconds(speed);
        }
        contentext.text = "";
        gameStatus.status = GameStatus.Status.onPlaying;
    }
}
