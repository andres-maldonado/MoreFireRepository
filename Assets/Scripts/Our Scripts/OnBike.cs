using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NewPlayerMovement.Instance.GetComponent<Animator>().SetInteger("spriteInQuestion", 2);
        NewPlayerMovement.Instance.GetComponent<NewPlayerMovement>().speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
