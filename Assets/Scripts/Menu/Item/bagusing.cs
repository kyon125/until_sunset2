﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class bagusing : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerBag player;
    public GameObject b_gocom;
    private GameStatus gameStatus;
    private int num_select;
    void Start()
    {
        player = GameObject.Find("GameController").GetComponent<PlayerBag>();
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //道具的使用
    public void useitem()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();

        if (gameStatus.status == GameStatus.Status.onBaging && player.select_itemid < 999)
        {
            print(Itemdateset.itemdate[player.select_itemid].effect);
            //if (Itemdateset.itemdate[player.select_itemid].effect.ToString() != "life")
            //{
            //    print("UESEESSEEESSES");
            //    GameStatus.gameStatus.lifeController(Itemdateset.itemdate[player.select_itemid].life);
            //    PlayerBag.playerbag.removeitem(player.select_itemid, 1);
            //    player.select_itemid = 9999;
            //}
            switch (Itemdateset.itemdate[player.select_itemid].effect)
            {
                case (1):
                    {
                        print("UESEESSEEESSES");
                        GameStatus.gameStatus.lifeController(Itemdateset.itemdate[player.select_itemid].life);
                        PlayerBag.playerbag.removeitem(player.select_itemid, 1);
                        for (int i = 0; i < player.bg.I_item.Count; i++)
                        {
                            print(PlayerBag.playerbag.select_itemid);
                            if (player.bg.I_item[i].id == PlayerBag.playerbag.select_itemid)
                            {
                                print("ususuususususu");
                                GameObject.Find("Itemname").GetComponent<Text>().text = Itemdateset.itemdate[PlayerBag.playerbag.select_itemid].show_name;
                                GameObject.Find("Itemimage").GetComponent<Image>().sprite = Resources.Load<Sprite>("Itemsprite/" + PlayerBag.playerbag.select_itemid); ;
                                GameObject.Find("itemdescrip").GetComponent<Text>().text = Itemdateset.itemdate[PlayerBag.playerbag.select_itemid].depiction;
                                GameObject.Find("itemnumtext").GetComponent<Text>().text = "剩餘" + PlayerBag.playerbag.bg.I_num[i];
                            }
                        }
                        break;
                    }
            }
        }
    }
    
    public void B_composite()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        switch (gameStatus.status)
        {
            case GameStatus.Status.onBaging:
                {
                    gameStatus.status = GameStatus.Status.onComposition;
                    Tween t = GameObject.Find("com").transform.DOScaleX(1f, 0.2f);
                    Tween t2 = GameObject.Find("com").transform.DOScaleY(1f, 0.2f);
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
        player.select_itemid = this.gameObject.GetComponent<Itemset>().Item_id;
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
        else if (gameStatus.status == GameStatus.Status.onBaging)
        {
            print(Itemdateset.itemdate[num_select].depiction);
            GameObject.Find("Itemname").GetComponent<Text>().text = Itemdateset.itemdate[num_select].show_name;
            GameObject.Find("Itemimage").GetComponent<Image>().sprite = this.gameObject.GetComponent<Image>().sprite;
            GameObject.Find("itemdescrip").GetComponent<Text>().text = Itemdateset.itemdate[num_select].depiction;
            for (int i = 0; i < player.bg.I_item.Count; i++)
            {
                if (player.bg.I_item[i].id == num_select)
                {
                    GameObject.Find("itemnumtext").GetComponent<Text>().text = "剩餘" + PlayerBag.playerbag.bg.I_num[i];
                }
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

                //清空選擇圖示
                GameObject.Find("Itemname").GetComponent<Text>().text = "";
                GameObject.Find("Itemimage").GetComponent<Image>().sprite = Resources.Load<Sprite>("Itemsprite/" + "0");
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

