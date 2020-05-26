using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_animation : MonoBehaviour
{
    public GameObject obj;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = obj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.tag == "Player")
        {
            ani.SetBool("switch", true);
        }
    }
}
