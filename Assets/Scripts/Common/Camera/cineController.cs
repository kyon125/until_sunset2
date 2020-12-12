using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class cineController : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineVirtualCamera cine;
    float orgialSize;
    public static cineController cinecontroller;
    private void Awake()
    {
        cinecontroller = this;
    }
    void Start()
    {
        cine = this.GetComponent<CinemachineVirtualCamera>();
        intial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void intial()
    {
        orgialSize = cine.m_Lens.OrthographicSize;
    }
    public void cineSizeset(float f, float time)
    {
        DOTween.To(() => cine.m_Lens.OrthographicSize, x => cine.m_Lens.OrthographicSize = x, f, time);
    }
}
