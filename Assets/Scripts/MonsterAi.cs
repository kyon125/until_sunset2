using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi : MonoBehaviour
{
    public Animator wolfAni;

    // 待機 , 追擊 , 攻擊的清單
    public enum Status { idle, chase, attack };
    public Status status;

    // 怪物面向
    public enum Face { Right, Left };
    public Face face;


    public float speed;
    public Transform monster;
    private SpriteRenderer spr;

    public Transform player;


    void Start()
    {
        wolfAni= GameObject.Find("Wolf (1)").GetComponent<Animator>();

        status = Status.idle;

        if (player.transform.position.x > monster.transform.position.x) 
        {
            face = Face.Left;
        }
        else
        {
            face = Face.Right;
        }
    }

    void Update()
    {
        float dTime = Time.deltaTime;
        

        switch (status)
        {
            case Status.idle:          
                if (Mathf.Abs(monster.position.x - player.position.x) < 5 && Mathf.Abs(monster.position.y - player.position.y) < 2)
                {
                    if (wolfAni.GetInteger("runW") == 0)
                        wolfAni.SetInteger("runW", 1);
                   
                    //-------咆哮動畫-------//

                    //-------咆哮動畫-------//
                    status = Status.chase;
                }
                break;

            case Status.chase:
                if (monster.position.x >= player.position.x)
                {
                    face = Face.Left;
                }
                else
                {
                    face = Face.Right;
                }

                switch (face)
                {
                    case Face.Left:
                        monster.transform.localScale = new Vector2(1, 1);
                        transform.position -= new Vector3(speed * dTime, 0, 0);
                        break;
                    case Face.Right:
                        monster.transform.localScale = new Vector2(-1, 1);
                        transform.position += new Vector3(speed * dTime, 0, 0);
                        break;
                }
                if (Mathf.Abs(monster.position.x - player.position.x) >= 6)
                {
                    if (wolfAni.GetInteger("runW") == 1)
                        wolfAni.SetInteger("runW", 0);
                    status = Status.idle;
                }
                break;
            case Status.attack:
                if (Mathf.Abs(monster.position.x - player.position.x) < 2)
                {

                    //-------攻擊-----//

                    //-------攻擊-----//

                }
                break;
        }
    }
}
