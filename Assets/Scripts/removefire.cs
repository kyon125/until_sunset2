﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removefire : MonoBehaviour
{
    public Addfire fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" ) 
        {
             Destroy(GameObject.Find("newfire"));
        }
    }
}
