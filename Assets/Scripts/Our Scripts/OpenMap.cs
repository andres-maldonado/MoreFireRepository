using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    [SerializeField] Animator map;
    bool open = false;
    private void Start()
    {
        map = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!open)
            {
                map.Play("MapEnter");
                open = true;
            }
            else if (open)
            {
                map.Play("MapExit");
                open = false;
            }
        }
    }
}
