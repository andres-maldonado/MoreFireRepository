using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] EventReference dragItem;
    [SerializeField] private bool flip_direction = true;
    // moves the object to the mouse location and stops its velocity
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag() {
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + Camera.main.transform.position.x, Input.mousePosition.y, Camera.main.transform.position.z + Camera.main.nearClipPlane));
        mouse_position.z = 0f;
        Debug.Log(mouse_position);
        AudioManager.instance.PlayOneShot(dragItem, this.transform.position);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = mouse_position * (flip_direction ? -1 : 1);
    }
}
