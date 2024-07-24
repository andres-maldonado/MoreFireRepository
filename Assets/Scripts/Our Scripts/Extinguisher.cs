using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] EventReference extinguisher;
    EventInstance extinguisherInstance;
    PLAYBACK_STATE state;
    FMOD.Studio.STOP_MODE stopMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        extinguisherInstance.getPlaybackState(out state);
        if(Input.GetMouseButtonDown(0) && state == PLAYBACK_STATE.STOPPED)
        {
            extinguisherInstance = RuntimeManager.CreateInstance(extinguisher);
            extinguisherInstance.start();
        }
        if (Input.GetMouseButtonUp(0))
        {
            extinguisherInstance.stop(stopMode);
        }
    }
    public void StopSound()
    {
        extinguisherInstance.stop(stopMode);
    }
}
