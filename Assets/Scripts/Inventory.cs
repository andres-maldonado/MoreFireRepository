using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //if we want to have the objects be a class object with name, desc(maybe), and sprites
    public List<Item> inv = new List<Item>();

    // //if we want to have the inventory operate with just the name of objects as strings
    // public List<string> inv = new List<string>(); 

    void Start()
    {
        
        //testing string based inventory
        // inv.Add("onigiri");
        // inv.Add("famichiki");
        // print(inv[0] + " and " + inv[1]);

        // inv.Remove("famichiki");
        // print(inv[0]);

        //testing class based inventory

        Item item1 = ScriptableObject.CreateInstance<Item>();
        item1.Init("bread", "very yum very soft", Resources.Load<Sprite>("bread"));
        inv.Add(item1);
        print(item1.name);
        print(item1.desc);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
