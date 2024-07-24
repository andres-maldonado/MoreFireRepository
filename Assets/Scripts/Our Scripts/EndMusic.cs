using FMODUnity;
using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusic : MonoBehaviour
{
    [SerializeField] EventReference endMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        EventInstance endMusicEventInstance = RuntimeManager.CreateInstance(endMusic);
        endMusicEventInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
