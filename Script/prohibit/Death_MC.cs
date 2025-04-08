using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death_MC : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject MC_S, MC_Img;
    public GameObject Blood_Screen, Death;
    public Image Blood_Screen_Img;
    private float fadeDuration = 3.2f;
    public Animator animator;
    static public bool isDead = true;
    private bool sceneLoaded = false;

    public Sprite Death_Img_Sprite;
    public Image Death_Img;
    private AudioSource audioSource; // 音效來源
    public AudioClip[] audioClip; // 音效片段

    void Start()
    {
        MC_S = GameObject.Find("Player_S");
        MC_Img = GameObject.Find("F S0100");
        audioSource = GetComponent<AudioSource>();
        Diary_icon[] all_icon = Resources.LoadAll<Diary_icon>("icon_skill");
        // 訂閱場景加載完成的事件
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // 取消訂閱事件以防止重複觸發
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.MC_HP <= 0 && isDead)
        {
            Blood_Screen_Img.color = new Color(0f, 0f, 0f, 0.5f);
            Death.SetActive(true);
            animator.SetTrigger("Death");
            StartCoroutine(FadeToFullOpacity());
            Blood_Screen.SetActive(true);
        }
    }

    private IEnumerator FadeToFullOpacity()
    {
        bool close = true;
        isDead = false;
        Color startColor = Blood_Screen_Img.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            if (close && elapsedTime > 0.2f)
            {
                close = false;
                MC_Img.SetActive(false);
            }
            Blood_Screen_Img.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        static_parameters.stage_number--;
        sceneLoaded = false; // 重置場景加載標記

        // 加載場景
        Death_Img.sprite = Death_Img_Sprite;
        SceneManager.LoadScene("magic_house");

        // 等待場景加載完成
        yield return new WaitUntil(() => sceneLoaded);
        yield return new WaitForSeconds(2f);
        // 在場景加載完成後執行重生邏輯
        MC_S.transform.position = new Vector3(0, 0, 0);
        Death.transform.localScale *= 5;
        Death.transform.localPosition = new Vector3(0, -400, -42);
        animator.SetTrigger("Reborn");
        audioSource.PlayOneShot(audioClip[0]);
        // 確保動畫結束後延遲7.5秒再繼續執行後續程式碼
        yield return new WaitForSeconds(7.5f);
        Death.transform.localPosition = new Vector3(0, -50, -42);
        Death.transform.localScale /= 5;
        Death.SetActive(false);
        MC_Img.SetActive(true);
        Blood_Screen.SetActive(false);
        Blood_Screen_Img.color = targetColor;
        Death_Img.sprite = Death_Img_Sprite;
        isDead = true;
        static_parameters.Ani_state = 0;
        Ani_MC.isAttackPlaying = false;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "magic_house")
        {
            // 設定場景加載完成標記為 true
            sceneLoaded = true;
        }
    }

    private bool AnimatorIsPlaying(string animationName)
    {
        // 確認當前動畫狀態是否是指定的動畫
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime < 1f; // 若動畫仍在播放，返回true
    }
}
