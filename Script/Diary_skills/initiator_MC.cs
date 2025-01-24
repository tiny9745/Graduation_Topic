using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public class initiator_MC : MonoBehaviour
{
    float timer_f = 0;
    bool time_A_B = false;
    private Vector3 previousPosition;
    float accumulatedDistance = 0;
    bool timer_close = true;
    public GameObject bullet53, Ward54, throw11, Ward12, Guardian41, Guardian42, Guardian43, Guardian44, Guardian45; public Transform Firepoint;
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        // Skill_public_funtion.play_piano = true;
        // Skill_public_funtion.feel_to_skill = 2; // 0=happy,1=angry,2=sad,3=wow
        // Debug.Log("feel_to_skill:" + Skill_public_funtion.feel_to_skill);
        previousPosition = transform.position;
        Skill_public_funtion.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
    }

    // Update is called once per frame
    void Update()
    {
        fight_instinct();
        sprint_Bonus();
        Guardian();
    }

    private void fight_instinct()
    {
        if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
        {
            if (IconManager.Instance != null)
            {
                foreach (var icon in IconManager.Instance.IconList)
                {
                    switch (icon.iconID)
                    {
                        case 1:
                            Skill_public_funtion.skill_01_time += Time.deltaTime;
                            if (Skill_public_funtion.skill_01_time > 10f)
                            {
                                static_parameters.MC_HP -= static_parameters.MC_HP_Max / 20;
                                Skill_public_funtion.skill_01_time = 0;
                                Debug.Log("MC_HP" + static_parameters.MC_HP);
                            }
                            break;
                        case 3:
                            if (Skill_public_funtion.MC_HP_tmp != static_parameters.MC_HP)
                            {
                                Skill_public_funtion.MC_HP_tmp = static_parameters.MC_HP;
                                static_parameters.MC_ATK = Mathf.Pow(1.75f - static_parameters.MC_HP / static_parameters.MC_HP_Max, 2);
                                Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
                            }
                            break;

                        case 4:
                            if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp)
                            {
                                static_parameters.MC_ATK *= 1.5f;
                            }
                            break;
                        case 5:
                            if (Skill_public_funtion.skill_05_atk == 0 && static_parameters.MC_ATK_tmp == static_parameters.MC_ATK)
                            {
                                Skill_public_funtion.skill_05_atk = 1;
                                static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
                                static_parameters.MC_ATK *= 1.5f;
                            }
                            break;
                    }
                }
            }
        }
        else //reduction
        {
            static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
        }
    }
    void Accurate_calculation()//不用
    {
        // foreach (var icon in IconManager.Instance.IconList)
        // {
        //     switch (icon.iconID)
        //     {
        //         case 0://攻守兼備
        //             timer_f += Time.deltaTime;
        //             if (timer_f > 15)
        //             {
        //                 timer_f = 0;
        //                 time_A_B = !time_A_B;
        //                 if (time_A_B)
        //                 {
        //                     static_parameters.MC_ATK *= 1.1f;
        //                     static_parameters.MC_DEF = static_parameters.MC_DEF_tmp;
        //                 }
        //                 else
        //                 {
        //                     static_parameters.MC_DEF *= 1.1f;
        //                     static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
        //                 }
        //                 Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
        //                 Debug.Log("MC_DEF:" + static_parameters.MC_DEF);
        //             }

        //             break;
        //         case 1:
        //             if (Skill_public_funtion.blood_deduction_NPC_count >= 400)
        //             {
        //                 Skill_public_funtion.blood_deduction_NPC_count = 0;
        //                 static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
        //                 time_A_B = !time_A_B;
        //                 if (time_A_B)
        //                 {
        //                     static_parameters.MC_ATK *= 1.5f;
        //                 }
        //                 else
        //                 {
        //                     static_parameters.MC_ATK *= 0.8f;
        //                 }
        //                 Debug.LogWarningFormat("MC_ATK:" + static_parameters.MC_ATK);
        //             }

        //             break;
        //         case 2:
        //             float distance = Vector3.Distance(previousPosition, transform.position);
        //             accumulatedDistance += distance;
        //             previousPosition = transform.position;
        //             //Debug.Log("add_distance: " + accumulatedDistance);
        //             if (accumulatedDistance >= 40)
        //             {
        //                 time_A_B = !time_A_B;
        //                 static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
        //                 static_parameters.MC_Wspeed = Skill_public_funtion.MC_Wspeed_tmp;
        //                 accumulatedDistance = 0;
        //                 timer_f = 0;
        //                 timer_close = true;
        //             }
        //             if (time_A_B)
        //             {
        //                 if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp && timer_f < 2)
        //                 {
        //                     static_parameters.MC_ATK *= 2f;
        //                     Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
        //                 }
        //                 else
        //                 {
        //                     timer_f += Time.deltaTime;
        //                     if (timer_f > 5 && timer_close)
        //                     {
        //                         timer_close = false;
        //                         static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
        //                         Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
        //                     }
        //                 }
        //             }
        //             else
        //             {
        //                 if (static_parameters.MC_Wspeed == Skill_public_funtion.MC_Wspeed_tmp && timer_f < 2)
        //                 {
        //                     static_parameters.MC_Wspeed *= 2f;
        //                     Debug.Log("MC_speed:" + static_parameters.MC_Wspeed);
        //                 }
        //                 else
        //                 {
        //                     timer_f += Time.deltaTime;
        //                     if (timer_f > 5 && timer_close)
        //                     {
        //                         timer_close = false;
        //                         static_parameters.MC_Wspeed = Skill_public_funtion.MC_Wspeed_tmp;
        //                         Debug.Log("MC_speed:" + static_parameters.MC_Wspeed);
        //                     }
        //                 }
        //             }
        //             break;
        //         case 3:
        //             if (Skill_public_funtion.ATK_count >= 25)
        //             {
        //                 Skill_public_funtion.ATK_count = 0;
        //                 static_parameters.MC_DEF = static_parameters.MC_DEF_tmp;
        //                 time_A_B = !time_A_B;
        //                 if (time_A_B)
        //                 {
        //                     static_parameters.MC_DEF = static_parameters.MC_DEF * 1.25f;
        //                 }
        //                 else
        //                 {
        //                     static_parameters.MC_DEF = static_parameters.MC_DEF * 0.8f;
        //                 }
        //                 Debug.Log("MC_DEF:" + static_parameters.MC_DEF);
        //             }
        //             break;
        //     }
        // }
    }
    private void sprint_Bonus()//觸發衝刺時作用
    {
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                switch (icon.iconID)
                {
                    case 52:
                        if (Skill_public_funtion.skill_52_Dash_end)
                        {
                            Skill_public_funtion.skill_52_Dash_end = false;
                            static_parameters.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
                            static_parameters.MC_Wspeed = static_parameters.MC_Wspeed * 1.2f;
                        }
                        if (Skill_public_funtion.skill_52_Dash_time < 2f)
                        {
                            Skill_public_funtion.skill_52_Dash_time += Time.deltaTime;
                        }
                        else
                        {
                            Skill_public_funtion.skill_52_Dash_time = 0;
                            static_parameters.MC_Wspeed = static_parameters.MC_Wspeed_tmp;
                        }
                        break;
                    case 53:
                        if (Skill_public_funtion.skill_53_Dash)
                        {
                            Skill_public_funtion.skill_53_Dash = false;
                            Instantiate(bullet53, Firepoint.position, transform.rotation);
                        }
                        break;
                    case 54:
                        if (Skill_public_funtion.skill_54_Dash)
                        {
                            Skill_public_funtion.skill_54_Dash = false;
                            Instantiate(Ward54, transform.position, transform.rotation);
                        }
                        break;
                    case 55:
                        Ani_MC.DashCD_time = 2f;
                        Skill_public_funtion.skill_55_Dash_Magnification = 0.9f;
                        break;
                }
            }
        }
    }
    private void Book_throwing()
    {
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                switch (icon.iconID)
                {
                    case 11:
                        if (Skill_public_funtion.skill_11_throw_time < 10f)
                        {
                            Skill_public_funtion.skill_11_throw_time += Time.deltaTime;
                        }
                        else
                        {
                            Skill_public_funtion.skill_11_throw_time = 0;
                            Instantiate(throw11, Firepoint.position, transform.rotation);
                        }
                        break;
                    case 12:
                        if (Skill_public_funtion.skill_12_bullet)
                        {
                            Skill_public_funtion.skill_12_bullet = false;
                            Instantiate(Ward12, transform.position, transform.rotation);
                        }
                        break;
                    case 13:
                        Skill_public_funtion.skill_13_bullet_atk = 2f;
                        break;
                    case 14:
                        if (Input.GetKeyDown(KeyCode.B) && static_parameters.Ani_state < 3)
                        {
                            Invoke("inventoryManager.bullet_fire", 0.5f);
                        }
                        break;
                }
            }
        }
    }
    private void Guardian()
    {
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                switch (icon.iconID)
                {
                    case 41:
                        if (Skill_public_funtion.skill_41_enter)
                        {
                            Instantiate(Guardian41, transform.position, transform.rotation);
                            Skill_public_funtion.skill_41_enter = false;
                        }
                        break;
                    case 42:
                        if (Skill_public_funtion.skill_42_enter)
                        {
                            Instantiate(Guardian42, transform.position, transform.rotation);
                            Skill_public_funtion.skill_42_enter = false;
                        }
                        break;
                    case 43:
                        if (Skill_public_funtion.skill_43_enter)
                        {
                            Instantiate(Guardian43, transform.position, transform.rotation);
                            Skill_public_funtion.skill_43_enter = false;
                        }
                        break;
                    case 44:
                        if (Skill_public_funtion.skill_44_enter)
                        {
                            Instantiate(Guardian44, transform.position, transform.rotation);
                            Skill_public_funtion.skill_44_enter = false;
                        }
                        break;
                    case 45:
                        if (Skill_public_funtion.skill_45_enter)
                        {
                            Instantiate(Guardian45, transform.position, transform.rotation);
                            Skill_public_funtion.skill_45_enter = false;
                        }
                        break;
                }
            }
        }
    }
}
