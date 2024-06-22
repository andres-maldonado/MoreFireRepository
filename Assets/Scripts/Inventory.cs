using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //if we want to have the objects be a class object with name, desc(maybe), and sprites
    public List<Item> inv = new List<Item>();
<<<<<<< HEAD

    // //if we want to have the inventory operate with just the name of objects as strings
    // public List<string> inv = new List<string>(); 
=======
    public List<Item> inv = new List<Item>();

    // // //if we want to have the inventory operate with just the name of objects as strings
    // // public List<string> inv = new List<string>(); 
>>>>>>> 36201e6cf8a367d13e2f8a3d7998f5c9ce2cfdd5

    void Start()
    {
        
<<<<<<< HEAD
        //testing string based inventory
        // inv.Add("onigiri");
        // inv.Add("famichiki");
        // print(inv[0] + " and " + inv[1]);

        // inv.Remove("famichiki");
        // print(inv[0]);

        //testing class based inventory [currently doesnt work]
        // public Item item1;

        //item1.Init("bread", "very soft very yum", Resources.load<Sprite>("C:\Users\sherb\Unity Projects\Fire Game\MoreFireRepository\Assets\Sprites\FirePlaceholderImages\bread.jpg"));

        Item item1 = ScriptableObject.CreateInstance<Item>();
        item1.Init("bread", "very yum very soft", Resources.Load<Sprite>("bread"));
        inv.Add(item1);
        print(item1.name);
        print(item1.desc);
=======
        
        //testing string based inventory
        // // inv.Add("onigiri");
        // // inv.Add("famichiki");
        // // print(inv[0] + " and " + inv[1]);

        // // inv.Remove("famichiki");
        // // print(inv[0]);

        //testing class based inventory

        Item item1 = ScriptableObject.CreateInstance<Item>();
        item1.Init("bread", "very yum very soft", Resources.Load<Sprite>("bread"));
        inv.Add(item1);
        print(item1.name);
        print(item1.desc);

>>>>>>> 36201e6cf8a367d13e2f8a3d7998f5c9ce2cfdd5
    }

    // Update is called once per frame
    void Update()
    {

    }
}
