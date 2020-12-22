using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cloudBasic : MonoBehaviour
{
    // Start is called before the first frame update
    public float pos ,down ,dt;
    bool isplayer, ismove;
    LayerMask player;
    void Start()
    {
        pos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && ismove == false)
        {
            Boing();
            collision.transform.SetParent(transform.parent, true);
            ismove = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && ismove == false)
        {
            collision.transform.SetParent(GameObject.Find("GameController").transform, true);
            transform.DOLocalMoveY(pos, 0.5f);
        }
    }
    void Boing()
    {
        StartCoroutine(waitboing());
    }
    IEnumerator waitboing()
    {
        transform.DOBlendableMoveBy(new Vector3(0, -down, 0), dt).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(dt);
        ismove = false;
    }
}
