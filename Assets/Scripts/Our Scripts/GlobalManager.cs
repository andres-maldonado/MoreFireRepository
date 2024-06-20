using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    // SINGLETON BOILER-PLATE
    private static GlobalManager _instance;
    public static GlobalManager Instance { get { return _instance; } }

    private void Awake() {
        // if a GlobalManager game object already exists, don't create a new one
        if (_instance != null && _instance != this) {
            Debug.LogError("Error: attempted to instantiate a second GlobalManager.");
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
    }
    // END SINGLETON BOILER-PLATE



    public void PrintMessage() {
        Debug.Log("Hello, world!");
    }

}
