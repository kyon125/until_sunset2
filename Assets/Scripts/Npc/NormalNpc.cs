using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNpc : Npc
{
    void Start()
    {
        
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
