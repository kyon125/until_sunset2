using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc :MonoBehaviour
{
    public simplot dia;
    public string npc_name;
    public abstract void speak();
}


