using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        print("GURO");
    }
}
