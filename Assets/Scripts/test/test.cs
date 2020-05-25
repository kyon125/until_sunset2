using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject G1;
    private TilemapCollider2D t1;
    void Start()
    {
        t1 = G1.gameObject.GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (t1.enabled == false && collision.tag == "Player")
        {
            t1.enabled = true;
        }
        else if (t1.enabled == true && collision.tag == "Player")
        {
            t1.enabled = false;
        }
    }

}
