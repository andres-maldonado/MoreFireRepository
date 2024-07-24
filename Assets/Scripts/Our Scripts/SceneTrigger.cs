using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [Tooltip("A comma-separated list of the quests that must be completed before the scene trigger can take place")]
    public string necessary_quests;
    [Tooltip("Name of dialogue file which will be queued when the trigger is interacted with and the necessary quests have not been completed")]
    public string failure_dialogue;
    public Sprite blank_sprite;
    NewGameSceneManager gameSceneManager;
    private bool inTrigger = false;
    public int scene;
    public string scene_name;
    public string exit;
    public bool isLong;
    public bool noButton = false;
    Animator doorIcon;
    [SerializeField] EventReference newSong;
    // Start is called before the first frame update
    void Start()
    {
        gameSceneManager = NewGameSceneManager.Instance;
        doorIcon = transform.GetChild(0).GetComponent<Animator>();
    }

    private bool QuestsComplete() {
        if (necessary_quests.Length == 0) return true;
        foreach (string q in necessary_quests.Split(",")) {
            if (!QuestManager.Instance.IsComplete(q.Trim())) {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) || noButton) && inTrigger == true)
        {
            if (QuestsComplete())
            {
                gameSceneManager.LoadScene(scene_name, exit, isLong);
            }
            else {
                GlobalManager.Instance.StartDialogue(failure_dialogue, blank_sprite);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
        doorIcon.SetBool("inTrigger", true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
        doorIcon.SetBool("inTrigger", false);
    }
}
