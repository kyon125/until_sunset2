using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemset : MonoBehaviour
{
    public int Item_id;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "item")
        {
            SpriteRenderer s = this.gameObject.GetComponent<SpriteRenderer>();
            Sprite p = Resources.Load<Sprite>("Itemsprite/" + Item_id.ToString());
            s.sprite = p;

            this.gameObject.name = Itemdateset.itemdate[Item_id].load_name;
        }        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void reset() 
    {
        Image s = this.gameObject.GetComponent<Image>();
        Sprite p = Resources.Load<Sprite>("Itemsprite/" + Item_id.ToString());
        s.sprite = p;

        this.gameObject.name = Itemdateset.itemdate[Item_id].load_name;
    }

}

