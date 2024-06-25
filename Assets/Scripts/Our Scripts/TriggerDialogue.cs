using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private int minigame_id = -1;
    [SerializeField] private string quests_to_start;
    [SerializeField] private string quests_to_complete;

    private void Start() {
        if (GetComponent<SpriteRenderer>() == null) {
            Debug.LogError("Error: no SpriteRenderer component attached to DialogueTrigger; no speaker sprite available.");
            GetComponent<TriggerDialogue>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerMovement>() != null) {
            // the collider that entered the trigger is the player
            other.GetComponent<PlayerMovement>().DisablePlayer(true); // stop movement
            GlobalManager.Instance.StartDialogue(dialogue_file_name, GetComponent<SpriteRenderer>().sprite, minigame_id, quests_to_start, quests_to_complete); // queue dialogue
        }
    }
}
