using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_241010 : MonoBehaviour
{
    public string targetSceneName = "magic_house";
    public GameObject loadingScreen;
    public Image loadingBar;
    public float loadingSpeed = 100f;
    public float maxFillAmount = 275f;
    private float scaleFactor;

    public float wave_bar_range = 30f;

    private float targetFillY = 0f;
    private float waveCenterX = 0f;
    private float minimumLoadingTime = 2f;
    private float loadingTimeElapsed = 0f;

    public Vector3 newPosition_start;
    private GameObject BlackScreen;
    private GameObject player_S;

    private bool wave_return = true;
    private bool screen_close = true;

    void Start()
    {
        scaleFactor = Screen.height / 1080f;
        maxFillAmount *= scaleFactor;

        BlackScreen = GameObject.Find("Black");
        player_S = GameObject.Find("Player_S");

        if (player_S != null)
            player_S.transform.localPosition = new Vector3(0, 0, -138);

        if (BlackScreen != null && Death_MC.isDead)
            BlackScreen.SetActive(false);

        if (loadingBar == null)
            loadingBar = GameObject.Find("BG_pink")?.GetComponent<Image>();

        if (loadingScreen == null)
            loadingScreen = GameObject.Find("Load_pink");

        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        if (loadingBar != null)
        {
            newPosition_start = loadingBar.transform.position;
            waveCenterX = newPosition_start.x;
        }

        StartCoroutine(LoadSceneAsync(targetSceneName));
    }

    void Update()
    {
        if (loadingBar == null || loadingScreen == null)
            return;

        if (loadingBar.transform.position.y >= targetFillY && screen_close && loadingTimeElapsed >= minimumLoadingTime)
        {
            screen_close = false;
            loadingScreen.SetActive(false);
        }
        else if (screen_close)
        {
            Screen_Loading();
            Loading_bar_wave();
        }

        loadingTimeElapsed += Time.deltaTime;
    }

    void Screen_Loading()
    {
        Vector3 newPosition = loadingBar.transform.position;
        newPosition.y = Mathf.MoveTowards(newPosition.y, targetFillY, loadingSpeed * Time.deltaTime);
        loadingBar.transform.position = newPosition;
    }

    void Loading_bar_wave()
    {
        Vector3 newPosition = loadingBar.transform.position;
        float waveLeft = waveCenterX - wave_bar_range;
        float waveRight = waveCenterX + wave_bar_range;

        if (newPosition.x <= waveLeft)
            wave_return = true;
        else if (newPosition.x >= waveRight)
            wave_return = false;

        float xMove = loadingSpeed * Time.deltaTime / 3f;
        newPosition.x += wave_return ? xMove : -xMove;
        loadingBar.transform.position = newPosition;
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        loadingTimeElapsed = 0f;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.95f);
            targetFillY = progress * maxFillAmount;

            if (progress >= 0.95f && loadingTimeElapsed >= minimumLoadingTime)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
