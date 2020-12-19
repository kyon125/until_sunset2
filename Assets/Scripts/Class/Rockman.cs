using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockman : MonoBehaviour
{
    // Start is called before the first frame update
    Animator ani;
    void Start()
    {
        ani = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        aniset();
    }
    void aniset()
    {
        switch (GameStatus.gameStatus.gametime)
        {
            case (GameStatus.Gametime.morning):
                {
                    ani.SetBool("isMorning", true);
                    break;
                }
            case (GameStatus.Gametime.evening):
                {
                    ani.SetBool("isEvening", true);
                    break;
                }
            case (GameStatus.Gametime.night):
                {
                    ani.SetBool("isMorning", false);
                    ani.SetBool("isEvening", false);
                    ani.SetBool("isNight", true);
                    break;
                }
        }
    }
}
