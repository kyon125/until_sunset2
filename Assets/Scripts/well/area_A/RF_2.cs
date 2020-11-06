using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RF_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Rigidbody2D> rb;
    public Rigidbody2D RB2;
    void Start()
    {
        for (int i = 0; i < rb.Count; i++)
        {
            rb[i].isKinematic = true;            
        }
        RB2.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "stayflat")
        {
            for (int i = 0; i < rb.Count; i++)
            {
                rb[i].isKinematic = false;
            }
            StartCoroutine(wait());
            RB2.isKinematic = false;
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5F);
    }
}
