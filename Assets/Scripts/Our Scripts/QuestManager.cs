using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TMP_Text questlog_UI;

    // SINGLETON BOILER-PLATE
    private static QuestManager _instance;
    public static QuestManager Instance { get { return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Debug.LogError("Error: attempted to instantiate a second GlobalManager.");
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
    }

    private Dictionary<string, (bool, bool)> quest_bank = new Dictionary<string, (bool, bool)>();
    [SerializeField] private List<Quest> active_quests = new List<Quest>();

    public void StartQuest(string quest_name) {
        Debug.Log("Beginning the valiant quest " + quest_name + "!");
    }

    public void CompleteQuest(string quest_name) {
        Debug.Log("Why young hero, it seems you have completed the " + quest_name + " quest!");
    }
}