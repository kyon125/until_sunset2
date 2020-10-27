using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igrone_rb : MonoBehaviour
{
    // Start is called before the first frame update
    public string tag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tag)
        {
            transform.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == tag)
        {
            transform.GetComponent<Collider2D>().enabled = true;
        }
    }
}
