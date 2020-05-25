using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{

    public GameObject slingshot; // 彈弓
    public static float angle = 60f; // 角度
    public GameObject bullet; // 子彈
    public Transform rayPic;
    public float power = 500f;
    public GameObject rayL;


    void Start()
    {
       rayPic.eulerAngles = new Vector3(0, 0, angle);       
    }

    // Update is called once per frame
    void Update()
    {
        shootControllor();
    }

    private void shootControllor()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rayL.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shoot(power);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            rayL.SetActive(false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (slingshot)
            {
                angle += 0.5f;
                angle = angle % 360;
            }
            else
            {
                angle -= 0.5f;
                angle = angle % 360;
            }
            rayPic.eulerAngles = new Vector3(0, 0, angle);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!slingshot)
            {
                angle += 0.5f;
                angle = angle % 360;
            }
            else
            {
                angle -= 0.5f;
                angle = angle % 360;
            }
            rayPic.eulerAngles = new Vector3(0, 0, angle);
        }
    }
    private void shoot(float power)
    {
        GameObject _bullet = Instantiate(bullet, slingshot.transform.position, Quaternion.identity) as GameObject;
        Vector2 forceDir = new Vector2(Mathf.Cos(Mathf.PI * angle / 180), Mathf.Sin(Mathf.PI * angle / 180));
        _bullet.GetComponent<Rigidbody2D>().AddForce(forceDir * power);
    }

}
