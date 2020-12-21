using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBag : MonoBehaviour
{
    public static PlayerBag playerbag;
    public GameObject itemsource;
    public GameObject  com;
    public c_bag bg = new c_bag();
    public List<Itemclass> comitem;
    private Itemclass _itemname;
    private int _itemname_num;
    public GameObject tsf , hit_item;    

    public int select_itemid;
    public bool islight = false;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerbag = this;
        bg.I_item = new List<Itemclass>();
        bg.I_num = new List<int>();
        comitem = new List<Itemclass>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= bg.I_item.Count - 1; i++)
        {
            print("第"+i+"項:"+bg.I_num[i] +"名稱:"+ bg.I_item[i].show_name);
        }
        for (int i = 0; i <= bg.I_num.Count - 1; i++)
        {
            if (bg.I_num[i] == 0 && tsf.transform.childCount >= bg.I_num.Count)
            {
                bg.I_item.RemoveAt(i);
                bg.I_num.RemoveAt(i);
                GameObject go = tsf.transform.GetChild(i).gameObject;
                Destroy(go);
            }
        }   
    }
    

    public void creatitem()
    {
        //清空物件
        for (int i = 0; i < tsf.transform.childCount; i++)
        {
            GameObject obj = tsf.transform.GetChild(i).gameObject;
            Destroy(obj);
        }
        //清空選擇圖示
        GameObject.Find("Itemname").GetComponent<Text>().text = "";
        GameObject.Find("Itemimage").GetComponent<Image>().sprite = Resources.Load<Sprite>("Itemsprite/" + "0") ;
        GameObject.Find("itemdescrip").GetComponent<Text>().text = "";

        for (int i = 0 ; i <= bg.I_item.Count - 1;i++)
        {
            GameObject item =  Instantiate(itemsource, tsf.transform);

            Itemset it = item.GetComponent<Itemset>();
            it.Item_id = bg.I_item[i].id;
            print(it.Item_id);
            it.reset();

            item.name = Itemdateset.itemdate[bg.I_item[i].id].show_name;
        }
    }
    void selected()
    {
        if (bg.I_item.Contains(_itemname) == true)
        {
            int num = bg.I_item.IndexOf(_itemname);
            bg.I_num[num]++;
        }
        else if (bg.I_item.Contains(_itemname) == false)
        {
            bg.I_item.Add(_itemname);
            bg.I_num.Add(1);
        }
    }
    public void getitem(int id , int count)
    {
        if (bg.I_item.Contains(Itemdateset.itemdate[id]) == true)
        {
            int id_num = bg.I_item.IndexOf(Itemdateset.itemdate[id]);
            bg.I_num[id_num] += count;
            simplot.plotPlay.playgetitem(Itemdateset.itemdate[id].show_name, count);
        }
        else if (bg.I_item.Contains(Itemdateset.itemdate[id]) == false)
        {
            bg.I_item.Add(Itemdateset.itemdate[id]);
            bg.I_num.Add(count);
            simplot.plotPlay.playgetitem(Itemdateset.itemdate[id].show_name, count);
        }                        
    }
    public void removeitem(int id, int count)
    {
        if (bg.I_item.Contains(Itemdateset.itemdate[id]) == true)
        {
            int id_num = bg.I_item.IndexOf(Itemdateset.itemdate[id]);
            bg.I_num[id_num] -= count;
            if (tsf.activeSelf== false)
            {
                for (int i = 0; i <= bg.I_num.Count - 1; i++)
                {
                    if (bg.I_num[i] == 0 && tsf.transform.childCount >= bg.I_num.Count)
                    {
                        bg.I_item.RemoveAt(i);
                        bg.I_num.RemoveAt(i);
                        GameObject go = tsf.transform.GetChild(i).gameObject;
                        Destroy(go);
                    }
                }
                creatitem();
            }           
        }
    }
}

public class c_bag
{
    public List<Itemclass> I_item;
    public List<int> I_num;
}

