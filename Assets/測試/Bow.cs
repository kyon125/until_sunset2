using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject player;
    public bool canRotate;
    Vector2 mousePosition;

    public Camera camera;
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 dircetion;

    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    void Update()
    {
        Vector2 bowPosition = transform.position;
        mousePosition = Input.mousePosition;
        dircetion = mousePosition - bowPosition;


        if ((player.transform.localScale.x > 0 && dircetion.x < 0)|| (player.transform.localScale.x < 0 && dircetion.x > 0))
        {
            canRotate = false;
        }
        else
        {
            canRotate = true;
        }

        if (canRotate == true)
        {
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);         
            transform.right = dircetion;

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }

            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PonitPosition(i * spaceBetweenPoints);
            }
        }
    }

    private void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);   
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;


    }

    Vector2 PonitPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (dircetion.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
