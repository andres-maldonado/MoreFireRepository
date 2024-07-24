using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMap : MonoBehaviour
{

    private GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Map").GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
