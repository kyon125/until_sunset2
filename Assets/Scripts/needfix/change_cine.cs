using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_cine : MonoBehaviour
{
    public List<GameObject> cam;
    public GameObject cam_a, cam_s, cam_e;

    public static change_cine cine;
    private bool back = false;
    void Start()
    {
        cine = this;
        cam = new List<GameObject>();
        for (int i = 0; i <= cam_a.transform.childCount - 1; i++)
        {
            cam.Add(cam_a.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&　back == false)
        {
            for (int i = 0; i <= cam.Count-1; i++)
            {
                cam[i].SetActive(false);
            }

            back = true;
            cam_s.SetActive(true);
        }
        else if (collision.tag == "Player" && back == true)
        {
            for (int i = 0; i <= cam.Count - 1; i++)
            {
                cam[i].SetActive(false);
            }

            back = false;
            cam_e.SetActive(true);
        }
    }
}
