using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();

    void Start()
    {
        Item item1 = ScriptableObject.CreateInstance<Item>();
        item1.Init("bread", "very yum very soft", Resources.Load<Sprite>("bread"));
        inv.Add(item1);
        print(item1.name);
        print(item1.desc);

        Item item2 = ScriptableObject.CreateInstance<Item>();
        item2.Init("water", "mmmmm refreshing", Resources.Load<Sprite>("water"));
        inv.Add(item2);
        print(item2.name);
        print(item2.desc);
    }
    void Update()
    {

    }
}
