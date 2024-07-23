using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParameterChange : MonoBehaviour
{
    [field: Header("Enter")]
    [SerializeField] float padValue = -1;
    [SerializeField] float bassValue = -1;
    [SerializeField] float plucksValue = -1;
    [SerializeField] float arpValue = -1;
    [SerializeField] float drumsValue = -1;
    [SerializeField] float rideValue = -1;
    [SerializeField] float prepOrEvacValue = -1;
    [field: Header("Exit")]
    [SerializeField] float padExitValue = -1;
    [SerializeField] float bassExitValue = -1;
    [SerializeField] float plucksExitValue = -1;
    [SerializeField] float arpExitValue = -1;
    [SerializeField] float drumsExitValue = -1;
    [SerializeField] float rideExitValue = -1;
    [SerializeField] float prepOrEvacExitValue = -1;
    private AudioManager audioManager;
    [SerializeField] bool onTrigger;
    private bool inside;
    private void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inside = true;
        if (!onTrigger) 
        {
            if (0 <= padValue && padValue <= 1) { audioManager.MusicParameterChange("Pad", padValue); }
            if (0 <= bassValue && bassValue <= 1) { audioManager.MusicParameterChange("Bass", bassValue); }
            if (0 <= plucksValue && plucksValue <= 1) { audioManager.MusicParameterChange("Plucks", plucksValue); }
            if (0 <= arpValue && arpValue <= 1) { audioManager.MusicParameterChange("Arp", arpValue); }
            if (0 <= drumsValue && drumsValue <= 1) { audioManager.MusicParameterChange("Drums", drumsValue); }
            if (0 <= rideValue && rideValue <= 1) { audioManager.MusicParameterChange("Ride", rideValue); }
            if (0 <= prepOrEvacValue && prepOrEvacValue <= 1) { audioManager.MusicParameterChange("PrepOrEvac", prepOrEvacValue); }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(Wait());
        if (!onTrigger)
        {
            if (0 <= padExitValue && padExitValue <= 1) { audioManager.MusicParameterChange("Pad", padExitValue); }
            if (0 <= bassExitValue && bassExitValue <= 1) { audioManager.MusicParameterChange("Bass", bassExitValue); }
            if (0 <= plucksExitValue && plucksExitValue <= 1) { audioManager.MusicParameterChange("Plucks", plucksExitValue); }
            if (0 <= arpExitValue && arpExitValue <= 1) { audioManager.MusicParameterChange("Arp", arpExitValue); }
            if (0 <= drumsExitValue && drumsExitValue <= 1) { audioManager.MusicParameterChange("Drums", drumsExitValue); }
            if (0 <= rideExitValue && rideExitValue <= 1) { audioManager.MusicParameterChange("Ride", rideExitValue); }
            if (0 <= prepOrEvacExitValue && prepOrEvacExitValue <= 1) { audioManager.MusicParameterChange("PrepOrEvac", prepOrEvacExitValue); }
        }
    }
    private void Update()
    {
        Debug.Log("inside is " + inside+", onTrigger is "+onTrigger+", "+Input.GetKeyDown(KeyCode.E));
        if(onTrigger && inside && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Go!");
            if (0 <= padValue && padValue <= 1) { audioManager.MusicParameterChange("Pad", padValue); }
            if (0 <= bassValue && bassValue <= 1) { audioManager.MusicParameterChange("Bass", bassValue); }
            if (0 <= plucksValue && plucksValue <= 1) { audioManager.MusicParameterChange("Plucks", plucksValue); }
            if (0 <= arpValue && arpValue <= 1) { audioManager.MusicParameterChange("Arp", arpValue); }
            if (0 <= drumsValue && drumsValue <= 1) { audioManager.MusicParameterChange("Drums", drumsValue); }
            if (0 <= rideValue && rideValue <= 1) { audioManager.MusicParameterChange("Ride", rideValue); }
            if (0 <= prepOrEvacValue && prepOrEvacValue <= 1) { audioManager.MusicParameterChange("PrepOrEvac", prepOrEvacValue); }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
        inside = false;
    }
}
