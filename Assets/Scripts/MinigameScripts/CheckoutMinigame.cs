using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class CheckoutMinigame : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider;
    [SerializeField] Animator wallet;
    [SerializeField] private TMP_Text item_listUI;
    [SerializeField] private List<string> checkout_screen = new List<string>();
    [SerializeField] string[] items_checkout;
    Dictionary<string, bool> checked_out = new Dictionary<string, bool>();
    BoxCollider2D checkout_trigger;

    bool finish_checkout = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (checked_out.ContainsKey(other.name)) // checks if item is scanned
        {
            checked_out[other.name] = true;
            checkout_screen.Add(other.name); 
            Debug.Log(other.name);
            if (!finish_checkout)
            {
                update_checkout_screen();
                checkout_done();
            }
            Destroy(other.gameObject);
            done_pay();
        }
    }

    void checkout_done()
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
            finish_checkout = true;
            wallet.Play("WalletEnter");
            collider.size = new Vector2 (1.5f, 0.4f);
            collider.offset = new Vector2 (-5, -3.4f);
            checked_out.Add("Coin", false);
        }        
    }

    void done_pay()
    {
        bool paid = true;
        foreach(var item in checked_out)
        {
            if (item.Value == false)
            {
                paid = false;
            }
        }
        if (paid)
        {
            wallet.Play("MinigameMoveDown");
            GetComponentInParent<MinigameWin>().Win();
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
        collider = collider.GetComponent<BoxCollider2D>();
        // initiates the map with all the items as not checked out
        checkout_trigger = GetComponent<BoxCollider2D>();
        for (int i = 0; i < items_checkout.Length; i++) 
        {
            checked_out.Add(items_checkout[i], false);
        }
    }
}
