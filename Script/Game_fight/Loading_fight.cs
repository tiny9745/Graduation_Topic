using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public string targetSceneName = "Game_fight";
    public GameObject loadingScreen;
    public Image loadingBar;

    void Start()
    {
        if (!StaticParameters.isSceneLoading)
        {
            StaticParameters.isSceneLoading = true;
            StartCoroutine(LoadSceneAsync(targetSceneName));
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Start asynchronous loading of scenes
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            // Calculate loading progress (Unity reports progress between 0 and 0.9)
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progressValue;
            Debug.Log("Loading progress: " + progressValue);
            yield return null;
        }
        StaticParameters.isSceneLoading = false;
    }
}

public static class StaticParameters
{
    public static bool isSceneLoading = false;
}