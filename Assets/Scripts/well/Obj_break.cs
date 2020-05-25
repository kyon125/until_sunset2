using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_break : MonoBehaviour
{
    // Start is called before the first frame update
    public float break_time;
    private float time;
    private bool start;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            time += Time.deltaTime;
        }
        if (time >= break_time)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("aa");
        if (collision.tag == "Player")
        {
            start = true;
        }
    }
}
