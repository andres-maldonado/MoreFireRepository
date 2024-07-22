using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    [SerializeField] Animator map;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            map.Play("MapEnter");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            map.Play("MapExit");
        }
    }
}
