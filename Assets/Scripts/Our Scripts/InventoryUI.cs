using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Animator items;
    [SerializeField] Animator quest;
    public bool inventory_isopen = false;

    public void close_inventory()
    {
        items.Play("InventorySlotsExit");
        quest.Play("QuestLogExit");
        inventory_isopen = false;
    }

    public void open_inventory()
    {
        items.Play("InventorySlotsEnter");
        quest.Play("QuestLogEnter");
        inventory_isopen = true;
    }

    void Update()
    {
        //if TAB is pressed when the inventory is open it is closed
        if (Input.GetKeyDown(KeyCode.Tab) && inventory_isopen)
        {
            close_inventory();
        }

        //brings up the inventory if TAB is pressed and the inventory is not already open
        if (Input.GetKeyDown(KeyCode.Tab) && inventory_isopen == false)
        {
            open_inventory();
        }
    }
}
