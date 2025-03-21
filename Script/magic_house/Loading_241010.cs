using System.Collections;
using Unity.VisualScripting;
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
    float scaleFactor = Screen.height / 1080f; // 依據螢幕解析度縮放
    public float wave_bar_range = 30f;
    private float targetFillAmount = 0f; // 目標進度
    private float minimumLoadingTime = 2f; // 最少顯示 x 秒
    private float loadingTimeElapsed = 0f; // 計時器
    public Vector3 newPosition_start;
    private GameObject BlackScreen;
    private GameObject player_S;

    bool wave_return = true;

    private bool screen_close = true;

    void Start()
    {
        BlackScreen = GameObject.Find("Black");
        player_S = GameObject.Find("Player_S");
        player_S.transform.localPosition = new Vector3(0, 0, -138);
        Debug.Log("transform.localPosition: " + player_S.transform.localPosition);
        if (BlackScreen != null && Death_MC.isDead)
        {
            BlackScreen.SetActive(false);
        }
        newPosition_start = loadingBar.transform.position;
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(targetSceneName));
        maxFillAmount = 275f * scaleFactor; // 讓 maxFillAmount 根據解析度縮放
    }

    void Update()
    {
        if (loadingBar == null) loadingBar = GameObject.Find("BG_pink").GetComponent<Image>();
        if (loadingScreen == null) loadingScreen = GameObject.Find("Load_pink");

        // 判斷是否關閉加載畫面
        if (loadingBar.transform.position.y >= targetFillAmount && screen_close && loadingTimeElapsed >= minimumLoadingTime)
        {
            screen_close = false;
            loadingScreen.SetActive(false);
        }
        else if (screen_close)
        {
            Screen_Loading(); // 根據場景加載進度逐漸提升 Y 軸座標
            Loading_bar_wave();
        }

        // 累積已經經過的加載時間
        loadingTimeElapsed += Time.deltaTime;
    }

    void Screen_Loading()
    {
        Vector3 newPosition_vertical = loadingBar.transform.position;

        // 更新 targetFillAmount，這裡使用 loadingSpeed 控制進度條速度
        newPosition_vertical.y = Mathf.MoveTowards(newPosition_vertical.y, targetFillAmount, loadingSpeed * Time.deltaTime);
        loadingBar.transform.position = newPosition_vertical;
    }

    void Loading_bar_wave()
    {
        Vector3 newPosition_horizontal = loadingBar.transform.position;
        if (newPosition_horizontal.x < newPosition_start.x - wave_bar_range)
        {
            wave_return = false;
        }
        else if (newPosition_horizontal.x > newPosition_start.x + wave_bar_range)
        {
            wave_return = true;
        }
        if (wave_return)
        {
            newPosition_horizontal.x = Mathf.MoveTowards(newPosition_horizontal.x, targetFillAmount, loadingSpeed * Time.deltaTime / 3);
            loadingBar.transform.position = newPosition_horizontal;
        }
        else
        {
            newPosition_horizontal.x = Mathf.MoveTowards(newPosition_horizontal.x, targetFillAmount, -loadingSpeed * Time.deltaTime / 3);
            loadingBar.transform.position = newPosition_horizontal;
        }
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
