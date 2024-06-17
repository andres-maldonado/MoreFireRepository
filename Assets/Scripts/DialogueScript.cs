using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// custom imports
using System.IO;
using TMPro;

// this script will handle dialogue boxes

public class DialogueScript : MonoBehaviour
{
    // important things
    public string startingBranch = "testing_branch1";
    const string dialoguePath = @"Assets/Misc/dialogue_tree.txt";
    private string targetText;

    GameObject textBox;

    (string, string) ReadDialogue() {
        
    }

    void Start()
    {
        textBox = GameObject.Find("DialogueText");

        TMP_Text t = textBox.GetComponent<TMP_Text>();

        if (!File.Exists(dialoguePath)) {
            // if the file path can't be found, create a new text file with placeholder
            // dialogue to avoid bad things happening
            using (StreamWriter sw = File.CreateText(dialoguePath)) {
                sw.WriteLine(startingBranch + ": ");
                sw.WriteLine("  msg: \"An error has occurred, no valid dialogue file exists.\"");
                sw.WriteLine("  next: TERMINUS");
            }
        }
        else {
            // the file path was found, meaning a valid dialogue tree file exists,
            // so let's use it
            using (StreamReader sr = File.OpenText(dialoguePath)) {
                string s;
                while ((s = sr.ReadLine()) != null) {
                    print(s);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
