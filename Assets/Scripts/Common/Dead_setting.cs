using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Dead_setting : MonoBehaviour
{
    Text tile , start , end;
    Button b1, b2;
    // Start is called before the first frame update
    void Start()
    {
        tile = GameObject.Find("tile").GetComponent<Text>();
        start = GameObject.Find("T_restart").GetComponent<Text>();
        end = GameObject.Find("T_end").GetComponent<Text>();

        b1 = GameObject.Find("restart").GetComponent<Button>();
        b1 = GameObject.Find("end").GetComponent<Button>();
        StartCoroutine(show());
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restatgame()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
        GameStatus.gameStatus.intialplayer();
        saveGame.savecontroller.load();
        GameStatus.gameStatus.archivestatus = GameStatus.ArchiveStatus.isLoad;
    }
    public void endgame()
    {
        Destroy(GameObject.Find("GameController"));
        GameStatus.gameStatus.intialplayer();
        SceneManager.LoadScene("Start");
    }

    IEnumerator show()
    {
        yield return new WaitForSeconds(0.5f);
        Tween t = tile.transform.DOScaleX(1, 0.3f);

        yield return new WaitForSeconds(0.5f);
        Tween t2 = start.DOFade(255, 2f);
        Tween t3 = end.DOFade(255, 2f);

    }
}
