using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    public simplot dia;
    public new string name;
    public Vector2 firstdia;
    public NPC_status Status;
    public Quest_controller c_quest;
    public List<Quest_set> quest;
    public npcStatus savestatus;

    public enum NPC_status
    {
        normal,
        isquest,
        questing
    }
    public abstract void speak();

    public class npcStatus
    {
        public string npcname;

        public int npc_plotX, npc_plotY;
        public string npcstatus;

        public string quest_name;

        public int start_plotX, start_plotY;
        public Vector2 start_plot;

        public int haveiem;

        public string goal_type;
        public string queststatus;

        public int itemid, itemunm;

        public string traget_NPC;
        public List<string> next_quest;
    }
}


