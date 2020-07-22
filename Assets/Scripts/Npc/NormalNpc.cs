using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNpc : Npc
{
    public NPC_status Status;
    void Start()
    {
        Status = NPC_status.normal;
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
                    dia.playdia(firstdia[0], firstdia[1]);
                    break;
                }
        }
    }
}
