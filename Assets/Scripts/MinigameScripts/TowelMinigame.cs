using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TowelMinigame : MonoBehaviour
{
    [SerializeField] private Sprite wet_towel_image;

    private float wetness = 0.00f;
    private bool game_won = false;

    void Update() {
        if (wetness > 1.5f && wetness < 1.6f) {
            transform.Find("Towel").GetComponent<SpriteRenderer>().sprite = wet_towel_image;
        }
        if (wetness > 2.1f && !game_won)
        {
            game_won = true;
            NewPlayerMovement.Instance.GetComponent<Animator>().SetInteger("spriteInQuestion", 1);
            GetComponentInParent<MinigameWin>().Win();
            Destroy(transform.Find("Towel").gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.name == "Towel") {
            wetness += 0.01f;
        }
    }
}
