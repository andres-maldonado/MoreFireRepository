using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class CheckoutMinigame : MonoBehaviour
{
    [SerializeField] Animator wallet;
    [SerializeField] private TMP_Text item_listUI;
    [SerializeField] private List<string> checkout_screen = new List<string>();
    [SerializeField] string[] items_checkout;
    Dictionary<string, bool> checked_out = new Dictionary<string, bool>();
    BoxCollider2D checkout_trigger;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (checked_out.ContainsKey(other.name)) // checks if item is scanned
        {
            checked_out[other.name] = true;
            checkout_screen.Add(other.name); 
            Debug.Log(other.name);
            update_checkout_screen();
            check_done();
            Destroy(other.gameObject);
        }
    }

    void check_done()
    {
        bool done_scanning = true;
        foreach(var item in checked_out)
        {
            if (item.Value == false)
            {
                done_scanning = false;
            }
        }
        if (done_scanning)
        {
            Debug.Log("done scanning !!");
            wallet.Play("WalletEnter");
        }        
    }

    public void update_checkout_screen() // updtaes the text on the checkout screen
    {
        string receipt = "";
        for (int i = 0; i < checkout_screen.Count; i++)
        {
            receipt += checkout_screen[i] + (i == checkout_screen.Count - 1 ? "" : "\n");
        }
        item_listUI.text = receipt;
    }

    void Start()
    {
        // initiates the map with all the items as not checked out
        checkout_trigger = GetComponent<BoxCollider2D>();
        for (int i = 0; i < items_checkout.Length; i++) 
        {
            checked_out.Add(items_checkout[i], false);
        }
    }
}
