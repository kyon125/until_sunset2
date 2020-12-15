using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class S1_plot : MonoBehaviour , Mainquest_interface
{
    // Start is called before the first frame update
    [SerializeField]
    public Quest_scriptable quest;
    [SerializeField]
    public int startplot, endplot;
    [SerializeField]
    public GameStatus.MainQuest trigger, change;
    [SerializeField]
    public string scenename;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playplot();
    }
    public void playplot()
    {
        if (SceneManager.GetActiveScene().name == scenename && GameStatus.gameStatus.mainquest == trigger)
        {
            GameStatus.gameStatus.mainquest = change;
            StartCoroutine(plot1(startplot ,endplot));
            if (quest != null)
            {
                Quest_controller.questcontroller.AddQuest(quest.quest);
            }
            this.enabled = false;
        }
    }
    IEnumerator plot1(int a, int b)
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        UIcotroller.uicotroller.blackscreenOpen();       
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(simplot.plotPlay.playplot(a,b));
        UIcotroller.uicotroller.blackscreenClose();       
    }
}
