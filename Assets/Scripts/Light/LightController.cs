using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    Light2D light2;
    public float start, end, speed;
    void Start()
    {
        light2 = this.GetComponent<Light2D>();
        start = light2.intensity;

        Sequence seq = DOTween.Sequence();
        seq.Append(DOTween.To(() => light2.intensity, x => light2.intensity = x, end, speed));
        seq.Append(DOTween.To(() => light2.intensity, x => light2.intensity = x, start, speed));        
        seq.SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
