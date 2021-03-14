using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class statusShow : MonoBehaviour
{
    // Start is called before the first frame update
    public static statusShow statusUI;
    int life , beforelife, energy , beforenergy,  endurance, beforendurance;
    public Transform UI_life , UI_endurance, UI_energy;
    public Image IM_life, IM_endurance;
    public Material M_life;
    public List<Image> life_group;
    public List<Image> endurance_group;
    public List<Image> energy_group;
    private void Awake()
    {
        intial();
    }
    void Start()
    {
        //Life 初始化        
    }

    // Update is called once per frame
    void Update()
    {
        life = (int)GameStatus.gameStatus.plaeyrstatus.life;
        endurance = (int)GameStatus.gameStatus.plaeyrstatus.endurance;
        energy = GameStatus.gameStatus.plaeyrstatus.energy;

        if (life != beforelife)
        {
            showlife();            
        }
        if (endurance != beforendurance)
        {
            showendurance();
        }
        if (energy != beforenergy)
        {
            showenergy();
        }
        beforelife = life;
        beforendurance = endurance;
        beforenergy = energy;
    }
    void intial()
    {
        life = (int)GameStatus.gameStatus.plaeyrstatus.life;
        endurance = (int)GameStatus.gameStatus.plaeyrstatus.endurance;
        energy = GameStatus.gameStatus.plaeyrstatus.energy;

        beforelife = life;
        beforendurance = endurance;
        beforenergy = energy;

        for (int i = 0; i < UI_life.childCount; i++)
        {
            life_group.Add(UI_life.GetChild(i).GetComponent<Image>());
        }
        for (int i = 0; i < UI_endurance.childCount; i++)
        {
            endurance_group.Add(UI_endurance.GetChild(i).GetComponent<Image>());
        }
        for (int i = 0; i < UI_energy.childCount; i++)
        {
            energy_group.Add(UI_energy.GetChild(i).GetComponent<Image>());
        }


        showenergy();
        showendurance();
        showlife();
    }
    //public void showlife()
    //{
    //    StartCoroutine(showlifeRim());
    //}
    public void showlife()
    {
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
    public void showendurance()
    {
        int i = Mathf.Abs(endurance - beforendurance);
        int nowlife = beforendurance;
        if (endurance - beforendurance < 0)
        {
            StartCoroutine(lessEndurance(i, nowlife));
        }
        else if (endurance - beforendurance > 0)
        {
            StartCoroutine(addEndueance(i, nowlife));
        }
    }
    public void showenergy()
    {
        int i = Mathf.Abs(energy - beforenergy);
        int nowlife = beforenergy;
        if (energy - beforenergy <0)
        {
            StartCoroutine(lessEnergy(i, nowlife));
        }
        else if (energy - beforenergy > 0)
        {
            StartCoroutine(addEnergy(i, nowlife));
        }
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
    IEnumerator lessEndurance(int i, int ie)
    {
        for (int a = 0; a < i; a++)
        {
            endurance_group[ie - (a + 1)].fillAmount = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator addEndueance(int i, int ie)
    {
        for (int a = 0; a < i; a++)
        {
            endurance_group[ie + (a)].fillAmount = 1;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator addEnergy(int i, int ie)
    {
        for (int a = 0; a < i; a++)
        {
            energy_group[ie + (a)].fillAmount = 1;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator lessEnergy(int i, int ie)
    {
        for (int a = 0; a < i; a++)
        {
            energy_group[ie - (a + 1)].fillAmount = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }

    //IEnumerator showlifeRim()
    //{
    //    DOTween.To(() => IM_life.fillAmount, x => IM_life.fillAmount = x, life, 0.5f).SetEase(Ease.Linear);
    //    yield return new WaitForSeconds(0.5F);
    //}
}
