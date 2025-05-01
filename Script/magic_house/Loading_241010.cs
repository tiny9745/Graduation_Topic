using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // 別忘了引入 TextMeshPro 的命名空間

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

    public TextMeshProUGUI Loading_Tips;
    private string[] Loading_Tips_texts;

    private bool wave_return = true;
    private bool screen_close = true;
    bool isChange_tips = false;

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
        Loading_Tips_Change();
    }

    void Update()
    {
        if (loadingBar == null || loadingScreen == null)
            return;

        if (loadingBar.transform.position.y >= targetFillY && screen_close && loadingTimeElapsed >= minimumLoadingTime)
        {
            screen_close = false;
            if (isChange_tips == false) Loading_Tips_Change();
            isChange_tips = true;
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

    private void Loading_Tips_Change()
    {
        Loading_Tips_texts = new string[]
        {
            "聽說全部的日記技能其實有25個！？",
            "魔法師莓莓似乎有著不可告人的身分……",
            "忘記操作了嗎？打開ESC選單再複習一次！",
            "仔細觀察日記碎片……好像有一樣的特徵？",
            "閒暇時可以找魔法師莓莓說說話喔～",
            "遇到說認識莓莓的人了？應該不是壞人吧？",
            "彈珠可以拿來找莓莓升級或跟婆婆購買商品！",
            "路過莓果叢要快速摘取，免得爆炸傷害！",
            "日記碎片為什麼會在受詛咒生物的身上呢？",
            "清除完地圖上的怪物才可以前往下一關！",
            "背包裡的東西不要囤積，盡快使用吧～",
            "出發前記得先翻看日記，嘗試拼湊修復它。",
            "打不贏？那就拼湊更多日記獲取特殊能力！",
            "荊棘過不去嗎？快用魔法泡泡衝刺啊！",
            "怪物只想跟著你，誘敵去荊棘叢裡刺死他們！",
            "沼澤？池塘？不管是什麼，只會拖慢你的速度！",
            "鴨子布偶真的好柔軟～但打人起來也特別疼痛唷！",
            "摸清楚敵人攻擊套路，就不用再害怕他們啦。"
        };
        int randomIndex = Random.Range(0, Loading_Tips_texts.Length);
        Loading_Tips.text = Loading_Tips_texts[randomIndex];
    }
}
