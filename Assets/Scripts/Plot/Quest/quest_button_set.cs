using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest_button_set : MonoBehaviour
{
    // Start is called before the first frame update
    public Quest_set quest_status;
    public Text text;
    public simplot dia;
    void Start()
    {
        dia = GameObject.Find("PlotController").GetComponent<simplot>();
        text.text = quest_status.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void button_click()
    {
        //替接受跟拒絕附值
        //GameObject.Find("B_accept").GetComponent<quest_button_set>().quest_status = quest_status;
        //GameObject.Find("B_refuse").GetComponent<quest_button_set>().quest_status = quest_status;

        //清除選項，並關閉視窗
        //for (int i = 0; i < GameObject.Find("Questcontent").transform.childCount; i++)
        //{
        //    GameObject go = GameObject.Find("Questcontent").transform.GetChild(i).gameObject;
        //    Destroy(go);
        //}

        
        //addquest();
        ////假如完成任務的話，將目標npc調回一般狀態
        //for (int i = 0; i < quest_status.next_quest.Count; i++)
        //{
        //    if (quest_status.next_quest[i].quest.status == queststatus.quested)
        //    {
        //        GameObject.Find(quest_status.next_quest[i].quest.traget_NPC).GetComponent<NormalNpc>().Status = Npc.NPC_status.normal;
        //    }
        //}
        
        if (quest_status.haveitem == true)
        {
            dia.playquestingdia((int)quest_status.start_plot.x, (int)quest_status.start_plot.y, quest_status.haveitem , quest_status.itemid, quest_status.itemnum);
            quest_status.haveitem = false;
        }
        else
        {
            dia.playdia((int)quest_status.start_plot.x, (int)quest_status.start_plot.y);
        }
        dia.closequest();
        //if (quest_status.accept == true)
        //{
        //    dia.playquestingdia((int)quest_status.start_plot.x, (int)quest_status.start_plot.y);
        //    dia.closequest();
        //}
        //else
        //{

        //}      
    }

    public void accept()
    {
        print(GameObject.Find(quest_status.traget_NPC).GetComponent<NormalNpc>().quest);
        dia.close_cheakquest();
        dia.playdia((int)quest_status.accept_plot.x, (int)quest_status.accept_plot.y);

        //設定下一個npc
        //for (int i = 0; i < quest_status.next_quest.Count; i++)
        //{
        //    if (quest_status.goal == goal_type.search)
        //    {
        //        NormalNpc npc = GameObject.Find(quest_status.next_quest[i].quest.traget_NPC).GetComponent<NormalNpc>();
        //        npc.Status = Npc.NPC_status.isquest;
        //        npc.quest.Insert(0, quest_status.next_quest[i].quest);
        //    }
        //}
        //將任務放入任務列表中
        addquest();

        //移除當前npc之任務
        for (int i = 0; i < GameObject.Find(quest_status.traget_NPC).GetComponent<NormalNpc>().quest.Count; i++)
        {
            if (GameObject.Find(quest_status.traget_NPC).GetComponent<NormalNpc>().quest[i].name == quest_status.name)
            {
                GameObject.Find(quest_status.traget_NPC).GetComponent<NormalNpc>().quest.RemoveAt(i);
                break;
            }            
        }
        if (GameObject.Find(quest_status.traget_NPC).GetComponent<NormalNpc>().quest.Count == 1)
        {
            GameObject.Find(quest_status.traget_NPC).GetComponent<NormalNpc>().Status = Npc.NPC_status.normal;
        }       
    }

    public void refuse()
    {
        dia.close_cheakquest();
        dia.playdia((int)quest_status.refuse_plot.x, (int)quest_status.refuse_plot.y);        
    }
    //將任務放入任務列表中
    void addquest()
    {
        if (quest_status.next_quest != null)
        {
            Quest_controller.questcontroller.AddQuest(quest_status);
        }        
    }
    //在結束對話後，加入道具
    
}
