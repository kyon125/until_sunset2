using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class ruby_awake : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject diamand;
    public Light2D light , L2, L3;
    public GameObject cam , cam1;
    GameStatus gameStatus;
    private PlayerBag An_bag;
    private simplot plot; 
    void Start()
    {
        plot = this.gameObject.GetComponent<simplot>();
        An_bag = GameObject.Find("An").GetComponent<PlayerBag>();
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (An_bag.bg.I_item.Contains(Itemdateset.itemdate[6]))
        {
            StartCoroutine(trunruby());
        }
    }

    IEnumerator trunruby()
    {
        gameStatus.status = GameStatus.Status.onPloting;
        yield return new WaitForSeconds(0.3f);
        diamand.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        plot.playdia(47,49);
        yield return new WaitForSeconds(3f);
        Tween t2 = DOTween.To(() => light.pointLightOuterRadius, x => light.pointLightOuterRadius = x, 20, 5f);
        yield return new WaitForSeconds(5f);
        Tween t3 = DOTween.To(() => L2.intensity, x => L2.intensity = x, 1, 3f);
        yield return new WaitForSeconds(3f);
        Tween t4 = DOTween.To(() => L3.intensity, x => L3.intensity = x, 10, 3f);
        yield return new WaitForSeconds(3f);
        plot.start = 40;
        plot.end = 42;
        plot.playdia(40,42);
        yield return new WaitForSeconds(2f);
        GameObject.Find("An").transform.position = new Vector3(218,-37, 0);
        cam.SetActive(false); 
        cam1.SetActive(true);
        BridgeSwitch.havenergy = true;
    }

}
