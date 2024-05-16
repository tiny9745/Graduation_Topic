using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_fight : MonoBehaviour
{
    public string targetSceneName = "Game_fight";
    public GameObject loadingScreen;
    public Image loadingBar;

    public float loadingSpeed = 0.3f; // 设置进度条更新速度，1为正常速度，0.5为减慢一倍

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
        operation.allowSceneActivation = false; // 暂时不激活场景，直到我们手动允许
        loadingScreen.SetActive(true);

        float targetFillAmount = 0f;

        while (!operation.isDone)
        {
            // 计算加载进度（Unity报告的进度在0和0.9之间）
            targetFillAmount = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log("Target loading progress: " + targetFillAmount);

            // 将进度条的填充值逐渐更新到目标值
            while (loadingBar.fillAmount < targetFillAmount)
            {
                loadingBar.fillAmount += Time.deltaTime * loadingSpeed;
                Debug.Log("Current loading progress: " + loadingBar.fillAmount);
                yield return null;
            }
            if (operation.progress >= 0.9f)
            {
                break;
            }
            yield return null;
        }

        // 确保进度条最终填充到1（场景加载完成）
        while (loadingBar.fillAmount < 1f)
        {
            loadingBar.fillAmount += Time.deltaTime * loadingSpeed;
            yield return null;
        }

        loadingScreen.SetActive(false); // 隐藏加载界面
        StaticParameters.isSceneLoading = false;
    }
}

public static class StaticParameters
{
    public static bool isSceneLoading = false;
}
