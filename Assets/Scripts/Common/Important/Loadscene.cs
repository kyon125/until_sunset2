﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Loadscene : MonoBehaviour
{
    // Start is called before the first frame update\
    public static Loadscene loadcontroller;
    public string loadName;
    public GameObject UI;
    public bool isportal;
    public Vector3 pos;
    public AsyncOperation async;
    private void Awake()
    {
        loadcontroller = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterController2D.chara == true)
        {
            UI.SetActive(true);
        }
        else if (CharacterController2D.chara == false)
        {
            UI.SetActive(false);
        }
        onloading();
    }
    public void onloading()
    {
        
    }
    public void changescene()
    {        
        SceneManager.LoadScene("Loading");        
    }
}
