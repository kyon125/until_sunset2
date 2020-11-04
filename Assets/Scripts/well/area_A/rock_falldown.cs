using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_falldown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rock ,road;
    public simplot plot;
    public float waittime;
    public int s, n;
    void Start()
    {
        road.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(rock);
            StartCoroutine(wait());
            plot.playdia(s,n);
            this.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(wait());
            road.GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waittime);
    }
}
