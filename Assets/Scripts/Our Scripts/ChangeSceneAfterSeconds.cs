using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAfterSeconds : MonoBehaviour
{
    public float time;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndChange(time));
    }

    private IEnumerator WaitAndChange(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        NewGameSceneManager.Instance.LoadScene(name, "", false);
    }
}
