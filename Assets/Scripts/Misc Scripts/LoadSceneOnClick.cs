using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    [SerializeField] string scene;
    [SerializeField] string entrance;

    public void LoadByIndex(int sceneIndex, string entrance)
    {
        //sceneManager.LoadScene(sceneIndex, entrance);
    }

    public void Loading() {
        NewGameSceneManager.Instance.LoadScene(scene, entrance, false);
    }
}
