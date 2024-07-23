using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorOnCollision : MonoBehaviour
{
    public string title;
    public string message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GlobalManager.Instance.DisplayError(title, message);
    }
}
