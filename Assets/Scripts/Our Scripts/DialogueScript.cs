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

    private Vector3 prompter_origin;
    private double prompter_time;

    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private string minigame_id = "BikeMinigame";
    [SerializeField] private int ticks_per_letter = 25;
    [SerializeField] private string[] start_quests;
    [SerializeField] private string[] end_quests;
    private List<Item> give_objects;

    public SpriteRenderer mc_sprite, speaker_sprite;
    private Image prompter_img;

    // (false) => other speaker
    // (true) => MC
    private bool speaking = true;
    
    private int letters_displayed = 0;
    private int counter = 0;
    private string current_text = "";
    private int first_letter = 0;

    private StreamReader file_reader;

    void Awake() {
        mainText = transform.GetChild(1).GetComponent<TMP_Text>();
        prompter = transform.GetChild(2).gameObject;
        prompter_img = prompter.GetComponent<Image>();
        prompter_origin = prompter.transform.localPosition;
    }

    public void Set(string file_name, Sprite speaker_image, string game_id = "", string quests_to_start = "", string quests_to_end = "", List<Item> objs = null, int tpl = 25) {
        dialogue_file_name = file_name;
        speaker_sprite = GameObject.Find("SpeakerPortrait").GetComponent<SpriteRenderer>();
        speaker_sprite.sprite = sp_sprite;
        minigame_id = game_id;
        start_quests = quests_to_start.Split(",");
        end_quests = quests_to_end.Split(",");
        ticks_per_letter = tpl;
        give_objects = objs;
    }

    void Start() {
        // if the file doesn't exist, disable the script so as not to break anything too badly
        if (!File.Exists(Application.streamingAssetsPath + "/Dialogue/" + dialogue_file_name + ".txt")) {
            Debug.LogError("No dialogue file named " + dialogue_file_name + " found!");
            gameObject.GetComponent<DialogueScript>().enabled = false;
        }

        file_reader = File.OpenText(Application.streamingAssetsPath + "/Dialogue/" + dialogue_file_name + ".txt");

        mc_sprite = GameObject.Find("MCPortrait").GetComponent<SpriteRenderer>();

        ReadDialogue();
    }

    void ReadDialogue() {
        if ((current_text = file_reader.ReadLine()) == null) {
            // queue destruction / start minigame
            Destroy(gameObject);
            if (give_objects != null) {
                Inventory i = GameObject.FindWithTag("MainCanvas").transform.Find("Inventory").gameObject.GetComponent<Inventory>();
                for (int j = 0; j < give_objects.Count; j++) 
                {
                    if (i.inv.Count < 5) 
                    {
                        i.inv.Add(give_objects[j]);
                    }
                }
            }
            GlobalManager.Instance.in_dialogue = false;
            NewPlayerMovement.Instance.DisablePlayer(false);
            foreach (string q in end_quests) {
                if (q.Trim() != "") QuestManager.Instance.CompleteQuest(q.Trim());
            }
            foreach (string q in start_quests) {
                if (q.Trim() != "") QuestManager.Instance.StartQuest(q.Trim());
            }

            if (minigame_id != "") {
                GlobalManager.Instance.StartMinigame(minigame_id);
            }
        }

        if (current_text != null) {
            first_letter = current_text.IndexOf(":") + 1;
            if (current_text.Substring(0, first_letter - 1).Trim() == "MC") speaking = true;
            else speaking = false;
        }
        
        prompter_time = -3.0;
        prompter_img.enabled = false;
        letters_displayed = 0;
    }

    void Update() {
        mc_sprite.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(mc_sprite.color.a, (speaking ? 1.0f : 0.25f), 0.12f));
        speaker_sprite.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(speaker_sprite.color.a, (speaking ? 0.25f : 1.0f), 0.12f));

        mainText.text = current_text.Substring(first_letter + 1, letters_displayed >= current_text.Length - first_letter - 1 ? current_text.Length - first_letter - 1 : letters_displayed);
        if (counter > ticks_per_letter) {
            counter = 0;
            letters_displayed++;
        }

        counter++;
        prompter_time += Time.deltaTime;
        if (letters_displayed == current_text.Length && !prompter_img.enabled) {
            prompter_img.enabled = true;
        }
        prompter.transform.localPosition = prompter_origin + new Vector3(0, (float)(Math.Abs(Math.Sin(prompter_time * 4) * 15f)), 0);

        if (Input.GetKeyDown(KeyCode.E)) {
            // if the message is finished typing, move on to the next message
            if (letters_displayed >= current_text.Length) ReadDialogue();
            // if it's not finished yet, show the whole message
            else { letters_displayed = current_text.Length; }
        }
    }
}
