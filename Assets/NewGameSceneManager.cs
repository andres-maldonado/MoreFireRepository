using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class NewGameSceneManager : MonoBehaviour
{
    private static NewGameSceneManager _instance;
    public static NewGameSceneManager Instance { get { return _instance; } }

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

    private GameObject player;
    private bool can_transition;
    public GameObject transition;
    private Animator transition_anim;

    private AsyncOperationHandle<SceneInstance> scene_handle;

    [Tooltip("Should the scene start with a fade in from black?")]
    public bool start_with_fade_in = true;

    private void Start() {
        transition_anim = transition.GetComponent<Animator>();
        if (start_with_fade_in) StartCoroutine(FadeIn());
        player = GameObject.FindWithTag("Player");
    }

    public void LoadScene(string scene_name, string entrance_name) {
        if (transition == null) {
            transition = GameObject.FindWithTag("MainCanvas").transform.GetChild(1).gameObject;
        }
        StartCoroutine(FadeOut(scene_name, entrance_name));
    }

    IEnumerator AsyncLoadScene(string scene_name, string entrance_name) {
        if (scene_handle.IsValid()) {
            AsyncOperationHandle<SceneInstance> unload_handle = Addressables.UnloadSceneAsync(scene_handle);
            yield return unload_handle;
        }
       
        yield return new WaitForSeconds(0.2f);
        scene_handle = Addressables.LoadSceneAsync(scene_name, LoadSceneMode.Single);
        yield return scene_handle;
        
        if (scene_handle.Status == AsyncOperationStatus.Succeeded) {
            Vector3 entranceCoord = GameObject.Find(entrance_name).transform.localPosition;
            player.transform.localPosition = entranceCoord;
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            StartCoroutine(FadeIn());
        }
    }

    public IEnumerator FadeIn()
    {

        transition_anim.SetBool("FadeOut", false);
        transition.SetActive(true);
        transition_anim.SetBool("FadeIn", true);
        yield return new WaitForSeconds(1);
        transition_anim.SetBool("FadeIn", false);
        transition.SetActive(false);
        //canTransition = true;
    }

    public IEnumerator FadeOut(string scene_name, string entrance_name)
    {
        //canTransition = false;
        transition.SetActive(true);
        transition_anim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(AsyncLoadScene(scene_name, entrance_name));
    }
}