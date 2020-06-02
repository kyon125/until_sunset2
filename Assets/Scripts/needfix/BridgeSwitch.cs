﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitch : MonoBehaviour
{
    public bool havenergy = false;
    private bool isswitch = false;
    public Animator b1, b2; 
    private simplot plot;
    // Start is called before the first frame update
    void Start()
    {
        plot = this.gameObject.GetComponent<simplot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isswitch == true)
        {
            if (havenergy == false)
            {
                plot.playdia();
            }
            else if (havenergy == true)
            {
                plot.start = 38;
                plot.end = 38;
                plot.playdia();
                b1.SetBool("switch", true);
                b2.SetBool("switch", true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isswitch = true;
        }
    }
}