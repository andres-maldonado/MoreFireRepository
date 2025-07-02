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
            GlobalManager.Instance.DisplayError("それは間違った方向です！", "他の方向に行ってみよう！");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 1)
        {
            GlobalManager.Instance.DisplayError("それは間違った方向です！", "他の方向に行ってみよう！");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 2)
        {
            GlobalManager.Instance.DisplayError("それは間違った方向です！", "他の方向に行ってみよう！");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 3)
        {
            GlobalManager.Instance.DisplayError("それは間違った方向です！", "他の方向に行ってみよう！");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 4)
        {
            GlobalManager.Instance.DisplayError("それは間違った方向です！", "他の方向に行ってみよう！");
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 5)
        {
            GlobalManager.Instance.DisplayError("それは間違った方向です！", "他の方向に行ってみよう！(E)");
        }
    }
}
