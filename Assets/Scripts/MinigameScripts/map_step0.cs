using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_step0 : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        this.transform.parent.transform.GetChild(9).gameObject.SetActive(true); //draws line
        this.transform.parent.transform.GetChild(15).gameObject.SetActive(false); //deletes previous path indicator
        this.transform.parent.transform.GetChild(16).gameObject.SetActive(true); //draws the next path indicator
        this.transform.parent.transform.GetChild(3).gameObject.SetActive(false); //deletes previous warning path indicator
        this.transform.parent.transform.GetChild(4).gameObject.SetActive(true); //draws the next path indicator
        this.transform.parent.GetComponent<EvacuationMinigame>().step = this.transform.parent.GetComponent<EvacuationMinigame>().step + 1;
    }
}
