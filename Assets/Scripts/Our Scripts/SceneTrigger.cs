using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    GameSceneManager gameSceneManager;
    private bool inTrigger = false;
    public int scene;
    public string exit;
    Animator doorIcon;
    // Start is called before the first frame update
    void Start()
    {
        gameSceneManager = GameSceneManager.Instance;
        doorIcon = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger == true)
        {
            gameSceneManager.LoadScene(scene, exit);
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
