using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes_Change_Magic_house : MonoBehaviour
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
    public AudioSource Ad;
    public AudioClip Leave;
    public Magician_talk magician_talk;

    void Start()
    {
        newPosition_start = new Vector2(737f, -557f);
    }

    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && (static_parameters.teaching_stop == 1 || static_parameters.teaching_stop >= 100))
        {
            static_parameters.isUpgrade_tmp = false;
            magician_talk.close_magician_talk();
            loadingBar.rectTransform.anchoredPosition = new Vector2(737f, -557f);
            StartCoroutine(LoadSceneWithProgress("house_outside"));
        }
    }

    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && (static_parameters.teaching_stop == 1 || static_parameters.teaching_stop >= 100))
        {
            static_parameters.isUpgrade_tmp = false;
            magician_talk.close_magician_talk();
            loadingBar.rectTransform.anchoredPosition = new Vector2(737f, -557f);
            StartCoroutine(LoadSceneWithProgress("house_outside"));
        }
    }

    IEnumerator LoadSceneWithProgress(string sceneName)
    {
        loadingScreen.SetActive(true);
        screen_close = true;
        targetFillAmount = 0f; // 重置進度條

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        float elapsedTime = 0f;
        Ad.PlayOneShot(Leave);
        while (!operation.isDone)
        {
            targetFillAmount = maxFillAmount;

            Screen_Loading();
            Loading_bar_wave();
            elapsedTime += Time.deltaTime;

            // 至少跑 minProgressTime 秒才允許場景切換
            if (elapsedTime >= minProgressTime)
            {
                SceneManager.LoadScene("house_outside");
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
