using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using FMODUnity;

public class PhoneMinigame : MonoBehaviour
{
    [SerializeField] private string correct_passcode = "1984";
    private string game_stage = "passcode";
    private string current_passcode = "";
    GameObject keypad;
    [SerializeField] EventReference text;
    [SerializeField] EventReference wrongPasscode;
    [SerializeField] EventReference open;

    private void Start() {
        keypad = transform.Find("Keypad").gameObject;
        foreach (Transform c in keypad.transform) {
            if (c.GetComponent<Button>() == null) continue;
            c.GetComponent<Button>().onClick.AddListener(() => EnterKey(c.GetChild(0).GetComponent<TMP_Text>().text.Trim()));
        }
    }

    public void ReceiveAlerts() {
        Debug.Log("clicked :D");
        GetComponentInParent<MinigameWin>().Win();
    }

    public void EnterKey(string n) {
        current_passcode += n;
        AudioManager.instance.PlayOneShot(text, this.transform.position);
        if (current_passcode.Length == 4) {
            if (current_passcode != correct_passcode) {
                current_passcode = "";
                AudioManager.instance.PlayOneShot(wrongPasscode, this.transform.position);
            }
            else {
                keypad.SetActive(false);
                AudioManager.instance.PlayOneShot(open, this.transform.position);
                transform.Find("AlertsButton").gameObject.SetActive(true);
                transform.Find("Square").gameObject.SetActive(false);
            }
        }
        Debug.Log(current_passcode);
    }
}
