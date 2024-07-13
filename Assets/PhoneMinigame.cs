using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMinigame : MonoBehaviour
{
    private string game_stage = "passcode";

    private void Update() {
        
    }

    public void ReceiveAlerts() {
        Debug.Log("clicked :D");
        GetComponentInParent<MinigameWin>().Win();
    }
}
