using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "quest_data"  , menuName = "scriptable_quest/quest")]
[System.Serializable]
public class Quest_scriptable :ScriptableObject
{    
    public Quest_set quest;
}
