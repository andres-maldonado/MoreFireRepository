using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Animator timer;
    [SerializeField] Animator items;
    public bool inventory_isopen = false;

    public void close_inventory()
    {
        timer.Play("InventoryTimerExit");
        items.Play("InventorySlotsExit");
        inventory_isopen = false;
    }

    public void open_inventory()
    {
        timer.Play("InventoryTimerEnter");
        items.Play("InventorySlotsEnter");
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
