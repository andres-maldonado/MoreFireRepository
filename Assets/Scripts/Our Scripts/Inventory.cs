using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();
    SpriteRenderer render;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    
    void get_item_sprite(List<Item> inventory, GameObject slot, int inventory_num)
    {
        render = slot.GetComponent<SpriteRenderer>();
        render.sprite = inventory[inventory_num].img;
        slot.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Foreground");
    }

    void Start()
    {
        Item item1 = ScriptableObject.CreateInstance<Item>();
        item1.Init("bread", "very yum very soft", Resources.Load<Sprite>("bread"));
        inv.Add(item1);

        Item item2 = ScriptableObject.CreateInstance<Item>();
        item2.Init("water", "mmmmm refreshing", Resources.Load<Sprite>("water"));
        inv.Add(item2);
    }

    void Update()
    {
        if (inv.Count >= 1)
        {
            get_item_sprite(inv, slot1, 0);

            if (inv.Count >= 2)
            {
                get_item_sprite(inv, slot2, 1);

                if (inv.Count >= 3)
                {
                    get_item_sprite(inv, slot3, 2);

                    if (inv.Count >= 4)
                    {
                        get_item_sprite(inv, slot4, 3);

                        if (inv.Count >= 5)
                        {
                            get_item_sprite(inv, slot5, 4);
                        }
                    }
                }
            }
        }
    }
}
