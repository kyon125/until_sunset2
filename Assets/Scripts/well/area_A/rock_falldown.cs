using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_falldown : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public simplot plot;
    public float waittime;
    public int s, n;
    void Start()
    {
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {            
            StartCoroutine(wait());
            simplot.plotPlay.playdia(s, n);
            rb.isKinematic = false;
            this.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(wait());
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waittime);
    }
}
