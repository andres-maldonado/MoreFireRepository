using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] EventReference dragItem;
    [SerializeField] private bool flip_direction = true;
    private bool hover = false;
    // moves the object to the mouse location and stops its velocity
    void OnMouseDrag() {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x + Camera.main.transform.position.x, Input.mousePosition.y, Camera.main.transform.position.z + Camera.main.nearClipPlane));
        mouse_position.z = 0f;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0f;
        transform.position = mouse_position * (flip_direction ? -1 : 1);
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.PlayOneShot(dragItem, this.transform.position);
        }
    }

    private void OnMouseEnter()
    {
        hover = true;
    }
    private void OnMouseExit()
    {
        hover = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && hover)
        {
            AudioManager.instance.PlayOneShot(dragItem, this.transform.position);
        }
    }
}
