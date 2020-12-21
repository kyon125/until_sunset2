using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    // Start is called before the first frame update
    public bool istrigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && GameStatus.gameStatus.hurtstatus != GameStatus.Hurtstatus.ishurt && istrigger == false)
        {
            hurtplayer();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && GameStatus.gameStatus.hurtstatus != GameStatus.Hurtstatus.ishurt && istrigger == true)
        {
            hurtplayer();
        }
    }
    public void hurtplayer()
    {
        StartCoroutine(hurt());
    }
    IEnumerator hurt()
    {
        GameStatus.gameStatus.lifeController(-1);
        GameStatus.gameStatus.hurtstatus = GameStatus.Hurtstatus.ishurt;
        yield return new WaitForSeconds(3f);
        GameStatus.gameStatus.hurtstatus = GameStatus.Hurtstatus.isnormal;
    }
}
