using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
