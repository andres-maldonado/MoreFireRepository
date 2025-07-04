using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishMinigame : MonoBehaviour
{
    private GameObject fires_parent;
    private GameObject door_fire;
    private GameObject nozzle;
    private bool game_won = false;
    private ParticleSystem extinguisher_particles;

    void Start() {
        fires_parent = transform.Find("Fires").gameObject;
        nozzle = transform.Find("Extinguwuisher").gameObject;
        door_fire = GameObject.Find("/DoorFire");
        extinguisher_particles = nozzle.GetComponent<ParticleSystem>();
        extinguisher_particles.Stop();
    }

    void Update() {
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + Camera.main.transform.position.x, Input.mousePosition.y, Camera.main.transform.position.z + Camera.main.nearClipPlane));
        mouse_position.z = 0f;
        nozzle.transform.position = mouse_position;

        if (Input.GetMouseButtonDown(0)) {
            extinguisher_particles.Play();
        }
        if (Input.GetMouseButtonUp(0)) {
            extinguisher_particles.Stop();
        }

        if (fires_parent.transform.childCount == 0 && !game_won) {
            GetComponentInParent<MinigameWin>().Win();
            Destroy(nozzle);
            Destroy(door_fire);
            game_won = true;
        }
    }
}
