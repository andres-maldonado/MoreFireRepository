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
    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private int ticks_per_letter = 10;
    
    private int letters_displayed = 0;
    private int counter = 0;
    private string current_text = "";

    private StreamReader file_reader;

    void Awake() {
        mainText = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
    }

    void Start() {
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
            GlobalManager.Instance.StartMinigame(0);
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

        if (Input.GetKeyDown(KeyCode.Z)) {
            ReadDialogue();
        }
    }
}
