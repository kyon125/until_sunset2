using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class ruby_awake : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject diamand;
    public Light2D light;

    private PlayerBag An_bag;
    private simplot plot; 
    void Start()
    {
        plot = this.gameObject.GetComponent<simplot>();
        An_bag = GameObject.Find("An").GetComponent<PlayerBag>();
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
        diamand.GetComponent<SpriteRenderer>().enabled = true;
        plot.playdia();
        yield return new WaitForSeconds(3f);
        Tween t = diamand.GetComponent<SpriteRenderer>().DOColor(new Color(241, 58, 58) , 5f);
        Tween t2 = DOTween.To(() => light.pointLightOuterRadius, x => light.pointLightOuterRadius = x, 20, 5f);
    }

}
