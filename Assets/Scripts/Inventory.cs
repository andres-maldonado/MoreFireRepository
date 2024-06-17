using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //if we want to have the objects be a class object with name, desc(maybe), and sprites

    // public void add_inv(Item add_item)
    // {
    //     inv.Add(add_item);
    // }

    // public void remove_inv(Item remove_item)
    // {
    //     inv.Remove(remove_item);
    // }

    // public List<Item> inv = new();

    //if we want to have the inventory operate with just the name of objects as strings
    public List<string> inv = new List<string>(); 

    void Start()
    {
        //testing string based inventory
        inv.Add("onigiri");
        inv.Add("famichiki");
        print(inv[0] + " and " + inv[1]);

        inv.Remove("famichiki");
        print(inv[0]);

        //testing class based inventory [currently doesnt work]
        // inv.add_inv("bread");
        // inv.add_inv("asahi milk tea");

        // print(inv[0].name + " and " + inv[1].name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
