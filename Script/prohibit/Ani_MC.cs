using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_MC : MonoBehaviour
{
    public Animator animator;
    int Angle_sum = 270;

    public GameObject Play_s;

    static public bool isDashCooldown = false;
    static public bool isDashCooldown_for_move = false;
    static public bool isAttackPlaying = false;
    static public float DashCD_time = 2f;
    short ATK_count = 0;
    float attackTime = 0; bool isAttack_combo = false,hold = false;
    static public float dashDuration = 0.63f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 更新角色位置
        this.transform.position = new Vector3(Play_s.transform.position.x, transform.position.y, Play_s.transform.position.z);

        // 設定角色面向角度
        UpdateFacingDirection();

        // 如果動畫正在播放，則不處理其他輸入
        if (isAttackPlaying || static_parameters.Ani_state == -1)
        {
            hold = true;
            return;
        }
        if(hold){
            hold = false;
            DefaultCheck();
        }
        // if(isDashCooldown)Debug.Log("isDashCooldown");
        // 處理輸入
        if (Input.GetKeyDown(KeyCode.L) && !isDashCooldown && IsMoving())
        {
            Skill_public_funtion.skill_31_dash = true;
            Skill_public_funtion.skill_33_Dash = true;
            Skill_public_funtion.skill_34_Dash = true;
            StartCoroutine(DashSequence());
        }
        else if (Input.GetKeyDown(KeyCode.J) && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 2)
        {
            if (ATK_count < 3)
            {
                ATK_count++;
                static_parameters.Ani_state = ATK_count + 1;
                StartCoroutine(AttackSequence());
            }
        }
        else if (ATK_count == 0)
        {
            DefaultCheck();
        }

        // 確保動畫狀態正確
        if (static_parameters.Ani_state == 0 || static_parameters.Ani_state == 1)
        {
            MC_ani_state();
        }
        if (isAttack_combo)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= 0.5f)
            {
                Debug.Log("leave time: "+attackTime);
                ATK_count = 0; attackTime = 0;
                isAttack_combo = false;
            }
        }
        else
        {
            attackTime = 0;
            DefaultCheck();
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
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    void DefaultCheck()
    {
        if (static_parameters.face == 0)
        {
            static_parameters.Ani_state = 0; // 站立
        }
        else
        {
            static_parameters.Ani_state = 1; // 行走
        }
    }

    IEnumerator DashSequence()
    {
        isDashCooldown = true;
        isDashCooldown_for_move = true;
        static_parameters.Ani_state = -1; // 設置為 Dash 狀態
        float dashStartTime = Time.time;
        dashDuration = 0.63f / Skill_public_funtion.skill_35_Dash_Magnification;
        animator.speed = Skill_public_funtion.skill_35_Dash_Magnification;
        PlayDashAnimation();

        // 確保動畫完整播放
        while (Time.time - dashStartTime < dashDuration)
        {
            yield return null;
        }
        Skill_public_funtion.skill_32_Dash_end = true;
        Skill_public_funtion.skill_31_dash = false;

        DefaultCheck();
        yield return new WaitForSeconds(DashCD_time);
        isDashCooldown = false;
    }

    IEnumerator AttackSequence()
    {
        // isAttackPlaying = true; isAttack_combo = true; startTime = Time.time;
        // 播放攻擊動畫
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
        // if(ani != static_parameters.Ani_state)
        // {
        //     ani = static_parameters.Ani_state;
        //     Debug.Log("Attack " + static_parameters.Ani_state);
        //     float elapsedTime = Time.time - startTime; // Calculate elapsed time
        //     if(elapsedTime!=0)Debug.Log("Attack duration: " + elapsedTime + " seconds");
        // }
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
}
