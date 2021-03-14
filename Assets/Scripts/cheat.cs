using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saveGame.savecontroller.load();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameObject.Find("An").transform.position = new Vector3(1321, 101.3f, 0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            PlayerBag.playerbag.getitem(10, 1);
            PlayerBag.playerbag.getitem(11, 1);
            PlayerBag.playerbag.getitem(12, 1);
            PlayerBag.playerbag.getitem(13, 1);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            GameStatus.gameStatus.energyController(5);
        }
    }
}
