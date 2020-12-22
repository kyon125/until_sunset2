using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBriage : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;

    Vector2 startPos;

    private void Awake()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

        Destroy(this.gameObject, 4.0f);

        startPos = LineDrawer.startPos;
        hasHit = LineDrawer.hasHit;
        hasHit = false;
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
        startPos = this.gameObject.transform.position;
        LineDrawer.startPos = startPos;

        hasHit = true;
        LineDrawer.hasHit = hasHit;

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
