using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalManager : MonoBehaviour
{
    private string minigame_folder = "Assets/Resources/MinigamePrefabs";
    private List<GameObject> minigames = new List<GameObject>();

    public static double time = 0.00f;

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

            int id = 0;

            // load in all minigame prefabs
            foreach (string path in Directory.GetFiles(minigame_folder)) {
                string[] split_path = path.Split("/");
                string sub_path = "";

                // removes the "Assets/Resources/" portion of the path to work
                // properly with Resources.Load()
                for (int j = 2; j < split_path.Length; j++) {
                    sub_path += split_path[j];
                    if (j != split_path.Length - 1) {
                        sub_path += "/";
                    }
                }

                // removes the .prefab suffix which breaks Resources.Load()
                split_path = sub_path.Split(".");
                sub_path = "";
                for (int k = 0; k < split_path.Length - 1; k++) {
                    sub_path += split_path[k];
                    if (k != split_path.Length - 2) {
                        sub_path += ".";
                    }
                }

                // loads the actual prefab into the List containing all minigames
                GameObject loaded = Resources.Load(sub_path) as GameObject;
                if (loaded != null) {
                    minigames.Add(loaded);
                    Debug.Log(sub_path + " (ID: " + id + ")");
                    id++;
                }
            }
        }
    }
    // END SINGLETON BOILER-PLATE

    // 
    public void StartMinigame(int minigame_id) {
        Instantiate(minigames[minigame_id], new Vector3(0, 5, 0), Quaternion.identity);
    }

}
