using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveGame : MonoBehaviour
{
    // Start is called before the first frame update
    AsyncOperation scene;
    void Start()
    {
        //if (scene == null)
        //{
        //    scene = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("scene"));
        //    scene.allowSceneActivation = false;
        //}        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            save();
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            load();
        }
    }
    public void save()
    {
        //抓取資料
        playerSave playerValue = new playerSave();
        playerValue.sceneName = SceneManager.GetActiveScene().name;
        playerValue.playerPos = GameObject.Find("An").transform.position;
        playerValue.theStatus = this.gameObject.GetComponent<GameStatus>().status.ToString();
        playerValue.playerLife = this.gameObject.GetComponent<GameStatus>().plaeyrstatus.life;

        //寫入
        PlayerPrefs.SetString("scene", playerValue.sceneName);
        PlayerPrefs.SetFloat("playerX", playerValue.playerPos.x);
        PlayerPrefs.SetFloat("playerY", playerValue.playerPos.y);
        PlayerPrefs.SetFloat("playerZ", playerValue.playerPos.z);
        PlayerPrefs.SetString("gameStatus", playerValue.theStatus.ToString());
        PlayerPrefs.SetFloat("playerLife", playerValue.playerLife);
        
    }
    public void load()
    {       
        StartCoroutine(clickTostart());
    }
    IEnumerator clickTostart()
    {
        //讀取
        playerSave playerValue = new playerSave();
        playerValue.sceneName = PlayerPrefs.GetString("scene");
        playerValue.playerPos.x = PlayerPrefs.GetFloat("playerX");
        playerValue.playerPos.y = PlayerPrefs.GetFloat("playerY");
        playerValue.playerPos.z = PlayerPrefs.GetFloat("playerZ");
        playerValue.theStatus = PlayerPrefs.GetString("gameStatus");
        playerValue.playerLife = PlayerPrefs.GetFloat("playerLife");
        //場景預載  
        scene = SceneManager.LoadSceneAsync(playerValue.sceneName);
        //附值     
        yield return new WaitUntil(() => scene.isDone);
        GameObject.Find("An").transform.position = playerValue.playerPos;
        this.gameObject.GetComponent<GameStatus>().status = (GameStatus.Status)System.Enum.Parse(typeof(GameStatus.Status), playerValue.theStatus);
        this.gameObject.GetComponent<GameStatus>().plaeyrstatus.life = playerValue.playerLife;
    }
}
public class playerSave
{
    public string sceneName;
    public Vector3 playerPos; 
    public string theStatus;
    public float playerLife;
}
