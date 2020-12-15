using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Convey : MonoBehaviour
{
    public float distant ,timer;
    public GameObject An, cam1, cam2 ,ele;
    public bool godown;
    // Start is called before the first frame update
    void Start()
    {
        An = GameObject.Find("An");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void go()
    {
        if (godown == false)
        {
            convey();
            godown = true;
        }
        else if (godown == true)
        {
            returnconvey();
            godown = false;
        }
    }
    public void convey()
    {
        StartCoroutine(down());
    }
    public void returnconvey()
    {
        StartCoroutine(up());
    }

    IEnumerator up()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        An.transform.SetParent(ele.transform);
        ele.transform.DOBlendableMoveBy(new Vector3(0, distant, 0), timer);
        yield return new WaitForSeconds(0.5f);
        UIcotroller.uicotroller.fulloff();        
        yield return new WaitForSeconds(1f);
        cam1.SetActive(true);
        cam2.SetActive(false);
        UIcotroller.uicotroller.fullon();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(1.5f);

        An.transform.SetParent(null);
        GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
    }
    IEnumerator down()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        An.transform.SetParent(ele.transform);
        ele.transform.DOBlendableMoveBy(new Vector3(0, -distant, 0), timer);
        yield return new WaitForSeconds(1f);
        UIcotroller.uicotroller.fulloff();        
        yield return new WaitForSeconds(0.6f);
        cam1.SetActive(false);
        cam2.SetActive(true);
        UIcotroller.uicotroller.fullon();
        yield return new WaitForSeconds(0.6f);
        yield return new WaitForSeconds(1.5f);

        An.transform.SetParent(null);
        GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
    }
}
