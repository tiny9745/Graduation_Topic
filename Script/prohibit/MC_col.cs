using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MC_col : MonoBehaviour
{
    public Blood_col Blood_Col;
    public Animator animator;
    public Transform spriteTransform;
    public Material Deduct_Blood;
    private Material originalMaterial;
    private NavMeshAgent playerAgent;
    private AudioSource audioSource; // 音效來源
    public AudioClip[] audioClip;

    void Start()
    {
        playerAgent = GameObject.Find("Player_S").GetComponent<NavMeshAgent>();
        // playerAgent.enabled = false;
        Renderer renderer1 = spriteTransform.GetComponent<Renderer>();
        if (renderer1 != null)
        {
            originalMaterial = renderer1.material;
        }
        if (Blood_Col == null)
        {
            Blood_Col = GetComponent<Blood_col>();
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.clip = audioClip[0];
    }

    void Update()
    {
        if (static_parameters.MC_HP <= 0)
        {
            if (static_parameters.Change_enemy != 0)
            {
                audioSource.PlayOneShot(audioClip[1]);
            }
            static_parameters.Change_enemy = 0;
            static_parameters.next_door = false;
            // playerAgent.enabled = false;
        }
        SetLookDirection(static_parameters.face);
        // Check and update the attack speed
        if (static_parameters.MC_ATK_Speed_tmp != static_parameters.MC_ATK_Speed)
        {
            ATK_speedupdate();
        }
        else if (static_parameters.MC_Wspeed != static_parameters.MC_Wspeed_tmp)// Check and update the walk speed
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
    public void red()
    {
        Renderer renderer1 = spriteTransform.GetComponent<Renderer>();
        Deduct_Blood.SetColor("_Color", new Color(1, 0, 0, 0.5f));
        renderer1.material = Deduct_Blood;
        StartCoroutine(ResetMaterialAfterDelay(renderer1, 0.5f));
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
