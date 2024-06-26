using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private int minigame_id = -1;
    [SerializeField] private string quests_to_start;
    [SerializeField] private string quests_to_complete;
    [SerializeField] private Sprite speaker_sprite;
    [SerializeField] private Item fetch_item;

    private bool player_near = false;

    private void Start() {
        if (GetComponent<SpriteRenderer>() == null) {
            Debug.LogError("Error: no SpriteRenderer component attached to DialogueTrigger; no speaker sprite available.");
            GetComponent<TriggerDialogue>().enabled = false;
        }
    }

    private void Update() {
        if (player_near && Input.GetKeyDown(KeyCode.E) && !GlobalManager.Instance.in_dialogue) {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().DisablePlayer(true); // stop movement
            if (GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<InventoryUI>().inventory_isopen) //if the inventory is open close inventory
            {
                GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<InventoryUI>().close_inventory();
            }
            if (GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<Inventory>().inv.Contains(fetch_item)) {
                dialogue_file_name = "dialogue_test_postfetch";
                quests_to_complete = "water_fetch";
                quests_to_start = "";
                GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<Inventory>().inv.Remove(fetch_item);
                GameObject.FindWithTag("MainCanvas").transform.GetChild(0).GetComponent<Inventory>().clear_all_sprites();
            }
            GlobalManager.Instance.StartDialogue(dialogue_file_name, speaker_sprite, minigame_id, quests_to_start, quests_to_complete); // queue dialogue
            GlobalManager.Instance.in_dialogue = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() != null) {
            player_near = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() != null) {
            player_near = false;
        }
    }
}
