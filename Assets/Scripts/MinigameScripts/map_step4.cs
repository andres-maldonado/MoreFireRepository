using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_step4 : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        this.transform.parent.transform.GetChild(13).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(19).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(20).gameObject.SetActive(true);
        this.transform.parent.transform.GetChild(7).gameObject.SetActive(false);
        this.transform.parent.transform.GetChild(8).gameObject.SetActive(true);
        this.transform.parent.GetComponent<EvacuationMinigame>().step = this.transform.parent.GetComponent<EvacuationMinigame>().step + 1;
    }
}
