using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string name;
    public string desc;
    public Sprite img;
    public void Init(string item_name, string item_desc, Sprite icon)
    {
        name = item_name;
        desc = item_desc;
        img = icon;
    }
    
}
