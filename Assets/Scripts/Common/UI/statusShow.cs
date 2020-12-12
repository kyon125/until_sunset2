using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class statusShow : MonoBehaviour
{
    // Start is called before the first frame update
    public static statusShow statusUI;
    float life , beforelife;
    public Transform UI_life;
    public List<Image> IM_life = new List<Image>();
    void Start()
    {
        //Life 初始化
        intialLife();
    }

    // Update is called once per frame
    void Update()
    {
        life = GameStatus.gameStatus.plaeyrstatus.life / GameStatus.gameStatus.plaeyrstatus.maxlife;
        if (life != beforelife)
        {
            showlife();
        }
        beforelife = life;
    }
    void intialLife()
    {
        life = GameStatus.gameStatus.plaeyrstatus.life;
        beforelife = life;
        for (int i = 0; i < UI_life.childCount; i++)
        {
            IM_life.Add(UI_life.GetChild(i).GetComponent<Image>());
        }
    }
    public void showlife()
    {
        StartCoroutine(lifeCalculation());
    }
    IEnumerator lifeCalculation()
    {
        if (beforelife < life)
        {
            float i = life - beforelife;
            ;
            for (int a = Mathf.FloorToInt(beforelife / 0.2f); a < i; a++)
            {
                print("a=" + a);
                DOTween.To(() => IM_life[a].fillAmount, x => IM_life[a].fillAmount = x, 0, 0.1f);
                yield return new WaitUntil(() => IM_life[a].fillAmount == 0);
            }
        }
        else if (beforelife > life)
        {

        }
        else if (beforelife == life)
        {
            
        }

        //int i = Mathf.FloorToInt(life / GameStatus.gameStatus.plaeyrstatus.maxlife / 0.2f);
        //print("I=" + i);
        //for (int a = 0; a < i; a++)
        //{
        //    print("a=" + a);
        //    DOTween.To(() => IM_life[a].fillAmount, x => IM_life[a].fillAmount = x, 0, 0.1f);
        //    yield return new WaitUntil(() => IM_life[a].fillAmount == 0);
        //}
        //float f = (life / GameStatus.gameStatus.plaeyrstatus.maxlife / 0.2f - i);
        //print("f=" + f);
        //DOTween.To(() => IM_life[i].fillAmount, x => IM_life[i].fillAmount = x, f, 0.1f);
    }
}
