using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Change_Forest : MonoBehaviour
{
    public GameObject CloseDoor01;
    public GameObject CloseDoor02;
    public GameObject player_S;
    public SpriteRenderer Signs;
    public Sprite[] Signs_Sprite;

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
    private int into_gameFight_Levels_memory = 0;
    bool open = false;
    private int all_stage = 6;
    public Animator door_ani01, door_ani02;

    void Start()
    {
        player_S = GameObject.Find("Player_S");
        Invoke("OpenDoor", 4f);
        newPosition_start = new Vector2(737f, -557f);

        if (static_parameters.stage_number == 5)
        {
            static_parameters.into_gameFight_Levels = 6;
            into_gameFight_Levels_memory = static_parameters.into_gameFight_Levels;
            Signs.sprite = Signs_Sprite[1];
        }
        else if (static_parameters.stage_number == 4)
        {
            static_parameters.into_gameFight_Levels = 5;
            into_gameFight_Levels_memory = static_parameters.into_gameFight_Levels;
            Signs.sprite = Signs_Sprite[2];
        }
        else
        {
            static_parameters.into_gameFight_Levels = Random.Range(0, 5);
            into_gameFight_Levels_memory = static_parameters.into_gameFight_Levels;
            Signs.sprite = Signs_Sprite[0];
        }
    }
    private void Update()
    {
        if (loadingBar == null) loadingBar = GameObject.Find("BG_pink").GetComponent<Image>();
        if (loadingScreen == null) loadingScreen = GameObject.Find("Load_pink");
        if (static_parameters.Change_enemy == 0)
        {
            CloseDoor01.SetActive(false);
            CloseDoor02.SetActive(false);
            door_ani01.SetBool("tree_flash", true);
            door_ani02.SetBool("tree_flash", true);
        }
        else
        {
            door_ani01.SetBool("tree_flash", false);
            door_ani02.SetBool("tree_flash", false);
            CloseDoor01.SetActive(true);
            CloseDoor02.SetActive(true);
        }
    }

    private void OpenDoor()
    {
        open = true;
    }

    private void OnTriggerEnter(Collider Hit)
    {
        int i;
        if (Hit.gameObject.CompareTag("Player") && static_parameters.Change_enemy == 0)
        {
            static_parameters.next_door = false;
            static_parameters.into_gameFight_Levels = into_gameFight_Levels_memory;
            static_parameters.stage_number++;
            foreach(var audio in FindObjectsOfType<AudioSource>())audio.Stop();
            if (static_parameters.stage_number < all_stage)
            {
                i = static_parameters.stage_number;
            }
            else
            {
                i = all_stage;
            }
            static_parameters.money += i * 10;
            player_S.transform.localPosition = new Vector3(0, 0, -138);
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
                SceneManager.LoadScene("Fight_241130");
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
