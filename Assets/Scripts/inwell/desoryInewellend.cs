using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desoryInewellend : MonoBehaviour
{
    // Start is called before the first frame update
    public GameStatus.MainQuest main;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStatus.gameStatus.mainquest == main)
        {
            Destroy(this.transform.gameObject);
        }
    }
}
