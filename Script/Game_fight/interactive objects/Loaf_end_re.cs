using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loaf_end_re : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBar;
    public float loadingSpeed = 100f;
    public float maxFillAmount = 275f;
    public float wave_bar_range = 30f;
    private float targetFillAmount = 0f;
    private float minProgressTime = 1.5f;
    private Vector3 newPosition_start;
    private bool wave_return = true;
    private bool screen_close = true;
    static public bool isEnd = false, reNextscene = false;
    float elapsedTime = 0f;
    void Start()
    {
        newPosition_start = new Vector2(737f, -557f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            isEnd = false;
            loadingBar.rectTransform.anchoredPosition = new Vector2(737f, -557f);
            StartCoroutine(LoadSceneWithProgress("Fight_241130"));
        }
    }

    IEnumerator LoadSceneWithProgress(string sceneName)
    {
        loadingScreen.SetActive(true);
        screen_close = true;
        targetFillAmount = 0f; // 重置進度條

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);


        while (!operation.isDone)
        {
            targetFillAmount = maxFillAmount;

            Screen_Loading();
            Loading_bar_wave();
            elapsedTime += Time.deltaTime;

            // 至少跑 minProgressTime 秒才允許場景切換
            if (elapsedTime >= minProgressTime)
            {
                reNextscene = true;
                // SceneManager.LoadScene("Fight_241130");
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        loadingScreen.SetActive(false);
        screen_close = false;
    }

    void Screen_Loading()
    {
        RectTransform rect = loadingBar.rectTransform;
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x,
        Mathf.MoveTowards(rect.anchoredPosition.y, targetFillAmount, (maxFillAmount / minProgressTime) * Time.deltaTime));
    }

    void Loading_bar_wave()
    {
        RectTransform rect = loadingBar.rectTransform;
        Vector2 newPosition_horizontal = rect.anchoredPosition;
        if (newPosition_horizontal.x < newPosition_start.x - wave_bar_range)
        {
            wave_return = false;
        }
        else if (newPosition_horizontal.x > newPosition_start.x + wave_bar_range)
        {
            wave_return = true;
        }

        float moveDirection = wave_return ? 1 : -1;
        newPosition_horizontal.x = Mathf.MoveTowards(newPosition_horizontal.x, newPosition_start.x + (moveDirection * wave_bar_range), loadingSpeed * Time.deltaTime / 3);
        rect.anchoredPosition = newPosition_horizontal;
    }
}
