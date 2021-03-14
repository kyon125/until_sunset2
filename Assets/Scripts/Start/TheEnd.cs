using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class TheEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public int s, s1, e, e1;
    public List<Text> group;
    public Text END;
    bool i1, i2, i3, i4;
    void Start()
    {
        for (int i = 0; i < PlayerBag.playerbag.bg.I_item.Count; i++)
        {
            if (PlayerBag.playerbag.bg.I_item[i].id == 10)
            {
                i1 = true;
            }
            else if (PlayerBag.playerbag.bg.I_item[i].id == 11)
            {
                i2 = true;
            }
            else if (PlayerBag.playerbag.bg.I_item[i].id == 12)
            {
                i3 = true;
            }
            else if (PlayerBag.playerbag.bg.I_item[i].id == 13)
            {
                i4 = true;
            }
        }

        if (i1 == true && i2 == true && i3 == true && i4 == true)
        {
            StartCoroutine(plae(s, e));
        }
        else
        {
            StartCoroutine(plae(s1, e1));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator plae(int s ,int e)
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        yield return StartCoroutine(simplot.plotPlay.playplot(s, e));
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        for (int i = 0; i < group.Count; i++)
        {
            group[i].DOFade(1, 1.5f);
            yield return new WaitForSeconds(3.5f);
            group[i].DOFade(0, 1.5f);
            yield return new WaitForSeconds(1.5f);
        }
        END.DOFade(1, 2.5F);
        yield return new WaitUntil(() => Input.anyKeyDown);
        Loadscene.loadcontroller.loadName = "Start";
        Loadscene.loadcontroller.changescene();
    }
}
