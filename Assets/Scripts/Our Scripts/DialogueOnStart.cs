using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnStart : MonoBehaviour
{
    public string text;
    public Sprite sprite;
    public string minigame;
    // Start is called before the first frame update
    void Start()
    {
        GlobalManager.Instance.StartDialogue(text, sprite, minigame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
