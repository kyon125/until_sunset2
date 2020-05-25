using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Water_flat")
        {
            Physics2D.IgnoreCollision(this.transform.GetComponent<Collider2D>() , collision.transform.GetComponent<Collider2D>());
        }
    }
}
