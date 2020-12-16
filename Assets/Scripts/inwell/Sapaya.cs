using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapaya : MonoBehaviour
{
    // Start is called before the first frame update
    bool isplayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer == true && Input.GetKeyDown(KeyCode.F))
        {
            PlayerBag.playerbag.removeitem(5, 1);
            GameStatus.gameStatus.mainquest = GameStatus.MainQuest.wellend;
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
}
