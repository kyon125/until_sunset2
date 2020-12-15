using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    bool shot = false;
    bool canRotate;
    Vector3 mousePosition;

    public Camera camera;
    public GameObject shotPos;
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    public GameObject bow;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    public GameObject player;

    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }

        StartCoroutine("hidePoints");
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        rotateLim();

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine("bowUse");
        }

        if ((player.transform.localScale.x > 0 && direction.x < 0) || (player.transform.localScale.x < 0 && direction.x > 0))
        {
            canRotate = false;
        }
        else
        {
            canRotate = true;
        }

        if (canRotate == true)
        {
            shotPos.transform.position = mousePosition;
            Shoot();

            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].transform.position = PonitPosition(i * spaceBetweenPoints);
            }
        }
        //print(direction);
    }

    void faceMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = camera.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.right = direction;
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && shot)
        {
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }
    }

    private void rotateLim()
    {
        // bow校正
        if (player.transform.localScale.x > 0)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        // bow校正
        else if (player.transform.localScale.x < 0)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    Vector2 PonitPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    IEnumerator bowUse()
    {
        yield return null;

        if (shot == false)
        {
            shot = true;
            bow.SetActive(true);
            for (int i = 0; i < numberOfPoints; i++)
                points[i].GetComponent<SpriteRenderer>().enabled = true;

        }
        else if (shot == true)
        {
            shot = false;
            bow.SetActive(false);
            for (int i = 0; i < numberOfPoints; i++)
                points[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator hidePoints()
    {
        yield return (1);

        for (int i = 0; i < numberOfPoints; i++)
            points[i].GetComponent<SpriteRenderer>().enabled = false;
    }
}
