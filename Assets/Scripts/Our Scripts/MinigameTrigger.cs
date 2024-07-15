using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using FMODUnity;
using System;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] GameObject minigame;
    [SerializeField] bool oneTime;
    private bool inTrigger = false;
    private GameObject canvas;
    [SerializeField] EventReference startSound;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("MainCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true)
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
        Instantiate(minigame, canvas.transform);
        AudioManager.instance.PlayOneShot(startSound, this.transform.position);
        Destroy(gameObject);
    }
}
