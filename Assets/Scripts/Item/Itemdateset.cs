using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdateset : MonoBehaviour
{
    // Start is called before the first frame update
    static public List<Itemclass> itemdate = new List<Itemclass>();
    static public List<compositionclass> composition = new List<compositionclass>();
    static public List<Plotclass> plot = new List<Plotclass>();
    private void Awake()
    {
        item_date();
        composition_data();
        plot_date();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void item_date()
    {
        TextAsset itemdata = Resources.Load<TextAsset>("database");

        string[] data = itemdata.text.Split(new char[] { '\n' });

        for (int a = 0; a < data.Length - 1; a++)
        {
            string[] row = data[a].Split(new char[] { ',' });

            Itemclass i = new Itemclass();
            int.TryParse(row[0], out i.id);
            i.show_name = row[1];
            i.load_name = row[2];

            itemdate.Add(i);
        }
    }

    void composition_data()
    {
        TextAsset itemdata = Resources.Load<TextAsset>("composite");

        string[] data = itemdata.text.Split(new char[] { '\n' });

        for (int a = 0; a < data.Length - 1; a++)
        {
            string[] row = data[a].Split(new char[] { ',' });

            compositionclass i = new compositionclass();
            int.TryParse(row[0], out i.id);
            int.TryParse(row[1], out i.item1);
            int.TryParse(row[2], out i.item2);
            int.TryParse(row[3], out i.composition);

            composition.Add(i);
        }
    }

    void plot_date()
    {
        TextAsset data = Resources.Load<TextAsset>("plot");

        string[] p = data.text.Split(new char[] { '\n' });

        for (int a = 0; a < p.Length - 1; a++)
        {
            string[] row = p[a].Split(new char[] { ',' });

            Plotclass step = new Plotclass();
            step.id = row[0];
            step.target = row[1];
            step.content = row[2];

            plot.Add(step);
        }
    }
}
