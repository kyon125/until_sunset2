using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotate : MonoBehaviour
{
    void Update()
    {
        if (transform.GetComponent<Rigidbody>() != null)
        {
            if (GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                Vector3 vel = GetComponent<Rigidbody>().velocity;

                float angleZ = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;

                float angleY = Mathf.Atan2(vel.z, vel.x) * Mathf.Rad2Deg;

                transform.eulerAngles = new Vector3(0, -angleY, angleZ);
            }
        }
    }
}