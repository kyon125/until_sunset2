using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bagusing : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerBag player;
    public GameObject com;
    private GameStatus gameStatus;
    private int num_select;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBag>();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= player.bg.I_num.Count - 1; i++)
        {
            print(player.bg.I_item[i].show_name +  player.bg.I_num[i]);
        }
    }
    //道具的使用
    public void useitem()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        if (gameStatus.status == GameStatus.Status.onBaging)
        {
            switch (num_select)
            {
                case (3):
                    print("ggg");
                    GameObject lil = Instantiate(Resources.Load<GameObject>("simple_fire") , GameObject.Find("An").transform);
                    break;
            }
        }
        else if (gameStatus.status == GameStatus.Status.onComposition)
        {

            if (player.comitem.Count < 2)
            {
                player.comitem.Add(Itemdateset.itemdate[num_select]);

                GameObject item = Instantiate(player.itemsource, GameObject.Find("ct").transform);

                Image im = item.GetComponent<Image>();
                Sprite p = Resources.Load<Sprite>("Itemsprite/" + num_select.ToString());
                im.sprite = p;

                item.name = Itemdateset.itemdate[num_select].show_name;               
            }
        }
        else
        {

        }
    }
    public void close()
    {
        Destroy(GameObject.Find("P_pack"));
        //gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        //switch (gameStatus.status)
        //{
        //    case GameStatus.Status.onBaging:
        //        {
        //            Destroy(GameObject.Find("P_pack"));
        //            gameStatus.status = GameStatus.Status.onPlaying;                    
        //            break;
        //        }
        //    case GameStatus.Status.onComposition:
        //        {
        //            player.comitem.Clear();
        //            gameStatus.status = GameStatus.Status.onBaging;
        //            Destroy(GameObject.Find("P_com"));
        //            break;
        //        }
        //}
    }
    public void B_composite()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        switch (gameStatus.status)
        {
            case GameStatus.Status.onBaging:
                {
                    gameStatus.status = GameStatus.Status.onComposition;
                    Destroy(GameObject.Find("I_block"));
                    print(gameStatus.status);
                    break;
                }
            case GameStatus.Status.onComposition:
                {
                    break;
                }
        }             
    }
    //選擇道具
    public void select()
    {
        num_select = this.gameObject.GetComponent<Itemset>().Item_id;

        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();

        if (gameStatus.status == GameStatus.Status.onComposition)
        {

            if (player.comitem.Count < 2)
            {
                player.comitem.Add(Itemdateset.itemdate[num_select]);

                GameObject item = Instantiate(player.itemsource, GameObject.Find("ct").transform);

                Image im = item.GetComponent<Image>();
                Sprite p = Resources.Load<Sprite>("Itemsprite/" + num_select.ToString());
                im.sprite = p;

                item.name = Itemdateset.itemdate[num_select].show_name;
            }
        }
    }
    public void composite()
    {
        for (int i = 1; i < Itemdateset.composition.Count - 1; i++)
        {
            if (player.comitem.Contains(Itemdateset.itemdate[Itemdateset.composition[i].item1]) && player.comitem.Contains(Itemdateset.itemdate[Itemdateset.composition[i].item2]))
            {
                if (player.bg.I_item.Contains(Itemdateset.itemdate[Itemdateset.composition[i].composition]) == true)
                {
                    int num = player.bg.I_item.IndexOf(Itemdateset.itemdate[Itemdateset.composition[i].composition]);
                    player.bg.I_num[num]++;
                }
                else if (player.bg.I_item.Contains(Itemdateset.itemdate[Itemdateset.composition[i].composition]) == false)
                {
                    player.bg.I_item.Add(Itemdateset.itemdate[Itemdateset.composition[i].composition]);
                    player.bg.I_num.Add(1);

                    GameObject it = Instantiate(player.itemsource, GameObject.Find("itemcreat").transform);
                    it.GetComponent<Itemset>().Item_id = Itemdateset.composition[i].composition;
                    it.GetComponent<Itemset>().reset();
                }

                for (int a = 0; a < 2; a++)
                {
                    int n = player.bg.I_item.IndexOf(player.comitem[a]);
                    player.bg.I_num[n]--;
                }
            }
            else
            {
                
            }

            for (int a = 0; a < GameObject.Find("ct").transform.childCount; a++)
            {
                GameObject go = GameObject.Find("ct").transform.GetChild(a).gameObject;
                Destroy(go);
            }

            player.comitem.Clear();
        }
    }
}

