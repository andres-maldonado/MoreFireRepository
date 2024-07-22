using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_step2 : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        this.transform.parent.transform.GetChild(11).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(17).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(18).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(5).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(6).gameObject.SetActive(true);
        this.transform.parent.GetComponent<EvacuationMinigame>().step = this.transform.parent.GetComponent<EvacuationMinigame>().step + 1;
    }
}
