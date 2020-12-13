using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_plot : MonoBehaviour
{
    // Start is called before the first frame update
    bool isdone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Viliage"&& isdone ==false)
        {
            StartCoroutine(plot1());
            isdone = true;
        }
    }
    IEnumerator plot1()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        UIcotroller.uicotroller.blackscreenOpen();       
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(simplot.plotPlay.playplot(1,3));
        UIcotroller.uicotroller.blackscreenClose();
    }
}
