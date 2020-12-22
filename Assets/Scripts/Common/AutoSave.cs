using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        saveGame.savecontroller.save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
