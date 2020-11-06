using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addfire : MonoBehaviour
{
    // Start is called before the first frame update
    public simplot sim;
    public GlobalLightContral gl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.tag == "Player")
        {
            //gl.ls = Ls.ing;
            reaction();
            gl.add();
            gl.dis();
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
    public void reaction()
    {
        sim.playdia(77, 77);
    }
}
