using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNpc : Npc
{
    void Start()
    {
        c_quest = GameObject.Find("Questlist").GetComponent<Quest_controller>();
        dia = GameObject.Find("PlotController").GetComponent<simplot>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void speak()
    {
        switch (Status)
        {
            case (NPC_status.normal):
                {
                    dia.playdia((int)firstdia.x, (int)firstdia.y);
                    break;
                }
            case (NPC_status.isquest):
                {
                    dia.playquestdia((int)firstdia.x, (int)firstdia.y);
                    for (int i = 0; i < quest.Count; i++)
                    {
                        c_quest.creat_choosebutton(quest[i]);
                    }
                    break;
                }
        }
    }
}
