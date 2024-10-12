using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_241010 : MonoBehaviour
{
    public string targetSceneName = "magic_house";
    public GameObject loadingScreen;
    public Image loadingBar;
    public float loadingSpeed = 100f; // 控制進度條速度
    public float maxFillAmount = 275f; // 用於控制 Y 軸的最大值
    private float targetFillAmount = 0f; // 目標進度
    private float minimumLoadingTime = 2f; // 最少顯示 x 秒
    private float loadingTimeElapsed = 0f; // 計時器

    private bool screen_close = true;

    void Start()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(targetSceneName));
    }

    void Update()
    {
        // 判斷是否關閉加載畫面
        if (loadingBar.transform.position.y >= targetFillAmount && screen_close && loadingTimeElapsed >= minimumLoadingTime)
        {
            screen_close = false;
            loadingScreen.SetActive(false);
            Debug.Log("close");
        }
        else if(screen_close)
        {
            // 根據場景加載進度逐漸提升 Y 軸座標
            Screen_Loading();
        }

        // 累積已經經過的加載時間
        loadingTimeElapsed += Time.deltaTime;
    }

    void Screen_Loading()
    {
        Vector3 newPosition = loadingBar.transform.position;

        // 更新 targetFillAmount，這裡使用 loadingSpeed 控制進度條速度
        newPosition.y = Mathf.MoveTowards(newPosition.y, targetFillAmount, loadingSpeed * Time.deltaTime);
        loadingBar.transform.position = newPosition;
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // 異步加載場景
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false; // 在手動允許之前不激活場景
        loadingTimeElapsed = 0f; // 開始計時

        while (!operation.isDone)
        {
            // 根據加載進度計算 targetFillAmount
            float progress = Mathf.Clamp01(operation.progress / 0.95f);
            targetFillAmount = progress * maxFillAmount; // 將進度轉換為 Y 軸目標

            // 判斷進度
            if (operation.progress >= 0.95f)
            {
                // 確保加載過程至少維持 minimumLoadingTime 秒
                if (loadingTimeElapsed >= minimumLoadingTime)
                {
                    operation.allowSceneActivation = true; // 允許場景激活
                }
            }
            yield return null; // 繼續等待
        }
    }
}
