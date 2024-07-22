using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evac_warning : MonoBehaviour
{
    [SerializeField] GameObject player_icon;
    public void OnTriggerEnter2D()
    {
        if (this.GetComponentInParent<EvacuationMinigame>().step == 0)
        {
            GlobalManager.Instance.DisplayError("There might be a more efficient route...", "Let's try finding a more direct path!");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 1)
        {
            GlobalManager.Instance.DisplayError("This doesn't seem to be the best way to go...", "Let's try finding a more direct path!");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 2)
        {
            GlobalManager.Instance.DisplayError("That's the wrong way!", "Let's try going the other way");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 3)
        {
            GlobalManager.Instance.DisplayError("This is not where I remember the shelter being...", "The shelter has to be somewhere around here...");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 4)
        {
            GlobalManager.Instance.DisplayError("This is not  I remember the shelter being...", "The shelter has to be somewhere around here...");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 5)
        {
            GlobalManager.Instance.DisplayError("Hmmm I'm pretty sure that I have gone this way...", "The shelter has to be somewhere around here...");
        }
    }
}
