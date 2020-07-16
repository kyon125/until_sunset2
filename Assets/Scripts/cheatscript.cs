using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam, cam1, cam2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameObject.Find("An").transform.position = new Vector3(161,-43 , 0);
            cam.SetActive(false);
            cam1.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            GameObject.Find("An").transform.position = new Vector3(206, -78, 0);
            cam.SetActive(false);
            cam2.SetActive(true);
        }
    }
    
}
