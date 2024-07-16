using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{

    public Item item;
    private bool in_trigger = false;
    public GameObject inventory;
    SpriteRenderer render;


    private void OnTriggerStay2D(Collider2D collision)
    {
        in_trigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        in_trigger = false;
    }
    void Update()
    {
        if (in_trigger && Input.GetKeyDown(KeyCode.E) && inventory.GetComponent<Inventory>().inv.Count < 5)
        {
            inventory.GetComponent<Inventory>().inv.Add(item); //adds item to inventory
            render = this.GetComponent<SpriteRenderer>();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.itemPickup, this.transform.position);
            Destroy(gameObject);
        }
        else if (in_trigger && Input.GetKeyDown(KeyCode.E) && inventory.GetComponent<Inventory>().inv.Count >= 5)
        {
            print("Inventory is full");
        }
    }
}
