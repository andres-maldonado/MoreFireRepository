using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorMessage : MonoBehaviour
{
    private TMP_Text title;
    private TMP_Text description;

    void Awake()
    {
        title = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        description = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
    }

    public void SetText(string titleString, string descriptionString)
    {
        title.text = titleString;
        description.text = descriptionString;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Close());
        }
    }

    IEnumerator Close()
    {
        transform.GetChild(0).GetComponent<Animator>().SetBool("Closed", true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
