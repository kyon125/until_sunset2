using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dead_setting : MonoBehaviour
{
    Text tile , start , end;
    // Start is called before the first frame update
    void Start()
    {
        tile = GameObject.Find("tile").GetComponent<Text>();
        start = GameObject.Find("T_restart").GetComponent<Text>();
        end = GameObject.Find("T_end").GetComponent<Text>();
        StartCoroutine(show());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator show()
    {
        yield return new WaitForSeconds(0.5f);
        Tween t = tile.transform.DOScaleX(1, 0.3f);
        yield return new WaitForSeconds(0.5f);
        Tween t2 = start.DOFade(255, 0.1f);
        Tween t3 = end.DOFade(255, 0.1f);

    }
}
