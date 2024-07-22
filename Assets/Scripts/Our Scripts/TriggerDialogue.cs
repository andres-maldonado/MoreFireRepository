using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private string dialogue_file_name = "dialogue_test_file";

    [SerializeField] private string minigame_id = "";
    [SerializeField] private string quests_to_start;
    [SerializeField] private string quests_to_complete;
    [SerializeField] private Sprite speaker_sprite;
    [SerializeField] private string fetch_item;
    [SerializeField] private bool interactToTrigger = true;

    [SerializeField] private bool do_fetch_quest = false;
    [SerializeField] private Item fetch_obj;
    [SerializeField] private string post_fetch_dialogue_file_name;

    private bool player_near = false;

    private void Start() {  }

    private void Update() {
        if (player_near && (Input.GetKeyDown(KeyCode.E)||!interactToTrigger) && !GlobalManager.Instance.in_dialogue) {
            Debug.Log("Player Triggered");
            GameObject.FindWithTag("Player").GetComponent<NewPlayerMovement>().DisablePlayer(true); // stop movement
            if (GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<InventoryUI>().inventory_isopen) //if the inventory is open close inventory
            {
                GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<InventoryUI>().close_inventory();
            }
            if (GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<Inventory>().in_inventory(fetch_item)) {
                dialogue_file_name = post_fetch_dialogue_file_name;
                GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<Inventory>().remove_item(fetch_item);
            }
            GlobalManager.Instance.StartDialogue(dialogue_file_name, speaker_sprite, minigame_id, quests_to_start, quests_to_complete); // queue dialogue
            if(!interactToTrigger)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<NewPlayerMovement>() != null) {
            player_near = true;
            Debug.Log("Player Entered");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<NewPlayerMovement>() != null) {
            player_near = false;
        }
    }
}
