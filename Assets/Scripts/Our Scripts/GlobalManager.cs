using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalManager : MonoBehaviour
{
    private string minigame_folder = "Assets/Resources/MinigamePrefabs";
    private List<GameObject> minigames = new List<GameObject>();

    public class GameTime {
        private float raw_time, gametime_scale_factor;
        public int hours, minutes;
        private bool paused = false;

        public GameTime(int starting_hours = 0, int starting_minutes = 0, float scale = 600.0f) {
            gametime_scale_factor = scale;
            hours = starting_hours;
            minutes = starting_minutes;
        }

        public void UpdateTime() {
            if (!paused) raw_time += 140 * Time.deltaTime / gametime_scale_factor;
            hours = (int)(raw_time / 10 + 8) % 24;
            minutes = (int)(raw_time % 10.0 * 6);

            print(GetPaddedTime());
        }

        public void Toggle() {
            paused = !paused;
        }

        private string GetPaddedITOS(int val) {
            return (val < 10 ? "0" + val : val.ToString());
        }

        public string GetPaddedTime() {
            return GetPaddedITOS(hours) + ":" + GetPaddedITOS(minutes);
        }
    }
    public static GameTime global_time = new GameTime();

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
                    // object was successfully loaded
                    minigames.Add(loaded);
                    Debug.Log(sub_path + " (ID: " + id + ")");
                    id++;
                }
            }
        }
    }
    // END SINGLETON BOILER-PLATE

    private void Update() {
        global_time.UpdateTime();
    }

    // ###### CUSTOM PUBLIC METHODS ######

    // launches one of the minigames using an integer ID
    public void StartMinigame(int minigame_id) {
        Instantiate(minigames[minigame_id], new Vector3(0, 0, 0), Quaternion.identity);
    }
}
