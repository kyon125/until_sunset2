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
    float bepos;
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
        bepos = transform.position.x;
    }
    void move()
    {
        sp.DOFade(1, 1f);
        switch (direction)
        {
            case (Direction.Horizontal):
                {
                    transform.parent.DOBlendableMoveBy(new Vector3(distant, 0, 0), time).SetEase(Ease.InOutSine);
                    break;
                }
            case (Direction.vertical):
                {
                    transform.parent.DOBlendableMoveBy(new Vector3(0, distant, 0), time).SetEase(Ease.InOutSine);
                    break;
                }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SetParent(transform.parent, true);           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SetParent(GameObject.Find("GameController").transform, true);
        }
    }
    public enum Direction
    {
        Horizontal,
        vertical
    }
}
