using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class hideTree : MonoBehaviour
{
    // Start is called before the first frame update
    bool isplayer;
    public SpriteRenderer sr;
    public Collider2D col;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer == true)
        {
            col.enabled = true;
            sr.DOFade(0.3f, 0.3f);
        }
        else
        {
            sr.DOFade(1f, 0.3f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = true;
        }
    }
}
