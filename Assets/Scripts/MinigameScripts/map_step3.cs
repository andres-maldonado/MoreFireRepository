using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_step3 : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        this.transform.parent.transform.GetChild(12).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(18).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(19).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(6).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(7).gameObject.SetActive(true);
        this.transform.parent.GetComponent<EvacuationMinigame>().step = this.transform.parent.GetComponent<EvacuationMinigame>().step + 1;
    }
}
