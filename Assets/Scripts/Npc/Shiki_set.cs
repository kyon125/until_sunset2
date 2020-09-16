using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiki_set : Npc 
{
    // Start is called before the first frame update
    void Start()
    {
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
            case (NPC_status.normal) :
            {
                    dia.playdia((int)firstdia.x, (int)firstdia.y);
                    break;
            }
            case (NPC_status.isquest) :
            {
                    dia.playquestdia(301, 301);
                    //生成跟任務數相同的button
                    break;
            }
            case (NPC_status.questing):
            {
                    dia.playquestdia(301, 301);
                    //c_quest.quest_Instantiate();
                    break;
            }
        }
    }
}

