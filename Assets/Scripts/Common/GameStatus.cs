using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public Status status;
    void Start()
    {
        status = new Status();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum Status
    {
        onPlaying,
        onBaging,
        onComposition,
        onPloting,
    }
}
