using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject inventory = GameObject.Find("Inventory");
        Destroy(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
