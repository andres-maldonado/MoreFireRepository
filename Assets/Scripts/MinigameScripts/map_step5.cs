using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_step5 : MonoBehaviour
{
    public bool done = false;
    void OnTriggerEnter2D()
    {
        this.transform.parent.transform.GetChild(8).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(14).gameObject.SetActive(true);
        done = true;
    }
}
