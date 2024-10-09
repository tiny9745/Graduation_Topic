using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_magic_new : MonoBehaviour
{
    public string targetSceneName = "magic_house";
    public GameObject loadingScreen;
    public Image loadingBar;

    public float loadingSpeed = 0.3f;

    void Start()
    {
        if (loadingScreen == null || loadingBar == null)
        {
            Debug.Log("LoadingScreen or LoadingBar not found in the current scene.");
            return;
        }
        if (!StaticParameters_magic_new.isSceneLoading_magic)
        {
            Time.timeScale = 0;
            StaticParameters_magic_new.isSceneLoading_magic = true;
            StartCoroutine(LoadSceneAsync(targetSceneName));
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Asynchronous loading of scenes
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false; // Do not activate scenes until manually allowed
        loadingScreen.SetActive(true);

        float targetFillAmount = 0f;

        while (!operation.isDone)
        {
            // Calculate loading progress
            targetFillAmount = Mathf.Clamp01(operation.progress / 0.9f);

            // Gradually update the progress bar to the target value
            while (loadingBar.fillAmount < targetFillAmount)
            {
                loadingBar.fillAmount += Time.unscaledDeltaTime * loadingSpeed; // "unscaledDeltaTime" is not affected by "Time.timeScale"
                yield return null;
            }
            if (operation.progress >= 0.9f)
            {
                break;
            }
            yield return null;
        }

        // Make sure the progress bar is loaded
        while (loadingBar.fillAmount < 1f)
        {
            loadingBar.fillAmount += Time.unscaledDeltaTime * loadingSpeed;
            yield return null;
        }
        loadingScreen.SetActive(false);
        Time.timeScale = 1;
        StaticParameters_magic_new.isSceneLoading_magic = false;
    }
}

public static class StaticParameters_magic_new
{
    public static bool isSceneLoading_magic = false;
}
