using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBag : MonoBehaviour
{
    public GameObject itemsource;
    public GameObject  com;
    public c_bag bg = new c_bag();
    public List<Itemclass> comitem;
    private Itemclass _itemname;
    private int _itemname_num;
    public GameObject tsf , hit_item;    
    private GameStatus gameStatus;
    private CharacterController2D An;

    public int select_itemid;
    public bool islight = false;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.Find("GameController").GetComponent<GameStatus>();
        An = GameObject.Find("An").GetComponent<CharacterController2D>();
        bg.I_item = new List<Itemclass>();
        bg.I_num = new List<int>();
        comitem = new List<Itemclass>();
        de_item();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= bg.I_item.Count - 1; i++)
        {
            print("第"+i+"項:"+bg.I_num[i]);
        }
        getitem();

        if (GameObject.Find("Pack") == true)
        {            
            for (int i = 0; i <= bg.I_num.Count - 1; i++)
            {
                if (bg.I_num[i] == 0)
                {
                    bg.I_item.RemoveAt(i);
                    bg.I_num.RemoveAt(i);
                    GameObject go = tsf.transform.GetChild(i).gameObject;
                    Destroy(go);
                }
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
    public void getitem()
    {
        if (hit_item != null)
        {
            if (Input.GetKeyDown(KeyCode.F) && hit_item.GetComponent<simplot2>().ishaveitem == true && An.isitem == true)
            {
                _itemname = Itemdateset.itemdate[hit_item.GetComponent<simplot2>().item_id];
                _itemname_num = hit_item.GetComponent<simplot2>().item_num;
                if (bg.I_item.Contains(_itemname) == true)
                {
                    int id_num = bg.I_item.IndexOf(_itemname);
                    bg.I_num[id_num] += _itemname_num;
                }
                else if (bg.I_item.Contains(_itemname) == false)
                {
                    bg.I_item.Add(_itemname);
                    bg.I_num.Add(_itemname_num);
                }
            }
        }                  
    }
    private void de_item()
    {
        bg.I_item.Add(Itemdateset.itemdate[1]);
        bg.I_num.Add(1);
    }
}

public class c_bag
{
    public List<Itemclass> I_item;
    public List<int> I_num;
}

