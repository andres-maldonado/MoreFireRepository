using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GlobalManager : MonoBehaviour
{
    public GameObject message_prefab, dialogue_prefab;

    private AsyncOperationHandle<GameObject> minigame_handle;

    // this keeps track of which minigames have already been completed so the triggers don't respawn
    private Dictionary<string, bool> minigame_completion = new Dictionary<string, bool>();

    public bool in_dialogue = false;

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
        }
    }
    // END SINGLETON BOILER-PLATE

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        global_time.UpdateTime(); // updates the global timer
    }

    // ###### CUSTOM PUBLIC METHODS ######

    public bool IsComplete(string minigame_address) {
        if (!minigame_completion.ContainsKey(minigame_address)) {
            Debug.Log("Error: no minigame named " + minigame_address + ".");
            return false;
        }
        return minigame_completion[minigame_address];
    }
    
    private string current_minigame;
    private IEnumerator LoadMinigame(string address) {
        minigame_handle = Addressables.LoadAssetAsync<GameObject>(address);
        yield return minigame_handle;

        if (minigame_handle.Status == AsyncOperationStatus.Succeeded) {
            if (!minigame_completion.ContainsKey(address)) {
                current_minigame = address;
                minigame_completion.Add(address, false);
            }
            Instantiate(minigame_handle.Result, GameObject.FindWithTag("MainCanvas").transform);
        }
    }

    // launches one of the minigames using an integer ID
    public void StartMinigame(string minigame_id) {
        //Instantiate(minigames[minigame_id], GameObject.FindWithTag("MainCanvas").transform);
        StartCoroutine(LoadMinigame(minigame_id));
    }

    public void FreeMinigame() {
        minigame_completion[current_minigame] = true;
        current_minigame = "";
        Addressables.Release(minigame_handle);
        Resources.UnloadUnusedAssets();
    }

    public void DisplayError(string error_title, string error_message) {
        GameObject e = Instantiate(message_prefab, GameObject.FindWithTag("MainCanvas").transform);
        e.GetComponent<ErrorMessage>().SetText(error_title, error_message);
    }

    public void StartDialogue(string branch_name, Sprite sp_sprite, string game_id = "", string quests_to_start = "", string quests_to_end = "", int tpl = 2) {
        GameObject d = Instantiate(dialogue_prefab, GameObject.FindWithTag("MainCanvas").transform);
        DialogueScript s = d.GetComponent<DialogueScript>();
        s.Set(branch_name, sp_sprite, game_id, quests_to_start, quests_to_end, tpl);
        in_dialogue = true;
    }
}
