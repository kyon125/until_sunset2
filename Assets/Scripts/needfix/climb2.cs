using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climb2 : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController2D an;
    bool climb = false;
    void Start()
    {
        an = GameObject.Find("An").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (an.isClimb == true && an.isGrounded == false && Input.GetKey(KeyCode.UpArrow))
        {
            climb = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            climb = false;
        }

        if (climb == true)
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
        else if (climb == false)
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
