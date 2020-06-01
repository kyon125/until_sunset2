using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Con_door : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator ani;

    void Start()
    {
        ani = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            print("HIT");
            ani.SetBool("break", true);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
