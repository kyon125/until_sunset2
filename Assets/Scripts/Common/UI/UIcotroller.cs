using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIcotroller : MonoBehaviour
{
    // Start is called before the first frame update
    static public UIcotroller uicotroller;
    public Image blockUp, blockDown;
    private void Awake()
    {
        uicotroller = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            blackscreenOpen();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            blackscreenClose();
        }
    }

    public void blackscreenOpen()
    {
        blockUp.transform.DOBlendableMoveBy(new Vector3(0, -200, 0), 0.5F);
        blockDown.transform.DOBlendableMoveBy(new Vector3(0, 200, 0), 0.5F);
    }

    public void blackscreenClose()
    {

        blockUp.transform.DOBlendableMoveBy(new Vector3(0, 200, 0), 0.5F);
        blockDown.transform.DOBlendableMoveBy(new Vector3(0, -200, 0), 0.5F);
    }
    public void fullon()
    {
        blockUp.transform.DOBlendableMoveBy(new Vector3(0, 700, 0), 0.5F);
        blockDown.transform.DOBlendableMoveBy(new Vector3(0, -700, 0), 0.5F);
    }
    public void fulloff()
    {
        blockUp.transform.DOBlendableMoveBy(new Vector3(0, -700, 0), 0.5F);
        blockDown.transform.DOBlendableMoveBy(new Vector3(0, 700, 0), 0.5F);
    }
    public void fullblock()
    {
        StartCoroutine(fullBlock());
    }
    IEnumerator fullBlock()
    {
        fulloff();
        yield return new WaitForSeconds(0.5f);
        fullon();
    }
}
