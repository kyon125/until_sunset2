using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class simConvey : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject An;
    public GameObject cam1, cam2;
    public Vector3 pos;
    void Start()
    {
        An = GameObject.Find("An");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            portal();
        }
    }
    void portal()
    {
        StartCoroutine(go());
    }
    IEnumerator go()
    {
        GameStatus.gameStatus.status = GameStatus.Status.onPloting;
        UIcotroller.uicotroller.fulloff();
        yield return new WaitForSeconds(1f);
        An.transform.position = pos;
        cam1.SetActive(false);
        cam2.SetActive(true);
        UIcotroller.uicotroller.fullon();
        yield return new WaitForSeconds(0.5f);

        GameStatus.gameStatus.status = GameStatus.Status.onPlaying;
    }
}
