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
    private string s_name;
    int num;
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
        
    }
    void intial() 
    {
        adList[0].Play();
        adList[0].volume = 0;
        DOTween.To(() => adList[0].volume, x => adList[0].volume = x, 0.5f, 1.5f).SetEase(Ease.Linear);
    }
    public void playbgm()
    {
        
        s_name = Loadscene.loadcontroller.loadName;
        print(s_name);
        stopbgm();
        for (int i = 0; i < adList.Count; i++)
        {
            if (adList[i].transform.name == s_name)
            {
                num = i;
            }
        }
        print(num);
        adList[num].Play();
        adList[num].volume = 0;
        DOTween.To(() => adList[num].volume, x => adList[num].volume = x, 0.5f, 1.5f).SetEase(Ease.Linear);

    }
    public void stopbgm()
    {
        for (int i = 0; i < adList.Count; i++)
        {
            adList[i].Stop();
        }
    }
}
