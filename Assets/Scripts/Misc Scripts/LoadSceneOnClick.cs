using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    [SerializeField] GameSceneManager sceneManager;
    public void LoadByIndex(int sceneIndex, string entrance)
    {
        //sceneManager.LoadScene(sceneIndex, entrance);
    }

    public void LoadByName(string scene_name, string entrance) {
        sceneManager.LoadScene(scene_name, entrance);
    }
}
