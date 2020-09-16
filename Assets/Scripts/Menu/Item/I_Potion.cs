using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Potion : MonoBehaviour
{
    // Start is called before the first frame update
    public string o_name;
    public bool red, blue ,green;
    basicPotion potion;
    void Start()
    {
        creatitem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void creatitem()
    {
        if (red == true)
        {
            potion = new Red_Potion() { item_name = "紅藥水", item_id = "P001" };
        }
        else if (blue == true)
        {
            potion = new Blue_Potion() { item_name = "藍藥水", item_id = "P002" };
        }
        else if (green == true)
        {
            potion = new Blue_Potion() { item_name = "綠藥水", item_id = "P003" };
        }
        o_name = potion.item_name;
    }
    class Red_Potion : basicPotion
    {
        public override void effect()
        {
            
        }
    }
    class Blue_Potion : basicPotion
    {
        public override void effect()
        {

        }
    }
    class Green_Potion : basicPotion
    {
        public override void effect()
        {

        }
    }
}
public abstract class basicPotion 
{
    public string item_name;
    public string item_id;
    public abstract void effect();
}

