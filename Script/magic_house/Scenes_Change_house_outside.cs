using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes_Change_house_outside : MonoBehaviour
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

    public GameObject player_S;

    void Start()
    {
        player_S = GameObject.Find("Player_S");
        player_S.transform.position = new Vector3(0, 0, -15);
        newPosition_start = new Vector2(737f, -557f);
        static_parameters.into_gameFight_Levels = Random.Range(0, 5);
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 100)
        {
            static_parameters.stage_number = 4;
            loadingBar.rectTransform.anchoredPosition = new Vector2(737f, -557f);
            foreach (var audio in FindObjectsOfType<AudioSource>())
            {
                //audio.Stop();
                if (audio.isPlaying) Debug.Log(audio.name);
            }
            StartCoroutine(LoadSceneWithProgress("Fight_241130"));
        }
    }

    IEnumerator LoadSceneWithProgress(string sceneName)
    {
        loadingScreen.SetActive(true);
        screen_close = true;
        targetFillAmount = 0f; // 重置進度條

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        float elapsedTime = 0f;

        while (!operation.isDone)
        {
            targetFillAmount = maxFillAmount;

            Screen_Loading();
            Loading_bar_wave();
            elapsedTime += Time.deltaTime;

            // 至少跑 minProgressTime 秒才允許場景切換
            if (elapsedTime >= minProgressTime)
            {
                switch (Random.Range(0, 1))
                {
                    case 0:
                        SceneManager.LoadScene("Fight_241130");
                        break;
                }
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
