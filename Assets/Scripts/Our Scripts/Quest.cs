using UnityEngine;

// allows new Quests to be created from the Editor
[CreateAssetMenu(fileName="Quest", menuName="ScriptableObject/Quest", order=1)]
public class Quest : ScriptableObject
{
    [Tooltip("How the quest is referred to in the game's code; MUST BE UNIQUE!")]
    public string quest_name;
    [Tooltip("What shows up in the questlog.")]
    public string quest_desc;
    [Tooltip("Should this quest be present at the beginning of the game?")]
    public bool is_starter_quest = false;
    public bool completed = false;
}
