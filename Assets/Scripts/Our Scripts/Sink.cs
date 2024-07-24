using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    [SerializeField] EventReference sink;
    EventInstance sinkInstance;
    PLAYBACK_STATE state;
    FMOD.Studio.STOP_MODE stopMode;
    public bool inside;
    // Start is called before the first frame update
    void Start()
    {
        sinkInstance = RuntimeManager.CreateInstance(sink);
        sinkInstance.start();
    }

    // Update is called once per frame
    public void StopSound()
    {
        sinkInstance.stop(stopMode);
    }
}
