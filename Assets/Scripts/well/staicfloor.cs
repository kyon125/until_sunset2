using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class staicfloor : MonoBehaviour
{
    // Start is called before the first frame update
    public floor_status f;
    public Collider2D c1,c2,c3;
    private float y1 , y2;
    
    public bool isup = false;
    
    void Start()
    {
        f = new floor_status();
        f = floor_status.F0;
    }

    // Update is called once per frame
    void Update()
    {
        y2 = GameObject.Find("An").transform.position.y - y1;
        if (y2 < 0)
        {
            isup = false;
        }
        else if (y2 > 0) 
        {
            isup = true;
        }
        y1 = GameObject.Find("An").transform.position.y;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (f)
        {
            case (floor_status.F0):
                {
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        c1.enabled = true;
                        f = floor_status.F1;
                    }
                    break;
                }
            case (floor_status.F3):
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        c2.enabled = true;
                        c3.enabled = false;
                        f = floor_status.F2;
                    }
                    break;
                }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (f)
        {
            case (floor_status.F0):
                {
                    break;
                }
            case (floor_status.F1):
                {
                    if (isup == true)
                    {
                        c2.enabled = true;
                        c1.enabled = false;
                        f = floor_status.F2;
                    }
                    else if (isup == false)
                    {
                        c1.enabled = false;
                        f = floor_status.F0;
                    }
                    break;
                }
            case (floor_status.F2):
                {
                    if (isup == true)
                    {
                        c3.enabled = true;
                        c2.enabled = false;
                        f = floor_status.F3;
                    }
                    else if (isup == false)
                    {
                        c1.enabled = true;
                        c2.enabled = false;
                        f = floor_status.F1;
                    }                    
                    break;
                }
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (tg.enabled == false && t2.enabled == true)
    //    {
    //        tg.enabled = true;
    //    }
    //}
    public enum floor_status
    {
        F0,
        F1,
        F2,
        F3
    }
}
