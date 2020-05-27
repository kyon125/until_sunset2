using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    public float power = 10;// 力量
    public float angle; // 角度
    public float Gravity = -10;// 重力加速度


    private Vector3 MoveSpeed;// 初速度向量
    private Vector3 GritySpeed = Vector3.zero;// 重力的速度向量
    private float dTime;// 時間
    private Vector3 currentAngle;

    //void Start()
    //{
    //    // 載入外部全域參數
    //    angle = ShootController.angle;

    //    // 初速度向量 = 角度 * 力量
    //    MoveSpeed = Quaternion.Euler(new Vector3(0, 0, ShootController.angle)) * Vector3.right * power;
    //    currentAngle = Vector3.zero;
    //}
    //void FixedUpdate()
    //{

    //    // 重力速度 = at ;
    //    GritySpeed.y = Gravity * (dTime += Time.fixedDeltaTime);
    //    // 位移模擬軌跡
    //    transform.position += (MoveSpeed + GritySpeed) * Time.fixedDeltaTime;
    //    currentAngle.z = Mathf.Atan((MoveSpeed.y + GritySpeed.y) / MoveSpeed.x) * Mathf.Rad2Deg;
    //    transform.eulerAngles = currentAngle;
    //}
}
