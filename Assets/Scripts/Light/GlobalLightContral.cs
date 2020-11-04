using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLightContral : MonoBehaviour
{
    Light2D light;
    float minLight = 0.3f;
    float maxLight = 1;
    float nowlight;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        nowlight = light.intensity;

        if (nowlight <= maxLight && nowlight >= minLight) 
            light.intensity = light.intensity - 0.003f;
    }
}
