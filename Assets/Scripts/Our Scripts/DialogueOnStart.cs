using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnStart : MonoBehaviour
{
    [SerializeField] private string dialogue_file_name = "dialogue_test_file";
    [SerializeField] private Sprite speaker_sprite;
    [SerializeField] private string minigame_id = "";
    [SerializeField] private string quests_to_start;
    [SerializeField] private string quests_to_complete;
    // public string text;
    // public Sprite sprite;
    // public string minigame;
    [SerializeField] private List<Item> give_objs = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        //GlobalManager.Instance.StartDialogue(text, sprite, minigame);
        GlobalManager.Instance.StartDialogue(dialogue_file_name, speaker_sprite, minigame_id, quests_to_start, quests_to_complete, give_objs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
