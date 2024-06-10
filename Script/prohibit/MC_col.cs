using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MC_col : MonoBehaviour
{
    public GameObject MC; public Blood_col Blood_Col;
    public Animator animator;
    public Transform spriteTransform;
    
    public Material Deduct_Blood; private Material originalMaterial;
    public string targetSceneName = "Game_fight"; public string PrepareSceneName = "magic_house";
    public Play_move MC_move;

    short face = 4;
    void Start()
    {      
        MC = GameObject.Find("Player");
        MC_move = GetComponentInParent<Play_move>();
        Renderer renderer1 = spriteTransform.GetComponent<Renderer>();
        if (renderer1 != null){
            originalMaterial = renderer1.material;
        }
        if(Blood_Col == null){
            Blood_Col = GetComponent<Blood_col>();
        }
    }

    void Update()
    {
        // Calculate movement direction
        Vector3 movement = new Vector3(MC_move.horizontalInput, 0f, MC_move.verticalInput);

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
        if (static_parameters.MC_HP <= 0){
            static_parameters.stage_number--;
            SceneManager.LoadScene("magic_house");
        }

        SetLookDirection(face);
    }
    void LateUpdate(){
        // Reset the sprite's local rotation to keep it fixed  
    }
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
            if(Blood_Col!=null)Blood_Col.FindHPImage();
        }
        if (scene.name == PrepareSceneName)
        {
            static_parameters.MC_HP = static_parameters.MC_HP_Max;
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
        // 检查碰撞物体是否具有Renderer组件
        Renderer renderer1 = spriteTransform.GetComponent<Renderer>();
        if (other.CompareTag("NPC_Att")){
            renderer1.material = Deduct_Blood;
            StartCoroutine(ResetMaterialAfterDelay(renderer1, 0.2f));
        }
    }
    private IEnumerator ResetMaterialAfterDelay(Renderer renderer1, float delay){
        yield return new WaitForSeconds(delay);
        renderer1.material = originalMaterial;
    }
}


