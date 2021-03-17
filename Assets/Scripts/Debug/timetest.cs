using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timetest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timechange();
    }
    void timechange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameStatus.gameStatus.gametime = GameStatus.Gametime.night;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            GameStatus.gameStatus.gametime = GameStatus.Gametime.morning;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GameStatus.gameStatus.gametime = GameStatus.Gametime.evening;
        }
    }
}
