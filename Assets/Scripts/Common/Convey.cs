using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convey : MonoBehaviour
{
    public Vector2 pos;
    public GameObject An, cam1, cam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            conveyplayer();
        }
    }
    void conveyplayer()
    {
        An.transform.position = new Vector3(pos.x, pos.y, An.transform.position.z);
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
