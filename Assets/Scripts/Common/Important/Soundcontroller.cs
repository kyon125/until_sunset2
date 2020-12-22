using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Soundcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioSource> adList;
    public static Soundcontroller soundcontroller;
    public Transform sound;
    private string s_name;
    int num;
    public bool start;
    private void Awake()
    {
        soundcontroller = this;
    }
    void Start()
    {
        intial();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start" && start == false)
        {
            start = true;
            intial();
        }
    }
    void intial() 
    {
        stopbgm();
        adList[0].Play();
        adList[0].volume = 0;
        DOTween.To(() => adList[0].volume, x => adList[0].volume = x, 0.3f, 1.5f).SetEase(Ease.Linear);
    }
    public void playbgm()
    {        
        s_name = Loadscene.loadcontroller.loadName;
        stopbgm();
        
        for (int i = 0; i < adList.Count; i++)
        {
            if (adList[i].transform.name == s_name)
            {
                num = new int();
                num = i;
            }
        }
        adList[num].Play();
        adList[num].volume = 0;
        DOTween.To(() => adList[num].volume, x => adList[num].volume = x, 0.3f, 1.5f).SetEase(Ease.Linear);
    }
    public void stopbgm()
    {
        for (int i = 0; i < adList.Count; i++)
        {
            print(i);
            adList[i].Stop();
        }
    }
}
