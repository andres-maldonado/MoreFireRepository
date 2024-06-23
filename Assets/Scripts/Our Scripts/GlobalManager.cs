using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GlobalManager : MonoBehaviour
{
    // ###### FILE PATHS ######
    private string minigame_folder = "Assets/Resources/MinigamePrefabs";

    // IMPORTANT: these file paths are relative to the Assets/Resources folder
    private string error_path = "Error Message";
    private string dialogue_path = "Dialogue/DialogueBox";

    private GameObject message_prefab, dialogue_prefab;

    private List<GameObject> minigames = new List<GameObject>();

    public class GameTime {
        private float raw_time, gametime_scale_factor;
        public int hours, minutes;
        private bool paused = false;

        public GameTime(float scale = 600.0f) {
            gametime_scale_factor = scale;
        }

        // updates the clock's internal values
        public void UpdateTime() {
            if (!paused) raw_time += 140 * Time.deltaTime / gametime_scale_factor;
            hours = (int)(raw_time / 10 + 8) % 24;
            minutes = (int)(raw_time % 10.0 * 6);
        }

        // toggles whether the clock is paused or not
        public void Toggle() {
            paused = !paused;
        }

        // returns a padded value of the form "XX"
        private string GetPaddedITOS(int val) {
            return (val < 10 ? "0" + val : val.ToString());
        }

        // returns the current game time in a string formatted as "XX:XX"
        public string GetPaddedTime() {
            return GetPaddedITOS(hours) + ":" + GetPaddedITOS(minutes);
        }
    }

    // create a new instance of the GameTime class to use as the global timer
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

        // load prefabs once, then instantiate them later
        message_prefab = Resources.Load(error_path) as GameObject;
        dialogue_prefab = Resources.Load(dialogue_path) as GameObject;
    }
    // END SINGLETON BOILER-PLATE

    private void Update() {
        global_time.UpdateTime(); // updates the global timer
    }

    private void Start() {
        StartDialogue("dialogue_test_file");
    }

    // ###### CUSTOM PUBLIC METHODS ######

    // launches one of the minigames using an integer ID
    public void StartMinigame(int minigame_id) {
        Instantiate(minigames[minigame_id], new Vector3(0, -15, 0), Quaternion.identity);
    }

    public void DisplayError(string error_title, string error_message) {
        GameObject e = Instantiate(message_prefab, Vector3.zero, Quaternion.identity);
        e.GetComponent<ErrorMessage>().SetText(error_title, error_message);
    }

    public void StartDialogue(string branch_name, int game_id = 0, bool start_minigame = true, int tpl = 25) {
        GameObject d = Instantiate(dialogue_prefab, Vector3.zero, Quaternion.identity);
        DialogueScript s = d.GetComponent<DialogueScript>();
        s.Set(branch_name, game_id, start_minigame, tpl);
    }
}
