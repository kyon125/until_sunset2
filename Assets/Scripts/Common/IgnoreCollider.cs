using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> igrone_Tag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < igrone_Tag.Count; i++)
        {
            if (collision.transform.tag == igrone_Tag[i])
            {
                Physics2D.IgnoreCollision(this.transform.GetComponent<Collider2D>(), collision.transform.GetComponent<Collider2D>());
            }
        }
    }        
}
