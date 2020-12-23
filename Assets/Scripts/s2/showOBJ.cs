using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showOBJ : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject morning, evening, night;
    public Color M, E, N;
    Camera cam;
    void Start()
    {
        cam = GameObject.Find("Bigcamera").GetComponent<Camera>();
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
                    evening.SetActive(false);
                    night.SetActive(false);
                    morning.SetActive(true);
                    cam.backgroundColor = M;
                    break;
                }
            case (GameStatus.Gametime.evening):
                {
                    morning.SetActive(false);                    
                    night.SetActive(false);
                    evening.SetActive(true);
                    cam.backgroundColor = E;
                    break;
                }
            case (GameStatus.Gametime.night):
                {
                    morning.SetActive(false);
                    evening.SetActive(false);
                    night.SetActive(true);
                    cam.backgroundColor = N;
                    break;
                }
        }
    }    
}
