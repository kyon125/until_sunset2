using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cloudMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Direction direction;
    public float distant, time;
    SpriteRenderer sp;
    float timer;
    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
        move();        
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        if (timer > time - 0.5f)
        {
            sp.DOFade(0, 0.5f);
        }
        if (timer > time)
        {
            Destroy(this.gameObject);
        }
    }
    void move()
    {
        sp.DOFade(1, 1f);
        switch (direction)
        {
            case (Direction.Horizontal):
                {
                    transform.DOBlendableMoveBy(new Vector3(distant, 0, 0), time);
                    break;
                }
            case (Direction.vertical):
                {
                    transform.DOBlendableMoveBy(new Vector3(0, distant, 0), time);
                    break;
                }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.parent = GameObject.Find("GameController").transform;
        }
    }
    public enum Direction
    {
        Horizontal,
        vertical
    }
}
