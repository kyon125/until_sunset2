using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePos = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos.origin, mousePos.direction, 1 << 13);
            if (hit.transform.tag == "Player")
            {
                Debug.Log(hit.transform.name);
            }           
        }
    }
}
