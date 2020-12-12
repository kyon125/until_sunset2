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
        GameStatus.gameStatus.status = GameStatus.Status.onSaving;
        //抓取資料(玩家基本狀態)
        playerSave playerValue = new playerSave();
        playerValue.sceneName = SceneManager.GetActiveScene().name;
        playerValue.playerPos = GameObject.Find("An").transform.position;
        playerValue.theStatus = this.gameObject.GetComponent<GameStatus>().status.ToString();
        playerValue.playerLife = this.gameObject.GetComponent<GameStatus>().plaeyrstatus.life;
        //抓取資料(背包狀態)
        bagSave bagsave = new bagSave();
        bagsave.bagItemcount = PlayerBag.playerbag.bg.I_item.Count;
        bagsave.itemId = new List<int>();
        bagsave.itemNum = new List<int>();
        for (int i = 0; i < bagsave.bagItemcount; i++)
        {
            bagsave.itemId.Add(PlayerBag.playerbag.bg.I_item[i].id);
            bagsave.itemNum.Add(PlayerBag.playerbag.bg.I_num[i]);
        }

        //寫入(玩家基本狀態)
        PlayerPrefs.SetString("scene", playerValue.sceneName);
        PlayerPrefs.SetFloat("playerX", playerValue.playerPos.x);
        PlayerPrefs.SetFloat("playerY", playerValue.playerPos.y);
        PlayerPrefs.SetFloat("playerZ", playerValue.playerPos.z);
        PlayerPrefs.SetString("gameStatus", playerValue.theStatus.ToString());
        PlayerPrefs.SetFloat("playerLife", playerValue.playerLife);
        //寫入(背包狀態)
        PlayerPrefs.SetInt("bagitemnum", bagsave.bagItemcount);
        for (int i = 0; i < bagsave.bagItemcount; i++)
        {
            PlayerPrefs.SetInt("itemID"+i, bagsave.itemId[i]);
            PlayerPrefs.SetInt("itemNum"+ i, bagsave.itemNum[i]);
        }
        GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
    }
    public void load()
    {       
        StartCoroutine(clickTostart());
    }
    IEnumerator clickTostart()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onLoading;
        //讀取(玩家基本狀態)
        playerSave playerValue = new playerSave();
        playerValue.sceneName = PlayerPrefs.GetString("scene");
        playerValue.playerPos.x = PlayerPrefs.GetFloat("playerX");
        playerValue.playerPos.y = PlayerPrefs.GetFloat("playerY");
        playerValue.playerPos.z = PlayerPrefs.GetFloat("playerZ");
        playerValue.theStatus = PlayerPrefs.GetString("gameStatus");
        playerValue.playerLife = PlayerPrefs.GetFloat("playerLife");
        //讀取(背包狀態)
        bagSave bagsave = new bagSave();
        bagsave.itemId = new List<int>();
        bagsave.itemNum = new List<int>();
        bagsave.bagItemcount = PlayerPrefs.GetInt("bagitemnum");
        for (int i = 0; i < bagsave.bagItemcount; i++)
        {
            bagsave.itemId.Add(PlayerPrefs.GetInt("itemID" + i));
            bagsave.itemNum.Add(PlayerPrefs.GetInt("itemNum" + i));
        }

        //場景預載  
        scene = SceneManager.LoadSceneAsync(playerValue.sceneName);
        yield return new WaitUntil(() => scene.isDone);

        //附值(玩家基本狀態)  
        GameObject.Find("An").transform.position = playerValue.playerPos;
        this.gameObject.GetComponent<GameStatus>().status = (GameStatus.Status)System.Enum.Parse(typeof(GameStatus.Status), playerValue.theStatus);
        this.gameObject.GetComponent<GameStatus>().plaeyrstatus.life = playerValue.playerLife;

        //附值(背包狀態)
        PlayerBag.playerbag.bg = new c_bag();
        PlayerBag.playerbag.bg.I_item = new List<Itemclass>();
        PlayerBag.playerbag.bg.I_num = new List<int>();
        for (int i = 0; i < bagsave.bagItemcount; i++)
        {
            PlayerBag.playerbag.bg.I_item.Add(Itemdateset.itemdate[bagsave.itemId[i]]);
            PlayerBag.playerbag.bg.I_num.Add(bagsave.itemNum[i]);
        }
        GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
    }
}
public class playerSave
{
    public string sceneName;
    public Vector3 playerPos; 
    public string theStatus;
    public float playerLife;
}
public class bagSave
{
    public int bagItemcount;
    public List<int> itemId;
    public List<int> itemNum;
}

