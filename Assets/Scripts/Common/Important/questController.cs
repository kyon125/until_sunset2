using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questController : MonoBehaviour
{
    // Start is called before the first frame update
    public static questController questcontroller;
    public List<Quest_set> questinglist;
    void Start()
    {
        questcontroller = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
