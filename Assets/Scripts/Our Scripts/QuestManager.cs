using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TMP_Text questlog_UI;

    private Dictionary<string, (Quest, bool)> quest_bank = new Dictionary<string, (Quest, bool)>();
    [SerializeField] private List<Quest> active_quests = new List<Quest>();

    // SINGLETON BOILER-PLATE
    private static QuestManager _instance;
    public static QuestManager Instance { get { return _instance; } }

    private void LoadQuestBank() {
        foreach (string path in Directory.GetFiles("Assets/Resources/Quests")) {
            // this successfully trims a filepath of the form "Assets/Resources/Quests/[quest_name].[extension]"
            // to "Quests/[quest_name]", which makes it compatible with Resources.Load()
            string snipped_path = path.Substring(17).Substring(0, path.LastIndexOf('.') - 17);
            Quest q = Resources.Load(snipped_path) as Quest;

            if (q != null) {
                quest_bank.Add(q.quest_name, (q, false));
            }
        }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Debug.LogError("Error: attempted to instantiate a second GlobalManager.");
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
            LoadQuestBank();
            UpdateLogText();
        }
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

    public void CompleteQuest(string quest_name) {
        if (active_quests.Contains(quest_bank[quest_name].Item1)) {
            active_quests.Remove(quest_bank[quest_name].Item1);
            Debug.Log("Why young hero, it seems you have completed the " + quest_name + " quest!");
            quest_bank[quest_name] = (quest_bank[quest_name].Item1, true);
            UpdateLogText();
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