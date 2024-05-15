using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MC_col : MonoBehaviour
{
    public GameObject MC;
    private Image HPimg;
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
        Image[] foundImages = FindObjectsOfType<Image>();
        foreach (Image img in foundImages)
        {
            if (img.name == "HP_change")
            {
                HPimg = img;
                Debug.Log("成功找到名為 'HP_change' 的 Image 元件");
                break;
            }
        }
    }
    //Determined to be attacked
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("NPC"))
        {
            HPimg.fillAmount = static_parameters.MC_HP *(1/static_parameters.MC_HP_Max);
            if (static_parameters.MC_HP <= 0)
            {
                static_parameters.MC_HP = 0;
                Destroy(gameObject);
            }
        }
        //The attack is determined based on the tag detection of the weapon category
        //Meet customs clearance conditions
    }
}
