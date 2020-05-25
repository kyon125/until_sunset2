using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector2 parallaxEffectMultiplier;

    public GameObject cam;
    private Transform camtransfrom;
    private Vector3 lastcampos;
    void Start()
    {
        camtransfrom = cam.transform;
        lastcampos = camtransfrom.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltamovent = camtransfrom.position - lastcampos;

        transform.position += new Vector3(deltamovent.x * parallaxEffectMultiplier.x, deltamovent.y * parallaxEffectMultiplier.y);
        lastcampos = camtransfrom.position;

    }
}
