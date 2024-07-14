using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] private string minigame_name;
    [SerializeField] bool oneTime;
    private bool inTrigger = false;
    private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalManager.Instance.IsComplete(minigame_name)) Destroy(gameObject);
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
        GameObject.FindWithTag("Player").GetComponent<NewPlayerMovement>().DisablePlayer(true);
        //Instantiate(minigame, canvas.transform);
        GlobalManager.Instance.StartMinigame(minigame_name);
        Destroy(gameObject);
    }
}
