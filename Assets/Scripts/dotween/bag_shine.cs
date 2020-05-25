using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class bag_shine : MonoBehaviour
{
    // Start is called before the first frame update

    Sequence mySequence;
    void Start()
    {        
        //dd();
        //Tween t = Im.DOFade(0, 3f);
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    private void OnMouseEnter()
    {
        dd();
    }
    private void OnMouseExit()
    {
        mySequence.Kill();
        Tween t = this.gameObject.GetComponent<Image>().DOFade(0, 0.1f);
    }
    void dd()
    {
        mySequence = DOTween.Sequence();
        mySequence.Append(this.transform.GetComponent<Image>().DOFade(0.4f, 0.5f));
        mySequence.Append(this.transform.GetComponent<Image>().DOFade(0f, 0.5f)); 
        mySequence.SetLoops(-1);
    }
}
