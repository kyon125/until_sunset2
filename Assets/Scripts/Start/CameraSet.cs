using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSet : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer background;
    void Start()
    {
        float rendersize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = rendersize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
}
