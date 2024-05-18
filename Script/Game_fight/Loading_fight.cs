using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_fight : MonoBehaviour
{
    public string targetSceneName = "Game_fight";
    public GameObject loadingScreen;
    public Image loadingBar;

    public float loadingSpeed = 0.3f;

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
        // 开始异步加载场景
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
                loadingBar.fillAmount += Time.deltaTime * loadingSpeed;
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
            loadingBar.fillAmount += Time.deltaTime * loadingSpeed;
            yield return null;
        }
        loadingScreen.SetActive(false);
        StaticParameters.isSceneLoading = false;
    }
}

public static class StaticParameters
{
    public static bool isSceneLoading = false;
}