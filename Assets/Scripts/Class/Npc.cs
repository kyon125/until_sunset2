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

    public enum NPC_status
    {
        normal,
        isquest,
        questing
    }
    public abstract void speak();
}


