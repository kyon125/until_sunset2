using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    public string loadname;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (loadname != "" && collision.tag =="player")
            loadscene();
    }
    void loadscene()
    {
        SceneManager.LoadScene(loadname);
    }
}
