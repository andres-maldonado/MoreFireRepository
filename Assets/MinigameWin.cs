using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWin : MonoBehaviour
{
    [Tooltip("Comma-separated list of quest names to complete upon minigame win")]
    [SerializeField] private string quests_to_complete;
    [Tooltip("Comma-separated list of quest names to start upon minigame win")]
    [SerializeField] private string quests_to_start = "";
    [SerializeField] private Sprite dialogue_sprite;
    [SerializeField] private string dialogue_to_queue;
    private GameObject inventory;
    [SerializeField] int itemCount;
    public List<Item> reward_items = new List<Item>();
    [SerializeField] Sprite bat;
    [SerializeField] bool instance;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inventory = GameObject.FindWithTag("Inventory");
    }

    public void Win()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.minigameWinSound, this.transform.position);
        GetComponent<Animator>().SetBool("isBeaten", true);
        //for (int i = 0; i < itemCount; i++) { inventory.GetComponent<Inventory>().inv.Add(reward_items[i]); }
        StartCoroutine(EndGame());
        if(instance)
        {
            gameObject.GetComponent<Extinguisher>().StopSound();
        }
    }

    IEnumerator EndGame()
    {
        Debug.Log("Ending");
        yield return new WaitForSeconds(.5f);
        if (dialogue_to_queue == "") NewPlayerMovement.Instance.DisablePlayer(false);
        foreach (string q in quests_to_complete.Split(","))
        {
            QuestManager.Instance.CompleteQuest(q.Trim());
        }
        Debug.Log("Ending2");
        GlobalManager.Instance.FreeMinigame();
        if (dialogue_to_queue != "") {
            GlobalManager.Instance.StartDialogue(dialogue_to_queue, dialogue_sprite, "", quests_to_start, "");
        }
        Debug.Log("Ending3");
        Destroy(gameObject);
        Debug.Log("Ending4");
        yield return null;
    }
}
