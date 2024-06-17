using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWin : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        GetComponent<Animator>().SetBool("isBeaten", true);
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(.5f);
        player.GetComponent<PlayerMovement>().DisablePlayer(false);
        Destroy(gameObject);
        yield return null;
    }
}
