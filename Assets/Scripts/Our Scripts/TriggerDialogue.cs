using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private bool repeat;
    [SerializeField] private string minigame_id = "";
    [SerializeField] private string quests_to_start;
    [SerializeField] private string quests_to_complete;
    [SerializeField] private Sprite speaker_sprite;
    [SerializeField] private string fetch_item;
    [SerializeField] private bool interactToTrigger = true;
    [SerializeField] private bool do_fetch_quest = false;
    [SerializeField] private Item fetch_obj;
    [SerializeField] private string post_fetch_dialogue_file_name;
    [SerializeField] private List<Item> give_objs = new List<Item>();

    private bool player_near = false;
    private InventoryUI inv_ui;
    private Inventory inv;

    private void Start() {
        inv_ui = GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<InventoryUI>();
        inv = GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<Inventory>();
    }

    private void Update() {
        if (player_near && (Input.GetKeyDown(KeyCode.E)||!interactToTrigger) && !GlobalManager.Instance.in_dialogue && !GlobalManager.Instance.in_minigame) {
            Debug.Log("Player Triggered");
            NewPlayerMovement.Instance.DisablePlayer(true); // stop movement
            if (inv_ui.inventory_isopen) //if the inventory is open close inventory
            {
                inv_ui.close_inventory();
            }
            if (inv.in_inventory(fetch_item)) {
                dialogue_file_name = post_fetch_dialogue_file_name;
                inv.remove_item(fetch_item);
            }
            GlobalManager.Instance.StartDialogue(dialogue_file_name, speaker_sprite, minigame_id, quests_to_start, quests_to_complete, give_objs); // queue dialogue
            Destroy(gameObject);
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
