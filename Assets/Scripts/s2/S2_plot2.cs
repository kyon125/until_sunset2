using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_plot2 : MonoBehaviour
{
    public int s, s1, s2, e, e1, e2;
    // Start is called before the first frame update
    bool isplayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = false;
        }
    }
}
