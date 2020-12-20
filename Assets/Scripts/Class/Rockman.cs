using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockman : MonoBehaviour
{
    // Start is called before the first frame update
    Animator ani;
    public float time;
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
        StartCoroutine(waitfornai());
    }
    IEnumerator waitfornai()
    {
        switch (GameStatus.gameStatus.gametime)
        {
            case (GameStatus.Gametime.morning):
                {
                    yield return new WaitForSeconds(time);
                    ani.SetBool("isMorning", true);                    
                    ani.SetBool("isEvening", false);
                    ani.SetBool("isNight", false);
                    break;
                }
            case (GameStatus.Gametime.evening):
                {
                    yield return new WaitForSeconds(time);
                    ani.SetBool("isMorning", false);                    
                    ani.SetBool("isEvening", true);
                    ani.SetBool("isNight", false);
                    break;
                }
            case (GameStatus.Gametime.night):
                {
                    yield return new WaitForSeconds(time);
                    ani.SetBool("isMorning", false);
                    ani.SetBool("isEvening", false);
                    ani.SetBool("isNight", true);
                    break;
                }
        }
    }
}
