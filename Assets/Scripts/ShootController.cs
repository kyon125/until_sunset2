using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    public GameObject slingshot; // 彈弓
    public float angle; // 角度
    public GameObject bullet; // 子彈
    public Transform ray;
    public Transform player;
    public Camera camera;

    //---------------------------------------------------------//
    private float crtForce = 0; // 當前的力
    private float minForce = 50; // 最小力
    private float maxForce = 200; // 最大力
    private float forceSpeed = 100; // 蓄力速度


    void Update()
    {
        lookAtMouse();

        ray.transform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButton(0))
        {
            ray.transform.localScale = new Vector3((crtForce / 120), 1 - (crtForce / 360), 1);
            crtForce += forceSpeed * Time.deltaTime; // 蓄力

            if (crtForce >= maxForce)
            {
                crtForce = maxForce;
                if (Input.GetMouseButtonUp(0))
                {
                    shoot();
                    crtForce = 50;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            shoot();
            ray.transform.localScale = new Vector3(1, 1, 1);
            crtForce = 50;
        }

        // 調整轉向箭頭貼圖錯誤的問題
        if (player.localScale.x > 0)
        {
            if (angle >= 90)
            {
                angle = 90;
            }
            slingshot.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (player.localScale.x < 0)
        {
            if (angle <= 85)
            {
                angle = 85;
            }
            slingshot.transform.localScale = new Vector3(-1, 1, 1);
        }

       // print(crtForce);
    }

    private void shoot()
    {
        GameObject _bullet = Instantiate(bullet, slingshot.transform.position, Quaternion.identity) as GameObject;
        Vector2 forceDir = new Vector2(Mathf.Cos(Mathf.PI * angle / 180), Mathf.Sin(Mathf.PI * angle / 180));
        _bullet.GetComponent<Rigidbody2D>().AddForce(forceDir * crtForce);
    }

    void lookAtMouse()
    {
        Vector3 dir = Input.mousePosition - camera.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
