using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deep_follow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private ParallaxBackground Parallax;

    private bool startmove = false;
    void Start()
    {
        Parallax = target.GetComponent<ParallaxBackground>();
        Parallax.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag =="Player")
            Parallax.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Parallax.enabled = false;
    }
}
