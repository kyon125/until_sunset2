using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class Sapaya_awake : MonoBehaviour
{
    // Start is called before the first frame update
    public Light2D L1, L2, L3, L4;
    public bool s1 = false;
    public bool s2 = false;
    public bool s3 = false;
    private bool issapaya =false;
    private simplot plot;
    GameStatus gameStatus;
    void Start()
    {
        plot = GameObject.Find("PlotController").GetComponent<simplot>();
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) &&issapaya ==true)
        {
            if (s1 == true && s2 == true && s3 == true)
            {
                plot.playdia(52,52);
                StartCoroutine(playplot());
            }
            else
            {

                plot.playdia(51,51);
            }
        }        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            issapaya = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            issapaya = false;
        }
    }
    IEnumerator playplot()
    {
        gameStatus.status = GameStatus.Status.onPloting;
        yield return new WaitForSeconds(3F);
        Tween t1 = DOTween.To(() => L1.intensity, x => L1.intensity = x, 1, 3f);
        yield return new WaitForSeconds(3F);
        Tween t2 = DOTween.To(() => L2.intensity, x => L2.intensity = x, 1, 3f);
        yield return new WaitForSeconds(3F);
        Tween t3 = DOTween.To(() => L3.intensity, x => L3.intensity = x, 1, 3f);
        yield return new WaitForSeconds(3F);
        Tween t4 = DOTween.To(() => L4.intensity, x => L4.intensity = x, 2, 3f);

        gameStatus.status = GameStatus.Status.onPlaying;
    }
}
