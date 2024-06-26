using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    private static GameSceneManager _instance;
    public static GameSceneManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    GameObject player;
    bool canTransition;

//Like the GameManager, this should be it's own gameobject

[Tooltip("The black screen transition that will be used")]
    public GameObject Transition;

    [Tooltip("If you want to open this scene with a fade in")]
    public bool startWithFadeIn = true;
    private bool noFadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        if (startWithFadeIn)
        {
            StartCoroutine(FadeIn());
        }
    }


    //This function should be called to other scripts so that way you have the transition working
    public void LoadScene(int SceneIndex, string entrance)
    {
        if (canTransition)
        {
            StartCoroutine(FadeOut());
            StartCoroutine(LoadAsyncScene(SceneIndex, entrance));
        }
    }

    IEnumerator LoadAsyncScene(int SceneIndex, string entrance)
    {
        yield return new WaitForSeconds(.5f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneIndex);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Transform entranceCoord = GameObject.Find(entrance).transform;
        player = GameObject.FindWithTag("Player");
        player.transform.localPosition = entranceCoord.transform.localPosition;
        Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    public IEnumerator FadeIn()
    {
        Transition.SetActive(true);
        Transition.GetComponent<Animator>().SetBool("FadeIn", true);
        yield return new WaitForSeconds(1);
        Transition.GetComponent<Animator>().SetBool("FadeIn", false);
        Transition.SetActive(false);
        canTransition = true;
    }

    public IEnumerator FadeOut()
    {
        canTransition = false;
        Transition.SetActive(true);
        Transition.GetComponent<Animator>().SetBool("FadeOut", true);
        yield return new WaitForSeconds(.5f);
        Transition.GetComponent<Animator>().SetBool("FadeOut", false);
        StartCoroutine(FadeIn());
    }
}
