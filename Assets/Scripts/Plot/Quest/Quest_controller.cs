using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_controller : MonoBehaviour
{
    public static Quest_controller questcontroller;
    public List<Quest_set> questlisting;
    public GameObject button;
    // Start is called before the first frame update
    private void Awake()
    {
        questcontroller = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddQuest(Quest_set quest)
    {
        for (int i = 0; i < questlisting.Count; i++)
        {
            if (questlisting[i].name == quest.name)
            {
                questlisting.RemoveAt(i);
            }
        }
        for (int i = 0; i < quest.next_quest.Count; i++)
        {
            questlisting.Add(quest.next_quest[i].quest);
        }        
    }
    public void creat_choosebutton(Quest_set quest)
    {
        GameObject b = Instantiate(button, GameObject.Find("Questcontent").transform);
        b.GetComponent<quest_button_set>().quest_status = quest;
    }
}
