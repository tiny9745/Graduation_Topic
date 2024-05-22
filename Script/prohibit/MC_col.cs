using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MC_col : MonoBehaviour
{
    public GameObject MC;
    public Transform spriteTransform;
    private RectTransform HPimg_White, HPimg_Red, HPimg_Green;
    public string targetSceneName = "Game_fight";
    public string PrepareSceneName = "magic_house";
    public float horizontalInput, verticalInput;
    short face=4;
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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Convert movement direction to world space
        if (movement.magnitude > 1){
            movement.Normalize();
        }
        movement = movement * static_parameters.MC_Wspeed * Time.deltaTime;
        transform.position += movement;
        // Determine the direction of the character
        if(movement != Vector3.zero){
            if (movement.x > 0){
                face = 1;
                
            }else if (movement.x < 0){
                face = 2;
            }else if (movement.z > 0){
                face = 3;
            }else if (movement.z < 0){
                face = 4;
            }
        }
        //MC HP change
        if (static_parameters.MC_HP_tmp != static_parameters.MC_HP){
            MC_HP();
        }
        MC_HP_effects();
        skill();
        //SetLookDirection(face);
    }
    void LateUpdate(){
        // Reset the sprite's local rotation to keep it fixed
        
    }

    // Subscribe to events
    private void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Unsubscribe event
    private void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        // Check whether the loaded scene is the target scene
        if (scene.name == targetSceneName)
        {
            FindHPImage();
        }
        if (scene.name == PrepareSceneName)
        {
            static_parameters.MC_HP = static_parameters.MC_HP_Max;
        }
    }

    private void FindHPImage(){
        // Find all "Image" in the scene
        RectTransform[] foundRectTransforms = FindObjectsOfType<RectTransform>();
        foreach (RectTransform rectTransform in foundRectTransforms)
        {
            // Check whether the name of the RectTransform component is the specified name"
            if (rectTransform.name == "HP_Max")
            {
                HPimg_White = rectTransform;
            }
            if (rectTransform.name == "HP_change")
            {
                HPimg_Red = rectTransform;
            }
            if (rectTransform.name == "HP_change_after")
            {
                HPimg_Green = rectTransform;
                break;
            }
        }

        if (HPimg_White != null && HPimg_Red != null && HPimg_Green != null){
            HPimg_White.sizeDelta = new Vector2(static_parameters.MC_HP_Max / 2, HPimg_White.sizeDelta.y);
            HPimg_Red.sizeDelta = new Vector2(static_parameters.MC_HP / 2, HPimg_White.sizeDelta.y);
            HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP / 2, HPimg_White.sizeDelta.y);
        }
    }

    //Determined to be attacked
    void MC_HP(){
        static_parameters.MC_HP_tmp = static_parameters.MC_HP;
        if (HPimg_Green != null){
            HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP / 2, HPimg_Green.sizeDelta.y);
        }
        if (static_parameters.MC_HP <= 0){
            SceneManager.LoadScene("magic_house");
        }
    }

    void MC_HP_effects(){
        if (HPimg_Red != null && HPimg_Green != null && HPimg_Red.sizeDelta.x > HPimg_Green.sizeDelta.x){
            // Let the damage amount (health bar2) gradually catch up with the current blood volume
            HPimg_Red.sizeDelta -= new Vector2(1, 0) * Time.deltaTime * 6f;
        }
    }

    void SetLookDirection(int face){
        switch (face){
            case 1:
                SetRotation(0, -90, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                SetRotation(0, 90, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 3:
                SetRotation(0, 180, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 4:
                SetRotation(0, 0, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;        
        }
    }

    void SetRotation(float x, float y, float z){
        Quaternion newRotation = Quaternion.Euler(x, y, z);
        transform.rotation = newRotation;
    }
    
    private void OnTriggerEnter(Collider other){
        
    }
    void skill(){
        if (Input.GetKeyDown(KeyCode.J)){
            
        }
        if (Input.GetKeyUp(KeyCode.J)){
            
        }
    }
}


