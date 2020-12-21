using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinebrainCon : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    private void Awake()
    {
        cam = transform.GetComponent<Camera>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Start" && SceneManager.GetActiveScene().name != "Loading")
        {
            cam.enabled = true;
        }
        else
        {
            cam.enabled = false;
        }
    }
}
