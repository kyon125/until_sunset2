using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiki_set : Npc
{
    // Start is called before the first frame update
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
            case (NPC_status.normal) :
            {
                    dia.playdia(300, 300);
                    break;
            }
        }
    }
}

public enum NPC_status
{
    normal
}