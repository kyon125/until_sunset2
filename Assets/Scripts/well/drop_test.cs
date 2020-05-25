using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_test : MonoBehaviour
{
    public GameObject [] r;
    public float dt;
    private float time;
    private int a=0;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (start == true )
        {
            clear();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            Destroy(r[a]);
            time = 0;
            a++;
            start = true;
        }        
    }
    void clear()
    {
        if (a < r.Length-1 && time >= dt)
        {
            Destroy(r[a]);
            time = 0;
            a++;
        }  
        else if (a == r.Length-1 && time >= dt)
        {
            Destroy(r[a]);
            time = 0;
            Destroy(this.gameObject);
        }
    }
}
