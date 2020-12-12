using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Loadscene : MonoBehaviour
{
    // Start is called before the first frame update\
    public static Loadscene loadcontroller;
    public string loadName;

    private void Awake()
    {
        loadcontroller = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changescene()
    {
        SceneManager.LoadScene("Loading");
    }
}
