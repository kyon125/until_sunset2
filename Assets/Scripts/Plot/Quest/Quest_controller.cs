using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_controller : MonoBehaviour
{
    public CharacterController2D An;
    public List<Quest_set> questlist;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void creat_choosebutton(Quest_set quest)
    {
        GameObject b = Instantiate(button, GameObject.Find("Questcontent").transform);
        b.GetComponent<quest_button_set>().quest_status = quest;
    }
}
