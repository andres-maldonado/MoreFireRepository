using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    public GameObject inventory;
    SpriteRenderer render;
    private void OnTriggerStay2D()
    {
        if (Input.GetKeyDown(KeyCode.E) && inventory.GetComponent<Inventory>().inv.Count < 5)
        {
            Item obj = ScriptableObject.CreateInstance<Item>();
            obj.Init(this.gameObject.name, this.gameObject.name, this.gameObject.transform.GetComponent<SpriteRenderer>().sprite);
            inventory.GetComponent<Inventory>().inv.Add(obj);
            render = this.GetComponent<SpriteRenderer>();
            AudioManager.instance.PlayOneShot(FMODEvents.instance.itemPickup, this.transform.position);
            Destroy(this);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inventory.GetComponent<Inventory>().inv.Count >= 5)
        {
            print("Inventory is full");
        }
    }
}
