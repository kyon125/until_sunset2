﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject GM;
    public static GameStatus gameStatus;
    public plaeyrStatus plaeyrstatus;
    public Status status;
    private void Awake()
    {
        DontDestroyOnLoad(this.transform.gameObject);
        if (GM == null)
        {
            GM = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
        gameStatus = this;
        status = new Status();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (plaeyrstatus.life <= 0 && status != GameStatus.Status.onGameover)
        {
            status = GameStatus.Status.onDead;
        }
        goDead();
    }
    void goDead()
    {
        if (status ==GameStatus.Status.onDead)
        {
            status = GameStatus.Status.onGameover;

            SceneManager.LoadScene("Gameover");            
        }
    }
    public void lifeController(float f)
    {
        plaeyrstatus.life += f;
        //statusShow.statusUI.showlife();
    }
    public enum Status
    {
        onPlaying,
        onMenu,
        onBaging,
        onComposition,
        onPloting,
        onSetting,
        onQuestchoose,
        onQuestlist,
        onDead,
        onGameover,
        onSaving,
        onLoading
    }
    [System.Serializable]
    public class plaeyrStatus
    {
        public float life;
        public float maxlife;
        public Vector3 pos;
    }
}