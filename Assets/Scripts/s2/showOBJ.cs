using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showOBJ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject morning, evening, night;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        show();       
    }
    void show()
    {
        switch (GameStatus.gameStatus.gametime)
        {
            case (GameStatus.Gametime.morning):
                {
                    morning.SetActive(true);
                    evening.SetActive(false);
                    night.SetActive(false);
                    break;
                }
            case (GameStatus.Gametime.evening):
                {
                    morning.SetActive(false);
                    evening.SetActive(true);
                    night.SetActive(false);
                    break;
                }
            case (GameStatus.Gametime.night):
                {
                    morning.SetActive(false);
                    evening.SetActive(false);
                    night.SetActive(true);
                    break;
                }
        }
    }
}
