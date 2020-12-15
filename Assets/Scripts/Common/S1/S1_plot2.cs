using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_plot2 : S1_plot
{
    // Start is called before the first frame update
    public string questname;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Quest_controller.questcontroller.questlisting.Count; i++)
        {
            if (Quest_controller.questcontroller.questlisting[i].name == questname)
            {
                playplot();
            }
        }        
    }
}
