﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wq_1 : MonoBehaviour
{
    public simplot dia;
    public int start, end;
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
        if (collision.gameObject.tag == "Player")
        {
            print("a");
            dia.playdia(start, end);
        }
    }
}
