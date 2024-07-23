using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private EventInstance musicEventInstance;
    private EventInstance dialogue;
    public static AudioManager instance { get; private set; }
    private void Start()
    {
        InitializeMusic(FMODEvents.instance.song);
        DontDestroyOnLoad(gameObject);
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
        }
        
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        Debug.Log("Played" + eventReference);
        return eventInstance;
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        PLAYBACK_STATE playbackState;
        musicEventInstance.getPlaybackState(out playbackState);
        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            musicEventInstance = CreateInstance(musicEventReference);
            musicEventInstance.start();
        }
        else
        {
            Debug.Log("Music already playing");
        }
    }

    public IEnumerator ChangeMusic(EventReference newTrack)
    {
        Debug.Log("AAA");
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEventInstance = CreateInstance(newTrack);
        musicEventInstance.start();
        yield return null;
    }

    public void MusicParameterChange(string parameterName, float parameterValue)
    {
        musicEventInstance.setParameterByName(parameterName, parameterValue);
    }
}
