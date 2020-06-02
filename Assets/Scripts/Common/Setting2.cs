using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Setting2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject set ,set2,obj_voice , obj_guide;

    private AudioClip adiuo;
    private GameStatus gameStatus;
    private setstatus Setstatus;
    void Start()
    {        
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        Setstatus = new setstatus();
        Setstatus = setstatus.onseting;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameStatus.status == GameStatus.Status.onPlaying)
        {
            gameStatus.status = GameStatus.Status.onSetting;
            set2 = Instantiate(set);
            Tween t = GameObject.Find("menu").transform.DOScaleY(1f, 0.3f);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && gameStatus.status == GameStatus.Status.onSetting)
        {
            gameStatus.status = GameStatus.Status.onPlaying;
            Destroy(set2);
        }
    }
    public void voice()
    {
        Setstatus = setstatus.onvoice;
        select();
    }
    public void guide()
    {
        Setstatus = setstatus.onguide;
        select();
    }
    public void end()
    {
        SceneManager.LoadScene("Start");
    }
    public void closs() 
    {
        Setstatus = setstatus.onseting;
        gameStatus.status = GameStatus.Status.onPlaying;
        Destroy(this.gameObject);
    }
    void select()
    {
        switch (Setstatus)
        {
            case (setstatus.onvoice):
                {
                    obj_voice.SetActive(true);
                    obj_guide.SetActive(false);
                    Tween t = obj_voice.transform.DOMoveX(1358.4f, 0.5f);
                    Tween t2 = obj_guide.transform.DOMoveX(621.4F, 0.5f);
                    break;
                }
            case (setstatus.onguide):
                {
                    obj_voice.SetActive(false);
                    obj_guide.SetActive(true);
                    Tween t = obj_voice.transform.DOMoveX(621.4f, 0.5f);
                    Tween t2 = obj_guide.transform.DOMoveX(1358.4F, 0.5f);
                    break;
                }
                //case (setstatus.onseting):
                //    {
                //        obj_voice.SetActive(false);
                //        obj_guide.SetActive(false);
                //        break;
                //    }
        }
    }
}
public enum setstatus
{
    onseting,
    onvoice,
    onguide,
}
