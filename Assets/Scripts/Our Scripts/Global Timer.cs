using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using TMPro;

public class GlobalTimer : MonoBehaviour
{
    private static GlobalTimer _instance;
    public static GlobalTimer Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    public TMP_Text timer;
    public float time = 0;
    public int realTimeInSeconds;

    private int hour;
    private int minute;

    public bool frozen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            time += 140 * Time.deltaTime / (realTimeInSeconds);
            hour = (int)time / 10 + 8;
            minute = (int)(time % 10f * 6);
            timer.text = hour + ":" + (minute < 10 ? "0" + (minute) : (minute));
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            frozen = !frozen;
        }
    }
}
