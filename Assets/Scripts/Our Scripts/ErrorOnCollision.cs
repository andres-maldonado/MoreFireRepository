using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorOnCollision : MonoBehaviour
{
    public string title;
    public string message;
    public void OnCollisionEnter2D()
    {
        GlobalManager.Instance.DisplayError(title, message);
    }
}
