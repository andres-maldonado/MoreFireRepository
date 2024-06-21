using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : MonoBehaviour
{
    private bool minigame_ended = false;
    private Vector3 screen_bottom = new Vector3(0, -15, 0);

    enum end_behavior {
        move_and_destroy,
        destroy,
    }
    [SerializeField] private end_behavior on_win = end_behavior.move_and_destroy;

    public void Win() { 
        AudioManager.instance.PlayOneShot(FMODEvents.instance.minigameWinSound, this.transform.position);
        if (on_win == end_behavior.destroy) Destroy(gameObject);
        else if (on_win == end_behavior.move_and_destroy) minigame_ended = true;
    }

    void Start() {
        // make sure the minigame object takes on proper default values when instantiated
        transform.position = screen_bottom;
        minigame_ended = false;
    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, minigame_ended ? screen_bottom : Vector3.zero, 0.003f);
        if (minigame_ended && Vector3.Distance(transform.position, screen_bottom) < 0.15 && on_win == end_behavior.move_and_destroy) Destroy(gameObject);
    }
}
