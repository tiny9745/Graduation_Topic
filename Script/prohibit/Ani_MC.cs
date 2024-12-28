using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class Ani_MC : MonoBehaviour
{
    // stand 0 walk 1 melee attack 2~4
    public Animator animator;
    public GameObject playerPrefab;
    private Play_move MC_move;
    int Angle_sum = 270;
    private float startTime;
    private float elapsedTime;
    public GameObject Play_s;
    float dashStartTime = 0;
    private bool isDashCooldown = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        MC_move = playerPrefab.GetComponent<Play_move>();
    }

    void Update()
    {
        // 更新位置
        this.transform.position = new Vector3(Play_s.transform.position.x, transform.position.y, Play_s.transform.position.z);

        // 設定角度方向
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

        // 普通攻擊邏輯
        if (Input.GetKey(KeyCode.J))
        {
            if (startTime <= 0)
            {
                startTime = Time.time;
                static_parameters.Ani_state = 0;
            }

            elapsedTime = Time.time - startTime;

            if (elapsedTime <= 0.7f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Ani_state = 2;
            }
            else if (elapsedTime > 0.7f / static_parameters.MC_ATK_Speed && elapsedTime <= 1.5f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Ani_state = 3;
            }
            else if (elapsedTime > 1.5f / static_parameters.MC_ATK_Speed && elapsedTime <= 2.4f / static_parameters.MC_ATK_Speed)
            {
                static_parameters.Ani_state = 4;
            }
            else if (elapsedTime > 2.4f / static_parameters.MC_ATK_Speed)
            {
                startTime = 0;
                static_parameters.Ani_state = 0;
            }
        }

        // Dash 邏輯
        if (Input.GetKeyDown(KeyCode.L) && !isDashCooldown)
        {
            StartCoroutine(DashSequence());
        }

        // 確保其他狀態正常運作
        if (static_parameters.Ani_state != 5)
        {
            Defult_Check();
            MC_ani_state();
        }
    }

    void Defult_Check()
    {
        if (static_parameters.face == 0)
        {
            static_parameters.Ani_state = 0;
        }
        else
        {
            static_parameters.Ani_state = 1;
        }
    }

    IEnumerator DashSequence()
    {
        isDashCooldown = true; // 設置為冷卻中
        static_parameters.Ani_state = 5; // 設置狀態為 Dash
        PlayDashAnimation(); // 播放 Dash 動畫

        float dashDuration = 0.63f; // Dash 動畫時長
        float dashStartTime = Time.time;

        // 等待 Dash 動畫播放完成
        while (Time.time - dashStartTime < dashDuration)
        {
            yield return null; // 每幀等待
        }

        // 動畫結束後恢復到預設狀態
        Defult_Check();
        yield return new WaitForSeconds(15f); // 冷卻 15 秒
        isDashCooldown = false; // 重置冷卻狀態
    }

    void PlayDashAnimation()
    {
        switch (Angle_sum)
        {
            case 0:
                animator.CrossFade("MC_Dash_R", 0.1f); // 平滑切換至 Dash 動畫
                break;
            case 45:
                animator.CrossFade("MC_Dash_B", 0.1f);
                break;
            case 90:
                animator.CrossFade("MC_Dash_B", 0.1f);
                break;
            case 135:
                animator.CrossFade("MC_Dash_L", 0.1f);
                break;
            case 180:
                animator.CrossFade("MC_Dash_L", 0.1f);
                break;
            case 225:
                animator.CrossFade("MC_Dash_F", 0.1f);
                break;
            case 270:
                animator.CrossFade("MC_Dash_F", 0.1f);
                break;
            case 315:
                animator.CrossFade("MC_Dash_R", 0.1f);
                break;
        }
    }
    void MC_ani_state()
    {
        switch (static_parameters.Ani_state)
        {
            case 0:// stand
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_Stand_Right");
                        break;
                    case 45:
                        animator.Play("MC_Stand_Back");
                        break;
                    case 90:
                        animator.Play("MC_Stand_Back");
                        break;
                    case 135:
                        animator.Play("MC_Stand_Left");
                        break;
                    case 180:
                        animator.Play("MC_Stand_Left");
                        break;
                    case 225:
                        animator.Play("MC_Stand_Front");
                        break;
                    case 270:
                        animator.Play("MC_Stand_Front");
                        break;
                    case 315:
                        animator.Play("MC_Stand_Right");
                        break;
                }
                break;
            case 1:// walk
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_Walk_Right");
                        break;
                    case 45:
                        animator.Play("MC_Walk_Back");
                        break;
                    case 90:
                        animator.Play("MC_Walk_Back");
                        break;
                    case 135:
                        animator.Play("MC_Walk_Left");
                        break;
                    case 180:
                        animator.Play("MC_Walk_Left");
                        break;
                    case 225:
                        animator.Play("MC_Walk_Front");
                        break;
                    case 270:
                        animator.Play("MC_Walk_Front");
                        break;
                    case 315:
                        animator.Play("MC_Walk_Right");
                        break;
                }
                break;
            case 2:
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_FR_Atk_01");
                        break;
                    case 45:
                        animator.Play("MC_BR_Atk_01");
                        break;
                    case 90:
                        animator.Play("MC_BR_Atk_01");
                        break;
                    case 135:
                        animator.Play("MC_BL_Atk_01");
                        break;
                    case 180:
                        animator.Play("MC_FL_Atk_01");
                        break;
                    case 225:
                        animator.Play("MC_FL_Atk_01");
                        break;
                    case 270:
                        animator.Play("MC_FR_Atk_01");
                        break;
                    case 315:
                        animator.Play("MC_FR_Atk_01");
                        break;
                }
                break;
            case 3:
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_FR_Atk_02");
                        break;
                    case 45:
                        animator.Play("MC_BR_Atk_02");
                        break;
                    case 90:
                        animator.Play("MC_BR_Atk_02");
                        break;
                    case 135:
                        animator.Play("MC_BL_Atk_02");
                        break;
                    case 180:
                        animator.Play("MC_FL_Atk_02");
                        break;
                    case 225:
                        animator.Play("MC_FL_Atk_02");
                        break;
                    case 270:
                        animator.Play("MC_FR_Atk_02");
                        break;
                    case 315:
                        animator.Play("MC_FR_Atk_02");
                        break;
                }
                break;
            case 4:
                switch (Angle_sum)
                {
                    case 0:
                        animator.Play("MC_FR_Atk_03");
                        break;
                    case 45:
                        animator.Play("MC_BR_Atk_03");
                        break;
                    case 90:
                        animator.Play("MC_BR_Atk_03");
                        break;
                    case 135:
                        animator.Play("MC_BL_Atk_03");
                        break;
                    case 180:
                        animator.Play("MC_FL_Atk_03");
                        break;
                    case 225:
                        animator.Play("MC_FL_Atk_03");
                        break;
                    case 270:
                        animator.Play("MC_FR_Atk_03");
                        break;
                    case 315:
                        animator.Play("MC_FR_Atk_03");
                        break;
                }
                break;
        }
    }
}
