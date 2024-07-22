using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_step1 : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        this.transform.parent.transform.GetChild(10).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(16).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(17).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(4).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(5).gameObject.SetActive(true);
        this.transform.parent.GetComponent<EvacuationMinigame>().step = this.transform.parent.GetComponent<EvacuationMinigame>().step + 1;
    }
}
