using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ani_MC : MonoBehaviour
{
    public Animator animator;
    int Angle_sum = 270;
    public GameObject Play_s;

    static public bool isDashCooldown = false, isDashCooldown_for_move = false;
    static public bool isAttackPlaying = false;
    static public float DashCD_time = 1f, dashDuration = 0.63f;
    short ATK_count = 0; bool atk_flag = false; float atk_time = 0;
    public AudioSource audioSource; // 音效播放元件
    public AudioClip[] walk_Sound;
    public Teaching_TextF teaching_TextF;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // 設定為循環播放
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 更新角色位置
        this.transform.position = new Vector3(Play_s.transform.position.x, transform.position.y, Play_s.transform.position.z);
        // 設定角色面向角度
        UpdateFacingDirection();
        if (atk_flag) atk_time += Time.deltaTime;

        if (atk_time >= 0.45f)
        {
            if ((Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.Mouse0)) && static_parameters.Bookstate == false && static_parameters.isTeaching == false && static_parameters.isUpgrade_tmp == false)
            {
                if (!isAttackPlaying) StartCoroutine(AttackSequence()); atk_time = 0;
            }
        }
        if (atk_time >= 0.8f || ATK_count > 4)
        {
            ResetCombo();
        }
        // 如果動畫正在播放，則不處理其他輸入
        if (isAttackPlaying || static_parameters.Ani_state == -1) return;

        // 處理輸入
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Mouse2)) && !isDashCooldown && IsMoving() && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 0 && static_parameters.Bookstate == false)
        {
            Skill_public_funtion.skill_31_dash = true;
            Skill_public_funtion.skill_33_Dash = true;
            Skill_public_funtion.skill_34_Dash = true;
            audioSource.PlayOneShot(walk_Sound[3]);
            StartCoroutine(DashSequence());
        }
        else if ((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Mouse0)) && static_parameters.Bookstate == false && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 2 && (teaching_TextF.talk_number >= 100 || teaching_TextF.talk_number < 12) && static_parameters.isUpgrade_tmp == false)
        {
            StartCoroutine(AttackSequence());
        }
        else if (!isAttackPlaying && ATK_count == 0)
        {
            DefaultCheck();
        }

        // 確保動畫狀態正確
        if (static_parameters.Ani_state == 0 || static_parameters.Ani_state == 1)
        {
            MC_ani_state();
        }
    }

    void UpdateFacingDirection()
    {
        switch (static_parameters.face)
        {
            case 0: break;
            case 1: Angle_sum = 0; break;
            case 2: Angle_sum = 45; break;
            case 3: Angle_sum = 90; break;
            case 4: Angle_sum = 135; break;
            case 5: Angle_sum = 180; break;
            case 6: Angle_sum = 225; break;
            case 7: Angle_sum = 270; break;
            case 8: Angle_sum = 315; break;
        }
    }

    bool IsMoving()
    {
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    void DefaultCheck()
    {
        if (static_parameters.face == 0)
        {
            static_parameters.Ani_state = 0; // 站立
            audioSource.clip = walk_Sound[0];
            if (audioSource.isPlaying == false) audioSource.Play();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "magic_house" || SceneManager.GetActiveScene().name == "house_outside")
            {
                audioSource.clip = walk_Sound[1];
                if (audioSource.isPlaying == false) audioSource.Play();
            }
            else
            {
                audioSource.clip = walk_Sound[2];
                if (audioSource.isPlaying == false) audioSource.Play();
            }
            static_parameters.Ani_state = 1; // 行走
        }
    }

    IEnumerator DashSequence()
    {
        isDashCooldown = true;
        static_parameters.Ani_state = -1; // 設置為 Dash 狀態
        float dashStartTime = Time.time;
        dashDuration = 0.63f / Skill_public_funtion.skill_35_Dash_Magnification;
        animator.speed = Skill_public_funtion.skill_35_Dash_Magnification;
        PlayDashAnimation();

        // 確保動畫完整播放
        while (Time.time - dashStartTime < dashDuration)
        {
            isDashCooldown_for_move = true; static_parameters.invincible = true;
            yield return null;
        }
        isDashCooldown_for_move = false; static_parameters.invincible = false;
        Skill_public_funtion.skill_32_Dash_end = true;
        Skill_public_funtion.skill_31_dash = false;

        DefaultCheck();
        yield return new WaitForSeconds(DashCD_time);
        isDashCooldown = false;
    }

    IEnumerator AttackSequence()
    {
        isAttackPlaying = true; atk_flag = true;
        // 播放攻擊動畫
        if (ATK_count < 4) ATK_count++;
        static_parameters.Ani_state = ATK_count + 1;
        MC_ani_state();
        switch (static_parameters.Ani_state)
        {
            case 2:
                yield return new WaitForSeconds(0.65f);
                break;
            case 3:
                yield return new WaitForSeconds(0.65f);
                break;
            case 4:
                yield return new WaitForSeconds(1.05f);
                ATK_count = 0;
                break;
            default:
                ATK_count = 0;
                break;
        }
        isAttackPlaying = false;
    }

    void PlayDashAnimation()
    {
        switch (Angle_sum)
        {
            case 0:
                Skill_public_funtion.skill_32_33_Dash_direction = 1;
                animator.CrossFade("MC_Dash_R", 0.1f);
                break;
            case 45:
            case 90:
                Skill_public_funtion.skill_32_33_Dash_direction = 2;
                animator.CrossFade("MC_Dash_B", 0.1f);
                break;
            case 135:
            case 180:
                Skill_public_funtion.skill_32_33_Dash_direction = 3;
                animator.CrossFade("MC_Dash_L", 0.1f);
                break;
            case 225:
            case 270:
                Skill_public_funtion.skill_32_33_Dash_direction = 4;
                animator.CrossFade("MC_Dash_F", 0.1f);
                break;
            case 315:
                Skill_public_funtion.skill_32_33_Dash_direction = 1;
                animator.CrossFade("MC_Dash_R", 0.1f);
                break;
        }
    }

    void MC_ani_state()
    {
        switch (static_parameters.Ani_state)
        {
            case 0: // Stand
                PlayStandAnimation();
                break;
            case 1: // Walk
                PlayWalkAnimation();
                break;
            case 2: // Attack
                Atk_step_number();
                break;
            case 3: // Attack 2
                Atk_step_number();
                break;
            case 4: // Attack 3
                Atk_step_number();
                break;
        }
    }

    private void Atk_step_number()
    {
        switch (Angle_sum)
        {
            case 0:
                PlayAttackAnimation($"MC_FR_Atk_0{static_parameters.Ani_state - 1}");
                break;
            case 45:
                PlayAttackAnimation($"MC_BR_Atk_0{static_parameters.Ani_state - 1}");
                break;
            case 90:
                PlayAttackAnimation($"MC_BR_Atk_0{static_parameters.Ani_state - 1}");
                break;
            case 135:
                PlayAttackAnimation($"MC_BL_Atk_0{static_parameters.Ani_state - 1}");
                break;
            case 180:
                PlayAttackAnimation($"MC_FL_Atk_0{static_parameters.Ani_state - 1}");
                break;
            case 225:
                PlayAttackAnimation($"MC_FL_Atk_0{static_parameters.Ani_state - 1}");
                break;
            case 270:
                PlayAttackAnimation($"MC_FR_Atk_0{static_parameters.Ani_state - 1}");
                break;
            case 315:
                PlayAttackAnimation($"MC_FR_Atk_0{static_parameters.Ani_state - 1}");
                break;
        }
    }

    void PlayStandAnimation()
    {
        switch (Angle_sum)
        {
            case 0:
                animator.Play("MC_Stand_Right");
                break;
            case 45:
            case 90:
                animator.Play("MC_Stand_Back");
                break;
            case 135:
            case 180:
                animator.Play("MC_Stand_Left");
                break;
            case 225:
            case 270:
                animator.Play("MC_Stand_Front");
                break;
            case 315:
                animator.Play("MC_Stand_Right");
                break;
        }
    }

    void PlayWalkAnimation()
    {
        switch (Angle_sum)
        {
            case 0:
                animator.Play("MC_Walk_Right");
                break;
            case 45:
            case 90:
                animator.Play("MC_Walk_Back");
                break;
            case 135:
            case 180:
                animator.Play("MC_Walk_Left");
                break;
            case 225:
            case 270:
                animator.Play("MC_Walk_Front");
                break;
            case 315:
                animator.Play("MC_Walk_Right");
                break;
        }
    }

    void PlayAttackAnimation(string animationName)
    {
        animator.CrossFade(animationName, 0.1f);
    }
    void ResetCombo()
    {
        ATK_count = 0; atk_time = 0; atk_flag = false;
    }
}
