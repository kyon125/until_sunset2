﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameStatus gameStatus;
    public plaeyrStatus plaeyrstatus;
    public Status status;
    void Start()
    {
        gameStatus = this;
        status = new Status();
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.transform.gameObject);

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
        onGameover
    }
    [System.Serializable]
    public class plaeyrStatus
    {
        public float life;
        public Vector3 pos;
    }
}
