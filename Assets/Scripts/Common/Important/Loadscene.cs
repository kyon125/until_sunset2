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
    public GameObject UI;
    public bool isportal;
    public Vector3 pos;
    public AsyncOperation async;
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
        //potarl();
        if (SceneManager.GetActiveScene().name != "Start" && SceneManager.GetActiveScene().name != "Loading")
        {
            UI.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Start" || SceneManager.GetActiveScene().name == "Loading")
        {
            UI.SetActive(false);
        }
        onloading();
    }
    public void onloading()
    {
        
    }
    public void changescene()
    {        
        SceneManager.LoadScene("Loading");        
    }
     public void potarl()
    {
        //if (Loadscene.loadcontroller.isportal == true && Loading.loading.loadstatus == Loading.Status.completed)
        //{

        //}
        StartCoroutine(test());
    }
    IEnumerator test()
    {
        yield return new WaitForEndOfFrame();
        GameObject.Find("An").transform.position = Loadscene.loadcontroller.pos;
        print("chan");
        print(GameObject.Find("An").transform.position);
        Loadscene.loadcontroller.isportal = false;
        CharacterController2D.chara.Rigidbody.isKinematic = false;
    }

}
