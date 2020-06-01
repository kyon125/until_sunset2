using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_item : MonoBehaviour
{
    // Start is called before the first frame update
    simplot2 plot;
    void Start()
    {
        plot = this.gameObject.GetComponent<simplot2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plot.ishaveitem == false)
        {
            Destroy(this.gameObject);
        }
    }
}
