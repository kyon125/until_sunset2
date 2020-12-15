using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusSet : MonoBehaviour
{
    public bool ismainquest;
    public GameStatus.MainQuest main;
    public bool iscine;
    public GameObject cine1, cine2;
    bool isplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ismainquest == true && isplayer == true)
        {
            changemain();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = false;
        }
    }
    void changemain()
    {
        GameStatus.gameStatus.mainquest = main;
        ismainquest = false;
    }
}
