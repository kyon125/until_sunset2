using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas cm = this.transform.GetComponent<Canvas>();
        cm.worldCamera = GameObject.Find("bigcamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    