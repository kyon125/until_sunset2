using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer r;
    public Material m1, m2;
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
