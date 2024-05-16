using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_migic : MonoBehaviour
{
    public string targetSceneName = "magic_house";
    public GameObject loadingScreen;
    public Image loadingBar;

    void Start()
    {
        if (!StaticParameters_magic.isSceneLoading_magic)
        {
            StaticParameters_magic.isSceneLoading_magic = true;
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
            Debug.Log("Loading progress: " + loadingBar.fillAmount);
            // Calculate loading progress (Unity reports progress between 0 and 0.9)
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progressValue;
            yield return null;
        }
        StaticParameters_magic.isSceneLoading_magic = false;
    }
}
public static class StaticParameters_magic
{
    public static bool isSceneLoading_magic = false;
}
