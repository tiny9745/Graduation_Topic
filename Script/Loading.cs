using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen; // 加载界面
    public Image loadingBar; // 加载进度条

    void Start()
    {
        // 检查变量是否已分配
        if (loadingScreen == null || loadingBar == null)
        {
            Debug.LogError("LoadingScreen or LoadingBar is not assigned in the inspector.");
            return;
        }

        if (!StaticParameters.isSceneLoading)
        {
            StaticParameters.isSceneLoading = true;
            string currentSceneName = SceneManager.GetActiveScene().name; // 获取当前场景的名称
            StartCoroutine(LoadSceneAsync(currentSceneName));
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // 开始异步加载场景
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            // 计算加载进度（Unity报告的进度在0和0.9之间）
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progressValue;
            Debug.Log("Loading progress: " + progressValue);
            yield return null;
        }

        // 确保进度条填满
        loadingBar.fillAmount = 1f;

        // 停止显示加载屏幕
        loadingScreen.SetActive(false);
        StaticParameters.isSceneLoading = false;
    }
}

public static class StaticParameters
{
    public static bool isSceneLoading = false;
}
