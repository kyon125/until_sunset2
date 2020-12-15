using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNpc : Npc
{
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        save();
        load();
    }
    void load()
    {
        print(PlayerPrefs.HasKey(this.name + "npcname"));
        //假設有存檔，並執行了讀檔
        if (PlayerPrefs.HasKey(this.name + "npcname")&& GameStatus.gameStatus.archivestatus == GameStatus.ArchiveStatus.isLoad)
        {
            print("i loaoaoaoaoaa");
            this.name = PlayerPrefs.GetString(this.name + "npcname");
            this.firstdia = new Vector2(PlayerPrefs.GetInt(this.name + "npcplotX"), PlayerPrefs.GetInt(this.name + "npcplotY"));
            this.Status = (Npc.NPC_status)System.Enum.Parse(typeof(Npc.NPC_status), PlayerPrefs.GetString(this.name + "npcstatus"));
            int qc = PlayerPrefs.GetInt(this.name + "questcount");

            this.quest = new List<Quest_set>();
            for (int i = 0; i < qc; i++)
            {
                Quest_set q = new Quest_set();
                q.name = PlayerPrefs.GetString(this.name + "questname" + i);
                q.start_plot = new Vector2(PlayerPrefs.GetInt(this.name + "plotX" + i), PlayerPrefs.GetInt(this.name + "plotY" + i));

                q.haveitem = PlayerPrefs.GetInt(this.name + "haveitem" + i) == 0 ? false : true;
                q.goal = (goal_type)System.Enum.Parse(typeof(goal_type), PlayerPrefs.GetString(this.name + "goaltype" + i));
                q.status = (queststatus)System.Enum.Parse(typeof(queststatus), PlayerPrefs.GetString(this.name + "goalstatus" + i));
                q.itemid = PlayerPrefs.GetInt(this.name + "itemid" + i);
                q.itemnum = PlayerPrefs.GetInt(this.name + "itemnum" + i);
                int nqc = PlayerPrefs.GetInt(this.name + "nextquestCount" + i);
                q.next_quest = new List<Quest_scriptable>();
                for (int a = 0; a < nqc; a++)
                {
                    q.next_quest.Add(Resources.Load<Quest_scriptable>("Quest" + PlayerPrefs.GetString(this.name + "nextquest" + i + "a" + a)));
                }
                this.quest.Add(q);
            }
        }
    }
    void save()
    {        
        //當遊戲為存檔狀態時，進行存檔
        if (GameStatus.gameStatus.status == GameStatus.Status.onSaving)
        {
            print("aaaaaasssave");
            PlayerPrefs.SetString(this.name + "npcname", this.name);
            PlayerPrefs.SetInt(this.name + "npcplotX", (int)this.firstdia.x);
            PlayerPrefs.SetInt(this.name + "npcplotY", (int)this.firstdia.y);
            PlayerPrefs.SetString(this.name + "npcstatus", this.Status.ToString());

            PlayerPrefs.SetInt(this.name + "questcount", this.quest.Count);

            for (int i = 0; i < this.quest.Count; i++)
            {
                
                print(this.quest[i].next_quest.Count);
                PlayerPrefs.SetString(this.name + "questname" + i, quest[i].name);
                PlayerPrefs.SetInt(this.name + "plotX" + i, (int)this.quest[i].start_plot.x);
                PlayerPrefs.SetInt(this.name + "plotY" + i, (int)this.quest[i].start_plot.y);
                
                if (this.quest[i].haveitem == false)
                {
                    PlayerPrefs.SetInt(this.name + "haveitem" + i, 0);
                }
                else
                {
                    PlayerPrefs.SetInt(this.name + "haveitem" + i, 1);
                }

                PlayerPrefs.SetString(this.name + "goaltype" + i, this.quest[i].goal.ToString());
                PlayerPrefs.SetString(this.name + "goalstatus" + i, this.quest[i].status.ToString());


                PlayerPrefs.SetInt(this.name + "itemid" + i, this.quest[i].itemid);
                PlayerPrefs.SetInt(this.name + "itemnum" + i, this.quest[i].itemnum);

                PlayerPrefs.SetInt(this.name + "nextquestCount" + i, this.quest[i].next_quest.Count);
                for (int a = 0; a < this.quest[i].next_quest.Count; a++)
                {
                    PlayerPrefs.SetString(this.name + "nextquest" + i + "a" + a, this.quest[i].next_quest[a].name);
                }
            }
        }
    }
    public override void speak()
    {
        switch (Status)
        {
            case (NPC_status.normal):
                {
                    simplot.plotPlay.playdia((int)firstdia.x, (int)firstdia.y);
                    break;
                }
            case (NPC_status.isquest):
                {
                    simplot.plotPlay.playquestdia((int)firstdia.x, (int)firstdia.y);
                    for (int i = 0; i < quest.Count; i++)
                    {
                        Quest_controller.questcontroller.creat_choosebutton(quest[i]);
                    }
                    break;
                }
        }
    }
}
