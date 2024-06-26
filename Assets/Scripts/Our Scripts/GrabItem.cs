using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{

    public Item item;
    private bool in_trigger = false;
    public GameObject inventory;


    private void OnTriggerStay2D(Collider2D collision)
    {
        in_trigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        in_trigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (in_trigger && Input.GetKeyDown(KeyCode.E) && inventory.GetComponent<Inventory>().inv.Count < 5)
        {
            //Item item2 = ScriptableObject.CreateInstance<Item>();
            //item2.Init(transform.name, "mmmmm refreshing", Resources.Load<Sprite>(transform.name));
            inventory.GetComponent<Inventory>().inv.Add(item);
            Destroy(gameObject);
        }
        else if (in_trigger && Input.GetKeyDown(KeyCode.E) && inventory.GetComponent<Inventory>().inv.Count >= 5)
        {
            print("Inventory is full");
        }
    }
}
