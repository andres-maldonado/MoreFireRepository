using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private float fire_strength = 1.00f;
    private bool fire_alive = true;

    private void Update() {
        if (fire_strength <= 0.00f) fire_alive = false;
        if (!fire_alive) {
            GetComponent<ParticleSystem>().Stop();
            Destroy(gameObject, 1.25f);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetMouseButton(0) && other.GetComponent<FireScript>() == null) {
            Debug.Log("pressed!");
            fire_strength -= Time.deltaTime;
        }
    }
}
