using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cloudMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Direction direction;
    public Selftime selftime;
    public List<move> list;
    GameStatus.Gametime GT;
    void Start()
    {
        intial();
    }

    // Update is called once per frame
    void Update()
    {
        if (GT != GameStatus.gameStatus.gametime)
        {
            change();
            GT = GameStatus.gameStatus.gametime;
        }
        GT = GameStatus.gameStatus.gametime;
    }
    void intial()
    {
        switch (GameStatus.gameStatus.gametime)
        {
            case (GameStatus.Gametime.morning):
                {                    
                    selftime = Selftime.M;
                    gohead();
                    break;
                }
            case (GameStatus.Gametime.evening):
                {
                    selftime = Selftime.E;
                    gohead();
                    break;
                }
            case (GameStatus.Gametime.night):
                {
                    selftime = Selftime.N;
                    gohead();
                    break;
                }
        }
    }
    void change()
    {
        switch (GameStatus.gameStatus.gametime)
        {
            case (GameStatus.Gametime.morning):
                {
                    selftime = Selftime.M;
                    gohead();
                    break;
                }
            case (GameStatus.Gametime.evening):
                {
                    selftime = Selftime.E;
                    gohead();
                    break;
                }
            case (GameStatus.Gametime.night):
                {
                    selftime = Selftime.N;
                    gohead();
                    break;
                }
        }
    }
    void gohead()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].s == selftime)
            {
                transform.DOLocalMove(list[i].pos, list[i].time);
            }
        }
        
    }    
    public enum Direction
    {
        Horizontal,
        vertical
    }
    public enum Selftime
    {
        M,
        E,
        N
    }
    [System.Serializable]
    public class move
    {
        public Selftime s;
        public Vector3 pos;
        public float time;
    }
}
