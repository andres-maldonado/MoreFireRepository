using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepData : MonoBehaviour
{
    private static KeepData _instance;
    public static KeepData Instance { get { return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
