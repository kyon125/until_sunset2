using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;


    private void Awake()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject, 0.5f);
    }
}