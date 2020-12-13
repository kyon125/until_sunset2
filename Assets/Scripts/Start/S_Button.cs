using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject set;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void p_start()
    {
        Loadscene.loadcontroller.loadName = "Viliage";
        Loadscene.loadcontroller.changescene();
    }
    public void p_end()
    {
        Application.Quit();
    }

    public void p_set()
    {
        Instantiate(set);
    }
}
