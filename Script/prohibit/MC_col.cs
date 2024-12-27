using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class MC_col : MonoBehaviour
{
    public GameObject MC, MC_S;
    public Blood_col Blood_Col;
    public Animator animator;
    public Transform spriteTransform;
    public Material Deduct_Blood;
    private Material originalMaterial;
    private NavMeshAgent playerAgent;
    public string Game_fight = "Game_fight", magic_house = "magic_house", house_outside = "house_outside";

    void Start()
    {
        MC = GameObject.Find("Player");
        MC_S = GameObject.Find("Player_S");
        playerAgent = GameObject.Find("Player_S").GetComponent<NavMeshAgent>();
        playerAgent.enabled = false;
        Renderer renderer1 = spriteTransform.GetComponent<Renderer>();
        if (renderer1 != null)
        {
            originalMaterial = renderer1.material;
        }
        if (Blood_Col == null)
        {
            Blood_Col = GetComponent<Blood_col>();
        }
    }

    void Update()
    {
        if (static_parameters.MC_HP <= 0)
        {
            playerAgent.enabled = false;
        }
        SetLookDirection(static_parameters.face);
        // Check and update the attack speed
        if (static_parameters.MC_ATK_Speed_tmp != static_parameters.MC_ATK_Speed)
        {
            ATK_speedupdate();
        }

        // Check and update the walk speed
        if (static_parameters.MC_Wspeed != static_parameters.MC_Wspeed_tmp)
        {
            Walk_speedupdate();
        }
    }

    void SetAnimationSpeed_ATK(string animName, float animSpeed)
    {
        // Ensure the animator is not null
        if (animator != null)
        {
            // Create parameter name
            string paramName = animName + "Speed";
            // Check if the parameter exists
            if (AnimatorHasParameter(animator, paramName))
            {
                // Set the speed of the specified animation
                animator.SetFloat(paramName, animSpeed);
            }
            else
            {
                Debug.LogWarning("Animator does not have the specified parameter: " + paramName);
            }
        }
    }

    void SetAnimationSpeed_Walk(string animName, float animSpeed)
    {
        if (animator != null)
        {
            string paramName = animName + "Speed";
            if (AnimatorHasParameter(animator, paramName))
            {
                animator.SetFloat(paramName, animSpeed);
            }
            else
            {
                Debug.LogWarning("Animator does not have the specified parameter: " + paramName);
            }
        }
    }

    bool AnimatorHasParameter(Animator animator, string paramName)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
            {
                return true;
            }
        }
        return false;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)//Into Scene
    {
        if (scene.name == Game_fight)
        {
            if (Blood_Col != null) Blood_Col.FindHPImage();
        }
        if (scene.name == magic_house)
        {
            static_parameters.MC_HP = static_parameters.MC_HP_Max;
        }
    }

    private void OnSceneUnloaded(Scene scene)//Leave Scene
    {
        if (scene.name == house_outside)
        {
            static_parameters.MC_HP = static_parameters.MC_HP_Max;
        }
    }

    void SetLookDirection(int face)
    {
        switch (face)
        {
            case 1:
                SetRotation(0, 270, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                SetRotation(0, 225, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 3:
                SetRotation(0, 180, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 4:
                SetRotation(0, 135, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 5:
                SetRotation(0, 90, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 6:
                SetRotation(0, 45, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 7:
                SetRotation(0, 0, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 8:
                SetRotation(0, 315, 0);
                spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    void SetRotation(float x, float y, float z)
    {
        Quaternion newRotation = Quaternion.Euler(x, y, z);
        transform.rotation = newRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer1 = spriteTransform.GetComponent<Renderer>();
        if (other.CompareTag("NPC_Att") && !static_parameters.invincible)
        {
            Deduct_Blood.SetColor("_Color", new Color(1, 0, 0, 0.5f));
            renderer1.material = Deduct_Blood;
            StartCoroutine(ResetMaterialAfterDelay(renderer1, 0.2f));
        }
        
    }
    void ATK_speedupdate()
    {
        static_parameters.MC_ATK_Speed_tmp = static_parameters.MC_ATK_Speed;
        SetAnimationSpeed_ATK("MC_Att_BR01", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_FR01", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_FL01", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_BL01", static_parameters.MC_ATK_Speed);

        SetAnimationSpeed_ATK("MC_Att_BR02", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_FR02", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_FL02", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_BL02", static_parameters.MC_ATK_Speed);

        SetAnimationSpeed_ATK("MC_Att_BR03", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_FR03", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_FL03", static_parameters.MC_ATK_Speed);
        SetAnimationSpeed_ATK("MC_Att_BL03", static_parameters.MC_ATK_Speed);
    }
    void Walk_speedupdate()
    {
        static_parameters.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
        SetAnimationSpeed_Walk("MC_Walk_Back", static_parameters.MC_Wspeed);
        SetAnimationSpeed_Walk("MC_Walk_Left", static_parameters.MC_Wspeed);
        SetAnimationSpeed_Walk("MC_Walk_Front", static_parameters.MC_Wspeed);
        SetAnimationSpeed_Walk("MC_Walk_Right", static_parameters.MC_Wspeed);

        SetAnimationSpeed_Walk("MC_Stand_Front", static_parameters.MC_Wspeed);
        SetAnimationSpeed_Walk("MC_Stand_Right", static_parameters.MC_Wspeed);
        SetAnimationSpeed_Walk("MC_Stand_Back", static_parameters.MC_Wspeed);
        SetAnimationSpeed_Walk("MC_Stand_Left", static_parameters.MC_Wspeed);
    }

    private IEnumerator ResetMaterialAfterDelay(Renderer renderer1, float delay)
    {
        yield return new WaitForSeconds(delay);
        renderer1.material = originalMaterial;
    }
}
