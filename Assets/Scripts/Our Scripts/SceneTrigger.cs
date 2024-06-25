using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    GameSceneManager gameSceneManager;
    private bool inTrigger = false;
    public int scene;
    Animator doorIcon;
    // Start is called before the first frame update
    void Start()
    {
        gameSceneManager = GameObject.FindWithTag("SceneManager").GetComponent<GameSceneManager>();
        doorIcon = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true)
        {
            gameSceneManager.LoadScene(scene);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
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
