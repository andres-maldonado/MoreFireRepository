using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishMinigame : MonoBehaviour
{
    private GameObject fires_parent;
    private GameObject nozzle;

    private bool game_won = false;

    void Start() {
        fires_parent = transform.Find("Fires").gameObject;
        nozzle = transform.Find("Nozzle").gameObject;
    }

    void Update() {
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + Camera.main.transform.position.x, Input.mousePosition.y, Camera.main.transform.position.z + Camera.main.nearClipPlane));
        mouse_position.z = 0f;
        nozzle.transform.position = mouse_position;

        if (fires_parent.transform.childCount == 0 && !game_won) {
            GetComponentInParent<MinigameWin>().Win();
            game_won = true;
        }
    }
}
