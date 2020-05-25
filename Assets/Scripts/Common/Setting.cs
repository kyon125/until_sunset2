using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject set;
    s_status status;
    Slider bgm, se;
    void Start()
    {
        Initial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void v_bgm()
    {
        status.bgm = bgm.value * 100;
    }

    public void v_se()
    { 
       
    }

    public void closs()
    {
        string json = JsonUtility.ToJson(status);
        StreamWriter file = new StreamWriter(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "SettingValue.json"));
        file.Write(json);
        file.Close();

        Destroy(set);        
    }
    void Initial()
    {
        set = GameObject.FindWithTag("Setting");
        bgm = GameObject.Find("V_bgm").GetComponent<Slider>();
        se = GameObject.Find("V_se").GetComponent<Slider>();

        StreamReader read = new StreamReader(System.IO.Path.Combine((Application.dataPath).ToString() + "/Json", "SettingValue.json"));
        string loadjson = read.ReadToEnd();
        read.Close();
        status = JsonUtility.FromJson<s_status>(loadjson);
        Debug.Log(status.bgm);
        bgm.value = status.bgm / 100;
        se.value = status.se / 100;
    }
    public class s_status
    {
        [SerializeField]
        public float bgm;
        [SerializeField]
        public float se;
    }
}
