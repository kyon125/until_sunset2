using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class creatCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject creat;
    public float t;
    float timer;
    void Start()
    {
        creatcloud();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= t)
        {
            creatcloud();
            timer = 0;
        }
    }
    void creatcloud()
    {
        Instantiate(creat ,transform.position ,Quaternion.identity);
    }
}
