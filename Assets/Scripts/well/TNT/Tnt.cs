﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tnt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject d_obj;
    public bool ishug;
    public DistanceJoint2D h_obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(d_obj);
        }
        if (ishug)
        {
            h_obj.enabled = false;
        }
    }
}
