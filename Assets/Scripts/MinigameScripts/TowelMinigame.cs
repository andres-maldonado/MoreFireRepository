using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelMinigame : MonoBehaviour
{
    [SerializeField] private Sprite wet_towel_image;

    private float wetness = 0.00f;
    private bool game_won = false;

    void Update() {
        if (wetness > 1.5f) {
            transform.Find("Towel").GetComponent<SpriteRenderer>().sprite = wet_towel_image;
        }
        if (wetness > 2.1f && !game_won) {
            GetComponentInParent<MinigameWin>().Win();
            Destroy(transform.Find("Towel").gameObject);
            game_won = true;
        }

        Debug.Log(wetness);
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.name == "Towel") {
            wetness += 0.01f;
        }
    }
}
