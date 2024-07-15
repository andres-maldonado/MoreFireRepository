using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evac_warning : MonoBehaviour
{
    [SerializeField] GameObject player_icon;
    private float scale = 2.83f;
    public void OnTriggerEnter2D()
    {
        print("wrong way");
    }
    void Update()
    {
        if (this.GetComponentInParent<EvacuationMinigame>().step == 1)
        {
            this.transform.position = new Vector2 (-5.15f * scale, 0.15f * scale);
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 2)
        {
            this.transform.position = new Vector2 (2.1f * scale, -2.99f * scale);
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 3)
        {
            this.transform.position = new Vector2 (-2.1f * scale, -3.4f * scale);
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 4)
        {
            this.transform.position = new Vector2 (-6.9f * scale, -2.3f * scale);
        }
        else if (this.GetComponentInParent<EvacuationMinigame>().step == 5)
        {
            this.transform.position = new Vector2 (-2.1f * scale, -3.4f * scale);
            Destroy(this);
        }
    }
}
