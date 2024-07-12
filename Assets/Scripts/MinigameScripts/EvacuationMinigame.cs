using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvacuationMinigame : MonoBehaviour
{

    public GameObject evac_game;
    [SerializeField] BoxCollider2D firststep;

    void OnTriggerEnter2D(Collider2D other)
    {
        print("hello");
    }
    // Start is called before the first frame update
    void Start()
    {
        firststep = firststep.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
}
