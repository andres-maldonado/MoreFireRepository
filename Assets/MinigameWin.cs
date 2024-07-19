using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWin : MonoBehaviour
{
    [Tooltip("Comma-separated list of quest names to complete upon minigame win")]
    [SerializeField] private string quests_to_complete;
    [SerializeField] private Sprite dialogue_sprite;
    [SerializeField] private string dialogue_to_queue;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Win()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.minigameWinSound, this.transform.position);
        GetComponent<Animator>().SetBool("isBeaten", true);
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(.5f);
        player.GetComponent<NewPlayerMovement>().DisablePlayer(false);
        foreach (string q in quests_to_complete.Split(","))
        {
            QuestManager.Instance.CompleteQuest(q.Trim());
        }
        GlobalManager.Instance.FreeMinigame();
        if (dialogue_to_queue != "") {
            GlobalManager.Instance.StartDialogue(dialogue_to_queue, dialogue_sprite, -1, "", "");
        }
        Destroy(gameObject);
        yield return null;
    }
}
