using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class Setting2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject set ,obj_voice , obj_guide;
    public  Scrollbar vol, light;
    private AudioSource audio;
    private Light2D globallight;
    private GameStatus gameStatus;
    private setstatus Setstatus;
    
    void Start()
    {        
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        audio = GameObject.Find("Sound_Controller").GetComponent<AudioSource>();
        globallight = GameObject.Find("Global Light 2D").GetComponent<Light2D>();
        

        Setstatus = new setstatus();
        Setstatus = setstatus.onseting;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameStatus.status == GameStatus.Status.onPlaying)
        {            
            gameStatus.status = GameStatus.Status.onSetting;
            set.SetActive(true);
            vol.enabled = true;
            light.enabled = true;
            vol.value = audio.volume;
            light.value = globallight.intensity;
            Tween t = GameObject.Find("menu").transform.DOScaleY(1f, 0.3f);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameStatus.status == GameStatus.Status.onSetting)
        {
            vol.enabled = false;
            light.enabled = false;
            gameStatus.status = GameStatus.Status.onPlaying;
            Tween t = GameObject.Find("menu").transform.DOScaleY(0F, 0.3f);
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
        Tween t = GameObject.Find("menu").transform.DOScaleY(0F, 0.3f);
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
        }
    }
    public void value()
    {
        audio.volume = vol.value;
        globallight.intensity = light.value;
    }
}
public enum setstatus
{
    onseting,
    onvoice,
    onguide,
}
