using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    public GameObject inventory;
    public bool in_trigger = false;
    private void OnTriggerEnter2D()
    {
        in_trigger = true;
    }

    private void OnTriggerExit2D()
    {
        in_trigger = false;
    }

    void Start()
    {
        inventory = GameObject.FindWithTag("Inventory");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && in_trigger && inventory.GetComponent<Inventory>().inv.Count < 5)
        {
            Item obj = ScriptableObject.CreateInstance<Item>();
            obj.Init(this.gameObject.name, this.gameObject.name, this.gameObject.transform.GetComponent<SpriteRenderer>().sprite);
            inventory.GetComponent<Inventory>().inv.Add(obj);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.itemPickup, this.transform.position);
            Destroy(this.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.E) && in_trigger && inventory.GetComponent<Inventory>().inv.Count >= 5)
        {
            print("Inventory is full");
        }
    }
}
