using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class statusShow : MonoBehaviour
{
    // Start is called before the first frame update
    public static statusShow statusUI;
    int life , beforelife;
    public Transform UI_life;
    public Image IM_life, IM_endurance;
    public Material M_life;
    public List<Image> life_group;
    private void Awake()
    {
        intialLife();
    }
    void Start()
    {
        //Life 初始化        
    }

    // Update is called once per frame
    void Update()
    {
        life = (int)GameStatus.gameStatus.plaeyrstatus.life;
        if (life != beforelife)
        {
            showlife2();
        }
        beforelife = life;
    }
    void intialLife()
    {
        life = (int)GameStatus.gameStatus.plaeyrstatus.life;
        beforelife = life;
        for (int i = 0; i < UI_life.childCount; i++)
        {
            life_group.Add(UI_life.GetChild(i).GetComponent<Image>());
        }
    }
    public void showlife()
    {
        StartCoroutine(showlifeRim());
    }
    public void showlife2()
    {
        print("a");
        int i = Mathf.Abs(life - beforelife);
        int nowlife = beforelife;
        if (life - beforelife < 0)
        {
            StartCoroutine(lessLife(i , nowlife));
        }
        else if (life - beforelife > 0)
        {
            StartCoroutine(addLife(i, nowlife));
        }
    }
    IEnumerator showlifeRim()
    {
        DOTween.To(() => IM_life.fillAmount, x => IM_life.fillAmount = x, life, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5F);
    }
    IEnumerator lessLife(int i , int ie)
    {
        for (int a = 0; a < i; a++)
        {
            life_group[ie - (a+1)].fillAmount = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator addLife(int i, int ie)
    {
        for (int a = 0; a < i; a++)
        {
            life_group[ie + (a)].fillAmount = 1;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
