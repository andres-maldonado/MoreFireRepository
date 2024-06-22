using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string name;
    public string desc;
    public Sprite img;
<<<<<<< HEAD
    public void Init(string item_name, string item_desc, Sprite icon)
    {
        name = item_name;
        desc = item_desc;
        img = icon;
    }
    
=======

    public void Init(string item_name, string item_desc, Sprite item_img)
    {
        name = item_name;
        desc = item_desc;
        img = item_img;
    }

>>>>>>> 36201e6cf8a367d13e2f8a3d7998f5c9ce2cfdd5
}
