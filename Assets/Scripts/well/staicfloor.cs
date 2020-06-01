using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class staicfloor : MonoBehaviour
{
    // Start is called before the first frame update
    floor_status f;
    
    private bool instaic = false;
    void Start()
    {
        f = new floor_status();
        f = floor_status.F0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (f)
        {
            case (floor_status.F0):
            {
                break;
            }
            case (floor_status.F1):
            {
                break;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }    
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (tg.enabled == false && t2.enabled == true)
    //    {
    //        tg.enabled = true;
    //    }
    //}
    enum floor_status
    {
        F0,
        F1,
        F2,
        F3
    }
}
