using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class changeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 playepos;
    public bool isobj;
    bool isplayer;
    public GameStatus.MainQuest quest;
    public string scenename;
    Material m;
    Vector3 t_scale;
    public GameObject UI;

    void Start()
    {
        if (isobj == true)
        {
            t_scale = UI.transform.localScale;
            UI.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
            m = transform.GetComponent<SpriteRenderer>().material;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayer == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                change();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameStatus.gameStatus.mainquest == quest)
        {
            if (isobj == true)
            {
                playerEnter();
                isplayer = true;
            }
            else
            {
                change();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameStatus.gameStatus.mainquest == quest)
        {
            if (isobj == true)
            {
                playerLeave();
                isplayer = false;
            }
        }
    }

    void playerEnter()
    {
        UI.transform.DOScale(t_scale, 0.3f);
        m.SetFloat("outLine", 1);
    }
    void playerLeave()
    {
        UI.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        m.SetFloat("outLine", 0);
    }
    public void change()
    {
        //Loading.loading.loadstatus = Loading.Status.loading;
        GameObject.Find("An").GetComponent<CharacterController2D>().Rigidbody.isKinematic = true;
        Loadscene.loadcontroller.isportal = true;
        Loadscene.loadcontroller.loadName = scenename;
        Loadscene.loadcontroller.pos = playepos;
        SceneManager.LoadScene("Loading");
        //saveGame.savecontroller.save();            
    }
}
