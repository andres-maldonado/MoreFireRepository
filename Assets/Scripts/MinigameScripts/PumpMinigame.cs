using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpMinigame : MonoBehaviour
{
    private float tire_fullness = 0.00f;
    [SerializeField] private float tire_deflate_rate = 1.0f;
    [SerializeField] private float breath_strength = 0.032f;
    private bool game_finished = false;

    private Transform meter;

    private void Awake() {
        meter = transform.GetChild(3).transform;
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.E)) {
            tire_fullness += breath_strength;
        }
        Debug.Log(tire_fullness);
        tire_fullness -= tire_deflate_rate * Time.deltaTime;
        tire_fullness = tire_fullness < 0.0f ? 0.0f : tire_fullness;
        meter.localScale = new Vector3(7.8f * tire_fullness, 1.0f, 1.0f);

        if (tire_fullness >= 1.0f && !game_finished) {
            GetComponentInParent<MinigameWin>().Win();
            game_finished = true;
        }
    }
}
