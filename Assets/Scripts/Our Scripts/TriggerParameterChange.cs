using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParameterChange : MonoBehaviour
{
    [field: Header("Enter")]
    [SerializeField] float padValue;
    [SerializeField] float bassValue;
    [SerializeField] float plucksValue;
    [SerializeField] float arpValue;
    [field: Header("Exit")]
    [SerializeField] float padExitValue;
    [SerializeField] float bassExitValue;
    [SerializeField] float plucksExitValue;
    [SerializeField] float arpExitValue;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (0 <= padValue && padValue <= 1) { audioManager.MusicParameterChange("Pad", padValue); }
        if (0 <= bassValue && bassValue <= 1) { audioManager.MusicParameterChange("Bass", bassValue); }
        if (0 <= plucksValue && plucksValue <= 1) { audioManager.MusicParameterChange("Plucks", plucksValue); }
        if (0 <= arpValue && arpValue <= 1) { audioManager.MusicParameterChange("Arp", arpValue); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (0 <= padExitValue && padExitValue <= 1) { audioManager.MusicParameterChange("Pad", padExitValue); }
        if (0 <= bassExitValue && bassExitValue <= 1) { audioManager.MusicParameterChange("Bass", bassExitValue); }
        if (0 <= plucksExitValue && plucksExitValue <= 1) { audioManager.MusicParameterChange("Plucks", plucksExitValue); }
        if (0 <= arpExitValue && arpExitValue <= 1) { audioManager.MusicParameterChange("Arp", arpExitValue); }
    }
}
