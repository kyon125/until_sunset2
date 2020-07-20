using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower_awake : MonoBehaviour
{
    // Start is called before the first frame update
    Sapaya_awake sapaya;
    simplot plot;
    private PlayerBag An_bag;
    private bool isflower = false;
    void Start()
    {
        sapaya = GameObject.Find("crystal_big").GetComponent<Sapaya_awake>();
        plot = GameObject.Find("PlotController").GetComponent<simplot>();
        An_bag = GameObject.Find("An").GetComponent<PlayerBag>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isflower ==true)
        {
            if (An_bag.bg.I_item.Contains(Itemdateset.itemdate[7]))
            {
                int n = An_bag.bg.I_item.IndexOf(Itemdateset.itemdate[7]);
                An_bag.bg.I_num[n]--;
                plot.playdia(62,62);
                goawake();
                Destroy(this.gameObject);
            }
            else
            {
                plot.playdia(61,61);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isflower = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isflower = false;
        }
    }
    void goawake()
    {
        if (sapaya.s1 == false && sapaya.s2 == false && sapaya.s3 == false)
        {
            sapaya.s1 = true;
        }
        else if (sapaya.s1 == true && sapaya.s2 == false && sapaya.s3 == false)
        {
            sapaya.s2 = true;
        }
        else if (sapaya.s1 == true && sapaya.s2 == true && sapaya.s3 == false)
        {
            sapaya.s3 = true;
        }
    }    
}
