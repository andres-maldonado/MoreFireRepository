using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    [SerializeField] Object minigame;
    [SerializeField] bool oneTime;
    private bool inTrigger = false;
    private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindWithTag("MainCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true)
        {
            StartGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }

    private void StartGame()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().DisablePlayer(true);
        Instantiate(minigame, canvas.transform);
        Destroy(gameObject);
    }
}
