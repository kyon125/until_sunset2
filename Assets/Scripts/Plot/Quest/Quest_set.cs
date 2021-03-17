using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest_set
{
    public string name;
    public Vector2 start_plot;

    public bool accept;

    public bool haveitem;

    public Vector2 accept_plot;
    public Vector2 refuse_plot;

    public goal_type goal;
    public queststatus status;
    public int itemid, itemnum;
    public string traget_NPC;

    public List<Quest_scriptable> next_quest;
}
public enum goal_type
{ 
    searchNpc,
    haveItem
}
public enum queststatus
{
    noStart,
    isQuesting,
    isQuestedButNoFinshed,
    isFinshed
}
