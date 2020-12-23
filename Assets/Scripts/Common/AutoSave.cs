using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    // Start is called before the first frame update
    public bool istrigger;
    private void Awake()
    {
        
    }
    void Start()
    {
        if(istrigger == false)
        saveGame.savecontroller.save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            saveGame.savecontroller.save();
            GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.tag == "Player")
        //{
        //    saveGame.savecontroller.save();
        //    GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
        //}
    }
}
