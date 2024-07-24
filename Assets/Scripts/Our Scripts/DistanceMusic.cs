using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMusic : MonoBehaviour
{
    private float scaryMix;
    private bool hitTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(NewPlayerMovement.Instance.transform.position.x - gameObject.transform.position.x);
        scaryMix = (60 + NewPlayerMovement.Instance.transform.position.x - gameObject.transform.position.x)/34;
        if (hitTrigger)
        {
            if (scaryMix > 1)
            {
                AudioManager.instance.MusicParameterChange("Pad", 1);
                AudioManager.instance.MusicParameterChange("Drums", 1);
            }
            else if (scaryMix > 0 && scaryMix < 1)
            {
                AudioManager.instance.MusicParameterChange("Pad", scaryMix);
                AudioManager.instance.MusicParameterChange("Drums", scaryMix);
            }
            if (scaryMix < 0)
            {
                AudioManager.instance.MusicParameterChange("Pad", 0);
                AudioManager.instance.MusicParameterChange("Drums", 0);
            }
        }
    }
}
