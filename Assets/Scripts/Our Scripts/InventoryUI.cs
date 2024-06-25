using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Animator timer;
    [SerializeField] Animator items;
    private bool inventory_isopen = false;

    void Start()
    {

    }

    void Update()
    {
        //brings up the inventory if TAB is pressed and the inventory is not already open
        if (Input.GetKeyDown(KeyCode.Tab) && inventory_isopen == false)
        {
            timer.Play("InventoryTimerEnter");
            items.Play("InventorySlotsEnter");
            inventory_isopen = true;
        }

        //if TAB is pressed when the inventory is open it is closed
        if (Input.GetKeyDown(KeyCode.Tab) && inventory_isopen)
        {
            timer.Play("InventoryTimerExit");
            items.Play("InventorySlotsExit");
            inventory_isopen = false;
        }

    }
}
