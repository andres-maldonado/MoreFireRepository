using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] private TMP_Text questlog_UI;

    public List<Quest> all_quests = new List<Quest>();
    //public List<Item> reward_items = new List<Item>();
    private Dictionary<string, (Quest, bool)> quest_bank = new Dictionary<string, (Quest, bool)>();

    [SerializeField] private List<Quest> active_quests = new List<Quest>();

    // SINGLETON BOILER-PLATE
    private static QuestManager _instance;
    public static QuestManager Instance { get { return _instance; } }

    private void LoadQuestBank() {
        foreach (Quest q in all_quests)
        {
            quest_bank.Add(q.quest_name, (q, false));
            if (q.is_starter_quest)
            {
                active_quests.Add(q);
            }
        }
    }

    public bool IsComplete(string quest_name) {
        if (!quest_bank.ContainsKey(quest_name)) {
            Debug.LogError("No quest named " + quest_name + "!");
            return false;
        }

        return quest_bank[quest_name].Item2;
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Debug.LogError("Error: attempted to instantiate a second QuestManager.");
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
            LoadQuestBank();
            UpdateLogText();
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    public void StartQuest(string quest_name) {
        if (quest_bank[quest_name].Item2) {
            Debug.LogError("Tried to start quest \"" + quest_name + "\", but this quest has already been completed!");
        }
        else {
            active_quests.Add(quest_bank[quest_name].Item1);
            Debug.Log("Beginning the valiant quest " + quest_name + "!");
            UpdateLogText();
        }
    }
    /*void add_to_inv()
    {
        if (quest_bank["route_map"].Item2 == true)//map
        {
            if (!inventory.GetComponent<Inventory>().in_inventory("Map"))
            {
                inventory.GetComponent<Inventory>().inv.Add(reward_items[0]);
            }
        }
        else if (quest_bank["checkout"].Item2 == true && inventory.GetComponent<Inventory>().in_inventory(""))// checkout
        {
            if (!inventory.GetComponent<Inventory>().in_inventory("Batteries") && !inventory.GetComponent<Inventory>().in_inventory("EnergyFood") && !inventory.GetComponent<Inventory>().in_inventory("Medkit"))
            {
                inventory.GetComponent<Inventory>().inv.Add(reward_items[1]);
                inventory.GetComponent<Inventory>().inv.Add(reward_items[2]);
                inventory.GetComponent<Inventory>().inv.Add(reward_items[3]);
            }
        }        
    }*/

    public void CompleteQuest(string quest_name) {
        if (quest_name.Length == 0) return;
        if (active_quests.Contains(quest_bank[quest_name].Item1)) {
            active_quests.Remove(quest_bank[quest_name].Item1);
            Debug.Log("Why young hero, it seems you have completed the " + quest_name + " quest!");
            quest_bank[quest_name] = (quest_bank[quest_name].Item1, true);
            UpdateLogText();
            //add_to_inv();
        }
        else {
            Debug.LogError("Tried to complete quest \"" + quest_name + "\", but this quest was never started!");
        }
    }

    public void UpdateLogText() {
        string q_string = "";
        for (int i = 0; i < active_quests.Count; i++) {
            q_string += active_quests[i].quest_desc + (i == active_quests.Count - 1 ? "" : "\n\n");
        }
        questlog_UI.text = q_string;
    }
}