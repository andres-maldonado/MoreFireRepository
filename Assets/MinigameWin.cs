using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWin : MonoBehaviour
{
    [Tooltip("Comma-separated list of quest names to complete upon minigame win")]
    [SerializeField] private string quests_to_complete;
    public GameObject player;

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
        player.GetComponent<PlayerMovement>().DisablePlayer(false);
        GlobalManager.Instance.FreeMinigame();
        Debug.Log("destroyed");
        Destroy(gameObject);
        foreach (string q in quests_to_complete.Split(","))
        {
            QuestManager.Instance.CompleteQuest(q.Trim());
        }
        yield return null;
    }
}
