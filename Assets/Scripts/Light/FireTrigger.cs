using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireTrigger : MonoBehaviour
{
    public Light2D globalLight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fire") 
        {
            globalLight.intensity = 1.0f;
        }
    }
}
