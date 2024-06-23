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
        if (Input.GetKeyDown(KeyCode.I))
        {
            timer.Play("InventoryTimerEnter");
            items.Play("InventorySlotsEnter");
            inventory_isopen = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inventory_isopen)
        {
            timer.Play("InventoryTimerExit");
            items.Play("InventorySlotsExit");
            inventory_isopen = false;
        }
    }
}
