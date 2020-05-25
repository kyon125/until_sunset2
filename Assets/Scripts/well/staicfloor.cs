using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class staicfloor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject G1, G2 , GF;
    private Collider2D t1, t2 ,tg;
    private GameObject an;
    private float f1 ,f2 , dis;
    public bool upstaic = false;
    void Start()
    {
        t1 = G1.gameObject.GetComponent<EdgeCollider2D>();
        t2 = G2.gameObject.GetComponent<EdgeCollider2D>();
        tg = GF.gameObject.GetComponent<EdgeCollider2D>();
        an = GameObject.Find("An");
        f2 = an.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        f1 = an.transform.position.y;         
        dis = f1 - f2;            
        f2 = an.transform.position.y;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (t1.enabled == false && Input.GetKeyDown(KeyCode.UpArrow))
        {
            t1.enabled = true;
        }
        else if (tg.enabled == true && Input.GetKeyDown(KeyCode.DownArrow))
        {
            t2.enabled = true;
            tg.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dis >= 0)
        {
            if (t1.enabled == true)
            {
                t2.enabled = true;
                t1.enabled = false;
            }
            else if (t2.enabled == true)
            {
                tg.enabled = true;
                t2.enabled = false;
            }
        }

        else if (dis < 0)
        {
            if (t2.enabled == true)
            {
                t1.enabled = true;
                t2.enabled = false;
            }
            else if (t1.enabled == true)
            {
                t1.enabled = false;
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
}
