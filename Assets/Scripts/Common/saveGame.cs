using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void save(playerSave playerValue)
    {
        PlayerPrefs.SetString("scene", playerValue.sceneName);
    }
}
public class playerSave
{
    public string sceneName;
    public Vector3 playerPos; 
}
