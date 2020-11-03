using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_falldown : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rock;
    public simplot plot;
    public int waittime;
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
            StartCoroutine(wait());
            Destroy(rock);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waittime);
    }
}
