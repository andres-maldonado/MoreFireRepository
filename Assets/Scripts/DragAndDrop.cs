using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Collider2D obj_collider;
    void Start() {
        obj_collider = GetComponent<Collider2D>();
    }

    void Update() {
        Vector3 mousePos = Input.mousePosition;

    }
}
