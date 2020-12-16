using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinesave : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> group = new List<GameObject>();
    string s_name;
    bool isload;
    void Start()
    {
        s_name = SceneManager.GetActiveScene().name;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            group.Add(this.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        load();
        save();
    }
    void load()
    {
        //假設有存檔，並執行了讀檔
        if (PlayerPrefs.HasKey(s_name + "cinenum") && GameStatus.gameStatus.archivestatus == GameStatus.ArchiveStatus.isLoad&&isload==false)
        {
            for (int i = 0; i < group.Count; i++)
            {
                group[i].SetActive(false);
            }
            group[PlayerPrefs.GetInt(s_name + "cinenum")].SetActive(true);
            isload = true;
        }
    }
    void save()
    {
        //當遊戲為存檔狀態時，進行存檔
        if (GameStatus.gameStatus.status == GameStatus.Status.onSaving)
        {
            for (int i = 0; i < group.Count; i++)
            {
                if (group[i].activeSelf == true)
                {
                    PlayerPrefs.SetInt(s_name + "cinenum", i);
                }
            }
        }
    }
}
