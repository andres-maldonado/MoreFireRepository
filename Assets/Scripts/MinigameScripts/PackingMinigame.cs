using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingMinigame : MonoBehaviour
{
    // an array of strings containing the names of all GameObjects which should
    // be packed
    [SerializeField] string[] should_pack;
    Dictionary<string, bool> packed = new Dictionary<string, bool>();

    BoxCollider2D collection_trigger;

    bool Validate() {
        // ensures all the items which are supposed to be packed actually exist
        for (int i = 0; i < should_pack.Length; i++) {
            if (transform.Find(should_pack[i]) == null) {
                Debug.LogError("Error: could not find child named " + should_pack[i] + ".");
                return false;
            }
        }
        
        // checks if the current GameObject has a parent object
        if (transform.parent == null) {
            Debug.LogError("Error: minigame script has no parent GameObject!");
            return false;
        }

        // at this point we know the parent GameObject exists, so we check if
        // it has the necessary "MinigameWin" component
        if (!transform.parent.TryGetComponent<MinigameWin>(out MinigameWin MGW)) {
            Debug.LogError("Error: minigame's parent doesn't have required MinigameWin component!");
            return false;
        }
        return true;
    }

    void Start() {
        // checks if something is wrong with the structure of the minigame and prevents
        // the script from executing (after printing an error message)
        bool is_valid = Validate();
        if (!is_valid) {
            GetComponent<PackingMinigame>().enabled = false;
        }

        collection_trigger = GetComponent<BoxCollider2D>();
        if (!collection_trigger.isTrigger) {
            Debug.LogError("Error: Bag collector collider is not a trigger!");
        }

        // initializes the map to show that nothing has been packed yet
        for (int i = 0; i < should_pack.Length; i++) {
            packed.Add(should_pack[i], false);
        }
    }

    void CheckForWin() {
        bool has_won = true;
        foreach (var item in packed) {
            if (item.Value == false) {
                has_won = false;
            }
        }
        if (has_won) {
            transform.parent.GetComponent<MinigameWin>().Win();
        }
    }

    // this will be built upon later
    void OnTriggerEnter2D(Collider2D other) {
        if (packed.ContainsKey(other.name)) {
            packed[other.name] = true;
            Destroy(other.gameObject);
            CheckForWin();
        }
    }
    
}
