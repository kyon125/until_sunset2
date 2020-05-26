using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_cine : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> cam;
    public GameObject cam_s;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i <= cam.Count-1; i++)
            {
                cam[i].SetActive(false);
            }

            cam_s.SetActive(true);
        }
    }
}
