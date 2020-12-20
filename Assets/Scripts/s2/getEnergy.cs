using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getEnergy : MonoBehaviour
{
    // Start is called before the first frame update
    public int s, e;
    bool isplayer;
    bool hasenergy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getenergy();
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
    void getenergy()
    {
        if (Input.GetKeyDown(KeyCode.F) && isplayer == true)
        {
            if (hasenergy == true)
            {
                simplot.plotPlay.playdia(s, e);
                hasenergy = false;
                GameStatus.gameStatus.energyController(1);
            }
        }
    }
}

