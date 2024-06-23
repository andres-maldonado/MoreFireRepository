using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// custom imports
using System.IO;
using TMPro;

// this script will handle dialogue boxes

public class DialogueScript : MonoBehaviour
{
    private TMP_Text mainText;
    private GameObject prompter;
    private Vector3 prompter_origin;
    private double prompter_time;

    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private int minigame_id = 0;
    [SerializeField] private bool start_minigame = true;
    [SerializeField] private int ticks_per_letter = 25;
    
    private int letters_displayed = 0;
    private int counter = 0;
    private string current_text = "";

    private StreamReader file_reader;

    void Awake() {
        mainText = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        prompter = transform.GetChild(0).GetChild(2).gameObject;
        prompter_origin = prompter.transform.position;
    }

    public void Set(string file_name, int game_id = 0, bool start_game = true, int tpl = 25) {
        dialogue_file_name = file_name;
        minigame_id = game_id;
        start_minigame = start_game;
        ticks_per_letter = tpl;
    }

    void Start() {
        // if the file doesn't exist, disable the script so as not to break anything too
        // badly
        if (!File.Exists("Assets/Resources/Dialogue/" + dialogue_file_name + ".txt")) {
            Debug.LogError("No dialogue file named " + dialogue_file_name + " found!");
            gameObject.GetComponent<DialogueScript>().enabled = false;
        }

        file_reader = File.OpenText("Assets/Resources/Dialogue/" + dialogue_file_name + ".txt");

        ReadDialogue();
    }

    void ReadDialogue() {
        if ((current_text = file_reader.ReadLine()) == null) {
            // queue destruction / start minigame
            Destroy(gameObject);
            if (start_minigame) {
                GlobalManager.Instance.StartMinigame(minigame_id);
            }
        }
        letters_displayed = 0;
    }

    void Update() {
        mainText.text = current_text.Substring(0, letters_displayed >= current_text.Length ? current_text.Length : letters_displayed);
        if (counter > ticks_per_letter) {
            counter = 0;
            letters_displayed++;
        }

        counter++;
        promper_time += Time.deltaTime;
        prompter.transform.position = prompter_origin + new Vector3(0, (float)(Math.Sin(prompter_time) * 10), 0);

        if (Input.GetKeyDown(KeyCode.Z)) {
            ReadDialogue();
        }
    }
}
