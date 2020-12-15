using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class shine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    Vector3 t_scale;
    Material m;
    void Start()
    {
        t_scale = UI.transform.localScale;
        UI.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        m = transform.GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            playerEnter();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            playerLeave();
        }
    }

    void playerEnter()
    {
        UI.transform.DOScale(t_scale, 0.3f);
        m.SetFloat("outLine", 1);
    }
    void playerLeave()
    {
        UI.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        m.SetFloat("outLine", 0);
    }
}
