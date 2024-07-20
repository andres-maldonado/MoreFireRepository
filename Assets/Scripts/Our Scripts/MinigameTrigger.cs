using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using FMODUnity;
using System;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] public string[] item_reqs;
    [SerializeField] private string minigame_name;
    [SerializeField] bool oneTime;
    private bool inTrigger = false;
    private GameObject canvas;
    [SerializeField] EventReference startSound;
    private bool has_req_items = false;

    private bool check_item_reqs(string[] item_reqs)
    {
        int count = 0;
        for (int i = 0; i < item_reqs.Length; i ++)
        {
            if(inventory.GetComponent<Inventory>().inv[i].name == item_reqs[i])
            {
                count++;
            }
        }
        if(count == item_reqs.Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalManager.Instance.IsComplete(minigame_name)) Destroy(gameObject);
        canvas = GameObject.FindWithTag("MainCanvas");
        has_req_items = check_item_reqs(item_reqs);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger && has_req_items)
        {
            if (GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<InventoryUI>().inventory_isopen) //if the inventory is open
            {
                GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<InventoryUI>().close_inventory(); //closes inventory
            }
            StartGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }

    private void StartGame()
    {
        //AudioManager.instance.PlayOneShot(FMODEvents.instance.startSound);
        GameObject.FindWithTag("Player").GetComponent<NewPlayerMovement>().DisablePlayer(true);
        //Instantiate(minigame, canvas.transform);
        AudioManager.instance.PlayOneShot(startSound, this.transform.position);
        GlobalManager.Instance.StartMinigame(minigame_name);
        Destroy(gameObject);
    }
}
