using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// custom imports
using System.IO;
using TMPro;

// this script will handle dialogue boxes

public class DialogueScript : MonoBehaviour
{
    private TMP_Text mainText;
    private GameObject prompter;
    private SpriteRenderer speaker_sprite;

    private Vector3 prompter_origin;
    private double prompter_time;

    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private int minigame_id = -1;
    [SerializeField] private int ticks_per_letter = 25;
    [SerializeField] private string[] start_quests;
    [SerializeField] private string[] end_quests;
    
    private int letters_displayed = 0;
    private int counter = 0;
    private string current_text = "";

    private StreamReader file_reader;

    void Awake() {
        mainText = transform.GetChild(1).GetComponent<TMP_Text>();
        prompter = transform.GetChild(2).gameObject;
        speaker_sprite = transform.GetChild(3).GetComponent<SpriteRenderer>();
        prompter_origin = prompter.transform.position;
    }

    public void Set(string file_name, Sprite speaker_image, int game_id = -1, string quests_to_start = "", string quests_to_end = "", int tpl = 25) {
        dialogue_file_name = file_name;
        speaker_sprite.sprite = speaker_image;
        minigame_id = game_id;
        start_quests = quests_to_start.Split(",");
        end_quests = quests_to_end.Split(",");
        ticks_per_letter = tpl;
    }

    void Start() {
        // if the file doesn't exist, disable the script so as not to break anything too badly
        if (!File.Exists(Application.streamingAssetsPath + "/Dialogue/" + dialogue_file_name + ".txt")) {
            Debug.LogError("No dialogue file named " + dialogue_file_name + " found!");
            gameObject.GetComponent<DialogueScript>().enabled = false;
        }

        file_reader = File.OpenText(Application.streamingAssetsPath + "/Dialogue/" + dialogue_file_name + ".txt");

        ReadDialogue();
    }

    void ReadDialogue() {
        if ((current_text = file_reader.ReadLine()) == null) {
            // queue destruction / start minigame
            Destroy(gameObject);
            GlobalManager.Instance.in_dialogue = false;
            GameObject.FindWithTag("Player").GetComponent<NewPlayerMovement>().DisablePlayer(false);
            foreach (string q in end_quests) {
                if (q.Trim() != "") QuestManager.Instance.CompleteQuest(q.Trim());
            }
            foreach (string q in start_quests) {
                if (q.Trim() != "") QuestManager.Instance.StartQuest(q.Trim());
            }

            if (minigame_id > -1) {
                GlobalManager.Instance.StartMinigame("BikeMinigame");
            }
        }
        prompter_time = -3.0;
        prompter.GetComponent<Image>().enabled = false;
        letters_displayed = 0;
    }

    void Update() {
        mainText.text = current_text.Substring(0, letters_displayed >= current_text.Length ? current_text.Length : letters_displayed);
        if (counter > ticks_per_letter) {
            counter = 0;
            letters_displayed++;
        }

        counter++;
        prompter_time += Time.deltaTime;
        if (letters_displayed == current_text.Length && !prompter.GetComponent<Image>().enabled) {
            prompter.GetComponent<Image>().enabled = true;
        }
        prompter.transform.position = prompter_origin + new Vector3(0, (float)(Math.Abs(Math.Sin(prompter_time * 4) * 0.05f)), 0);

        if (Input.GetKeyDown(KeyCode.Z)) {
            // if the message is finished typing, move on to the next message
            if (letters_displayed >= current_text.Length) ReadDialogue();
            // if it's not finished yet, show the whole message
            else { letters_displayed = current_text.Length; }
        }
    }
}
