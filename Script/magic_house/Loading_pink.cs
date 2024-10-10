using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_pink : MonoBehaviour
{
    public string targetSceneName = "magic_house";
    public GameObject loadingScreen;
    public GameObject loadingBar;
    public float loadingSpeed = 100f;
    float targetFillAmount = 558f;

    bool screen_close = true;
    void Start()
    {
        // if (loadingScreen == null || loadingBar == null)
        // {
        //     Debug.Log("LoadingScreen or LoadingBar not found in the current scene.");
        //     return;
        // }
        // if (!StaticParameters_magic.isSceneLoading_magic)
        // {
        //     Time.timeScale = 0;
        //     StaticParameters_magic.isSceneLoading_magic = true;
        //     StartCoroutine(LoadSceneAsync(targetSceneName));
        // }
        loadingScreen.SetActive(true);
    }

    void Update()
    {
        while (loadingBar.transform.position.y < targetFillAmount)
        {
            Screen_Loading();
        }
        if (loadingBar.transform.position.y >= targetFillAmount && screen_close)
        {
            screen_close = false;
            loadingScreen.SetActive(false);
            Debug.Log("close");
        }
    }

    void Screen_Loading()
    {
        Vector3 newPosition = loadingBar.transform.position;
        newPosition.y += Time.deltaTime;
        loadingBar.transform.position = newPosition;
        Debug.Log("loadingBar.transform.position.y:"+loadingBar.transform.position.y);
    }
    // IEnumerator LoadSceneAsync(string sceneName)
    // {
    //     // Asynchronous loading of scenes
    //     AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    //     operation.allowSceneActivation = false; // Do not activate scenes until manually allowed
    //     loadingScreen.SetActive(true);

    //     float targetFillAmount = 0f;

    //     while (!operation.isDone)
    //     {
    //         // Calculate loading progress
    //         targetFillAmount = Mathf.Clamp01(operation.progress / 0.9f);

    //         while (loadingBar.transform.position.y < targetFillAmount)
    //         {
    //             Vector3 newPosition = loadingBar.transform.position;
    //             newPosition.y += Time.unscaledDeltaTime * loadingSpeed;
    //             loadingBar.transform.position = newPosition;
    //             yield return null;
    //         }
    //         if (operation.progress >= 0.9f)
    //         {
    //             break;
    //         }
    //         yield return null;
    //     }

    //     // Make sure the progress bar is loaded
    //     // while (loadingBar.fillAmount < 1f)
    //     // {
    //     //     loadingBar.fillAmount += Time.unscaledDeltaTime * loadingSpeed;
    //     //     yield return null;
    //     // }
    //     loadingScreen.SetActive(false);
    //     Time.timeScale = 1;
    //     StaticParameters_magic.isSceneLoading_magic = false;
    // }
}
