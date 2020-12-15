using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_controller : MonoBehaviour
{
    public static Quest_controller questcontroller;
    public List<Quest_set> questlisting;
    public GameObject button;
    // Start is called before the first frame update
    private void Awake()
    {
        questcontroller = this;
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

    public void AddQuest(Quest_set quest)
    {
        for (int i = 0; i < questlisting.Count; i++)
        {
            if (questlisting[i].name == quest.name)
            {
                questlisting.RemoveAt(i);
            }
        }
        for (int i = 0; i < quest.next_quest.Count; i++)
        {
            questlisting.Add(quest.next_quest[i].quest);
        }        
    }
    public void creat_choosebutton(Quest_set quest)
    {
        GameObject b = Instantiate(button, GameObject.Find("Questcontent").transform);
        b.GetComponent<quest_button_set>().quest_status = quest;
    }
    void save()
    {
        //當遊戲為存檔狀態時，進行存檔
        if (GameStatus.gameStatus.status == GameStatus.Status.onSaving)
        {
            PlayerPrefs.SetInt("conquest" + "questlistcount", questlisting.Count);
            for (int i = 0; i < questlisting.Count; i++)
            {
                PlayerPrefs.SetString("conquest" + "questname" + i, questlisting[i].name);
                PlayerPrefs.SetInt("conquest" + "plotX" + i, (int)this.questlisting[i].start_plot.x);
                PlayerPrefs.SetInt("conquest" + "plotY" + i, (int)this.questlisting[i].start_plot.y);

                if (this.questlisting[i].haveitem == false)
                {
                    PlayerPrefs.SetInt("conquest" + "haveitem" + i, 0);
                }
                else
                {
                    PlayerPrefs.SetInt("conquest" + "haveitem" + i, 1);
                }

                PlayerPrefs.SetString("conquest" + "goaltype" + i, this.questlisting[i].goal.ToString());
                PlayerPrefs.SetString("conquest" + "goalstatus" + i, this.questlisting[i].status.ToString());

                

                PlayerPrefs.SetInt("conquest" + "itemid" + i, this.questlisting[i].itemid);
                PlayerPrefs.SetInt("conquest" + "itemnum" + i, this.questlisting[i].itemnum);                
            }
        }
    }
    void load()
    {
        //假設有存檔，並執行了讀檔
        if (PlayerPrefs.HasKey("conquest" + "questlistcount") && GameStatus.gameStatus.archivestatus == GameStatus.ArchiveStatus.isLoad)
        {

            int qc = PlayerPrefs.GetInt("conquest" + "questlistcount");

            this.questlisting = new List<Quest_set>();
            for (int i = 0; i < qc; i++)
            {
                Quest_set q = new Quest_set();
                q.name = PlayerPrefs.GetString("conquest" + "questname" + i);
                q.start_plot = new Vector2(PlayerPrefs.GetInt("conquest" + "plotX" + i), PlayerPrefs.GetInt("conquest" + "plotY" + i));

                q.haveitem = PlayerPrefs.GetInt("conquest" + "haveitem" + i) == 0 ? false : true;
                q.goal = (goal_type)System.Enum.Parse(typeof(goal_type), PlayerPrefs.GetString("conquest" + "goaltype" + i));
                q.status = (queststatus)System.Enum.Parse(typeof(queststatus), PlayerPrefs.GetString("conquest" + "goalstatus" + i));
                q.itemid = PlayerPrefs.GetInt("conquest" + "itemid" + i);
                q.itemnum = PlayerPrefs.GetInt("conquest" + "itemnum" + i);
                int nqc = PlayerPrefs.GetInt("conquest" + "nextquestCount" + i);
                q.next_quest = new List<Quest_scriptable>(); 
                questlisting.Add(q);
            }
        }
    }
}
