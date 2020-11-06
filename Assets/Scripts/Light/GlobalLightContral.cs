using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class GlobalLightContral : MonoBehaviour
{
    public Light2D light;
    public Ls ls;
    float nowlight;

    // Start is called before the first frame update
    void Start()
    {
        //ls = Ls.end;
        
        //Tween T = DOTween.To(() => light.intensity, x => light.intensity = x, 0, 30);
    }

    // Update is called once per frame
    void Update()
    {
        //switch (ls)
        //{
        //    case (Ls.begin):
        //        {
        //            break;
        //        }
        //    case (Ls.ing):
        //        {
        //            light.intensity = 1;
        //            ls = Ls.end;
        //            break;
        //        }
        //    case (Ls.end):
        //        {
        //            Tween T = DOTween.To(() => light.intensity, x => light.intensity = x, 0, 30);
        //            ls = Ls.begin;
        //            break;
        //        }
        //}
    }
    public void dis()
    {
        Tween T = DOTween.To(() => light.intensity, x => light.intensity = x, 0, 30);
    }
    public void add()
    {
        Tween T = DOTween.To(() => light.intensity, x => light.intensity = x, 1.2F, 0.01F);
    }
}
public enum Ls
{ 
    begin,
    ing,
    end
}
