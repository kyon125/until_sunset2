﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    GameStatus gameStatus;

    public CharacterController2D An;
    public GameObject menu, player, bag, quest, button;
    public GameObject questcontent, s_quest, e_quest, questbutton;
    private PlayerBag bg;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        bg = GameObject.Find("GameController").GetComponent<PlayerBag>();
    }

    // Update is called once per frame
    void Update()
    {
        callpack();
    }

    public void open_quest()
    {
        gameStatus.status = GameStatus.Status.onQuestlist;

        all_off();
        quest.gameObject.SetActive(true);
        //新增進行中任務
        //Instantiate(s_quest, GameObject.Find("m_QuestContent").transform);

        //新增完成的任務

        Tween t = GameObject.Find("Quest").transform.DOScale(new Vector3(1, 1, 1), 0.01f);
    }
    public void open_bag()
    {
        gameStatus.status = GameStatus.Status.onBaging;

        all_off();
        bg.creatitem();
        bag.gameObject.SetActive(true);
        

        Tween t = GameObject.Find("Bag").transform.DOScale(new Vector3(1, 1, 1), 0.01f);
    }
    void callpack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gameStatus.status == GameStatus.Status.onPlaying)
        {
            //gameStatus.status = GameStatus.Status.onBaging;
            //GameObject.Find("GameController").GetComponent<PlayerBag>().creatitem();
            //PlayerBag.playerbag.creatitem();
            //Tween t = bag.transform.DOScaleX(1, 0.2f).SetEase(Ease.OutBack);
            //Tween t2 = bag.transform.DOScaleY(1, 0.2f).SetEase(Ease.OutBack);
            //button.gameObject.SetActive(true);
            open_bag();
            //intialquest();
        }
    }
    //void intialquest()
    //{
    //    //新增進行中任務
    //    Instantiate(s_quest, questcontent.transform);
    //    for (int i = 0; i < Quest_controller.questcontroller.questlisting.Count; i++)
    //    {
    //        if (Quest_controller.questcontroller.questlisting[i].status == queststatus.questing)
    //        {
    //            GameObject b = Instantiate(questbutton, questcontent.transform);
    //            b.GetComponent<m_quest>().questvalue = Quest_controller.questcontroller.questlisting[i];
    //            b.transform.GetChild(0).GetComponent<Text>().text = Quest_controller.questcontroller.questlisting[i].name;
    //        }               
    //    }
    //    //新增完成的任務
    //    Instantiate(e_quest, questcontent.transform);
    //    for (int i = 0; i < Quest_controller.questcontroller.questlisting.Count; i++)
    //    {
    //        if (Quest_controller.questcontroller.questlisting[i].status == queststatus.quested)
    //        {
    //            GameObject b = Instantiate(questbutton, questcontent.transform);
    //            b.GetComponent<m_quest>().questvalue = Quest_controller.questcontroller.questlisting[i];
    //            b.transform.GetChild(0).GetComponent<Text>().text = Quest_controller.questcontroller.questlisting[i].name;
    //        }
    //    }
    //}
    public void close()
    {
        print("close");
        switch (gameStatus.status)
        {
            case GameStatus.Status.onMenu:
                {
                    gameStatus.status = GameStatus.Status.onPlaying;
                    Tween t = GameObject.Find("PackMain").transform.DOScale(new Vector3(0, 0, 1), 0.2f).SetEase(Ease.OutSine);
                    for (int i = 1; i < this.gameObject.transform.childCount; i++)
                    {
                        this.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    clear();
                    break;
                }
            case GameStatus.Status.onBaging:
                {
                    gameStatus.status = GameStatus.Status.onPlaying;
                    Tween t = GameObject.Find("Bag").transform.DOScale(new Vector3(0, 0, 1), 0.01f).SetEase(Ease.OutSine);
                    GameObject.Find("Bag").SetActive(false);
                    clear();
                    break;
                }
            case GameStatus.Status.onComposition:
                {
                    gameStatus.status = GameStatus.Status.onBaging;
                    Tween t = GameObject.Find("com").transform.DOScale(new Vector3(0, 0, 1), 0.2f).SetEase(Ease.OutSine);
                    break;
                }
            case GameStatus.Status.onQuestlist:
                {
                    gameStatus.status = GameStatus.Status.onPlaying;
                    Tween t = GameObject.Find("PackMain").transform.DOScale(new Vector3(0, 0, 1), 0.2f).SetEase(Ease.OutSine);
                    for (int i = 1; i < this.gameObject.transform.childCount; i++)
                    {
                        this.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    clear();
                    break;
                }
        }
    }

    void all_off()
    {
        for (int i = 1; i < this.gameObject.transform.childCount-1; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void clear()
    {
        for (int i = 0; i < questcontent.transform.childCount; i++)
        {
            Destroy(questcontent.transform.GetChild(i).gameObject);
        }
    }
}
