using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_Well_02 : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float time;
    private int a=0;
    public GameObject rock;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        shake();
    }
    void shake()
    {
        if (time >= 0.2 && a<8)
        {
            Instantiate(rock, new Vector3((-22.74f + a * 2.85f), -0.3f, 1), Quaternion.identity);
            time = 0;
            a++;
        }
    }    
}


interface rockdrop
{
    void droptime();
}
