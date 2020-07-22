using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    public simplot dia;
    public string name;
    public List<int> firstdia;
    public enum NPC_status
    {
        normal,
        isquest
    }
    public abstract void speak();
}


