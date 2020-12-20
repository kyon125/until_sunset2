using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class sim_Cine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject c1, c2;
    bool isplayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer == true)
        {
            c1.SetActive(false);
            c2.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isplayer = true;
        }
    }
}
