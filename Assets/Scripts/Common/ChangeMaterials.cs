using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeMaterials : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer r;
    public Material m1, m2;
    public GameObject icon;
    public Vector3 iconscale;
    GameStatus gameStatus;
    void Start()
    {
        r = this.gameObject.GetComponent<SpriteRenderer>();
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameStatus.status == GameStatus.Status.onPlaying)
        {
            if (collision.gameObject.tag == "Player")
            {
                Tween t = icon.transform.DOScale(iconscale, 0.2f);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameStatus.status == GameStatus.Status.onPlaying)
        {
            if (collision.gameObject.tag == "Player")
            {
                go_change();
            }
        }
        print("aaaa");        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameStatus.status == GameStatus.Status.onPlaying)
        {
            if (collision.gameObject.tag == "Player")
            {
                re_change();
                Tween t = icon.transform.DOScale(new Vector2(0f, 0f), 0.2f);
            }
        }        
    }
    void go_change()
    {
        r.material = m2;
    }
    void re_change()
    {
        r.material = m1;
    }
}
