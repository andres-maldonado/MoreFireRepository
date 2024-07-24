using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class AddressableScenes : MonoBehaviour
{

    private string[] manager_names = new string[] {"GlobalManager", "AudioManager", "QuestManager", "GameSceneManager"};

    // Start is called before the first frame update
    IEnumerator Init()
    {
        // DontDestroyOnLoad(gameObject);
        AsyncOperationHandle<SceneInstance> init_scene_op = Addressables.LoadSceneAsync("StartScreen", LoadSceneMode.Single);
        yield return init_scene_op;
    }

    IEnumerator SpawnManagers() {
        foreach (string m in manager_names) {
            AsyncOperationHandle<GameObject> loadOp = Addressables.LoadAssetAsync<GameObject>(m);
            yield return loadOp;

            if (loadOp.Result != null) {
                Instantiate(loadOp.Result, transform);
            }
        }
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Init());
    }
}
