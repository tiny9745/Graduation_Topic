using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MC_col : MonoBehaviour
{
    public GameObject MC;
    private RectTransform HPimg_White,HPimg_Red, HPimg_Green;
    public string targetSceneName = "Game_fight";
    void Start()
    {
        MC = GameObject.Find("Player");
        Renderer renderer = MC.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
    void Update()
    {
        // Get player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Convert movement direction to world space
        movement = transform.TransformDirection(movement);

        // Move character
        transform.position += movement * static_parameters.MC_Wspeed * Time.deltaTime;
    }

    // Subscribe to events
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Unsubscribe event
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check whether the loaded scene is the target scene
        if (scene.name == targetSceneName)
        {
            FindHPImage();
        }
    }
    private void FindHPImage()
    {
        // Find all "Image" in the scene
        RectTransform[] foundRectTransforms = FindObjectsOfType<RectTransform>();
        foreach (RectTransform rectTransform in foundRectTransforms)
        {
            // 檢查 RectTransform 组件的名稱是否為指定名稱"
            if (rectTransform.name == "HP_Max")
            {
                HPimg_White = rectTransform;
                Debug.Log("成功找到名為 'HP_Max' 的 RectTransform 组件0");
            }
            if (rectTransform.name == "HP_change")
            {
                HPimg_Green = rectTransform;
                Debug.Log("成功找到名為 'HP_change' 的 RectTransform 组件1");   
            }
            if (rectTransform.name == "HP_change_after")
            {
                HPimg_Red = rectTransform;
                Debug.Log("成功找到名為 'HP_change_after' 的 RectTransform 组件2");
                break; // 找到目标后退出循环
            }
        }
        HPimg_White.sizeDelta = new Vector2(static_parameters.MC_HP_Max/2, HPimg_White.sizeDelta.y);
        HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP_Max/2, HPimg_White.sizeDelta.y);
        HPimg_Red.sizeDelta = new Vector2(static_parameters.MC_HP_Max/2, HPimg_White.sizeDelta.y);
    }
    //Determined to be attacked
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("NPC"))
        {
            HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP/2, HPimg_Green.sizeDelta.y);
            /*if (HPimg_Red.sizeDelta.x > HPimg_Green.sizeDelta.x)
            {
                Debug.Log("in");
                //讓傷害量(紅色血條)逐漸追上當前血量
                HPimg_Red.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 10;
            }*/
            if (static_parameters.MC_HP <= 0)
            {
                static_parameters.MC_HP = static_parameters.MC_HP_Max;
                SceneManager.LoadScene("magic_house");
            }
        }
        //The attack is determined based on the tag detection of the weapon category
        //Meet customs clearance conditions
    }
}
