using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Addfire : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 60;
    float intiallight;
    bool start;
    public Light2D light2;
    public Transform An;
    void Start()
    {
        An = GameObject.Find("An").transform;
        intiallight = light2.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true && GameStatus.gameStatus.status == GameStatus.Status.onPlaying)
        {
            this.transform.position = An.position;
            timer -= Time.deltaTime;
        }
        light2.intensity = intiallight * (timer / 60);
        if (light2.intensity <= 0)
        {
            GameStatus.gameStatus.status = GameStatus.Status.onDead;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (start == false && collision.tag == "Player")
        {
            transform.SetParent(An);
            this.transform.position = An.position;
            simplot.plotPlay.playdia(359, 360);
            start = true;
        }
    }
}
