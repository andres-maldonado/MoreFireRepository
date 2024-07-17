using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    [SerializeField] GameSceneManager sceneManager;
    public void LoadByIndex(int sceneIndex, string entrance)
    {
        sceneManager.LoadScene(sceneIndex, entrance);
    }
    public void Peepeepoopoo()
    {
        sceneManager.LoadScene(1, "1");
    }
    public void MahBaws()
    {
        Application.Quit();
    }
}
