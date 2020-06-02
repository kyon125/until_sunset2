using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class guide_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    simplot plot;
    void Start()
    {
        plot = this.gameObject.GetComponent<simplot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            plot.playdia();
        }
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
