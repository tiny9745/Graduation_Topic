using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class initiator_MC : MonoBehaviour
{
    float timer_f = 0;
    private Vector3 previousPosition;
    float accumulatedDistance = 0;
    bool timer_close = true;
    public GameObject bullet33, Ward34, throw11, Guardian41, Guardian42, Guardian43, Guardian44, Guardian45; public Transform Firepoint;
    public InventoryManager inventoryManager;

    private Vector3 Guardian4x_point = Vector3.zero;

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
        Book_throwing();
        if (IconManager.Instance != null)
        {
            Debug.Log("IconManager.Instance is OK");
        }
        else
        {
            Debug.Log("IconManager.Instance == null");
        }
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
                                Debug.Log("skill_01");
                                static_parameters.MC_HP -= static_parameters.MC_HP_Max / 20;
                                Skill_public_funtion.skill_01_time = 0;
                                Debug.Log("MC_HP" + static_parameters.MC_HP);
                            }
                            break;
                        case 3:
                            if (Skill_public_funtion.MC_HP_tmp != static_parameters.MC_HP)
                            {
                                Debug.Log("skill_03");
                                Skill_public_funtion.MC_HP_tmp = static_parameters.MC_HP;
                                static_parameters.MC_ATK = Mathf.Pow(1.75f - static_parameters.MC_HP / static_parameters.MC_HP_Max, 2);
                                Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
                            }
                            break;
                        case 4:
                            if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp && Skill_public_funtion.skill_04_atk)
                            {
                                Debug.Log("skill_04");
                                Skill_public_funtion.skill_04_atk = false;
                                static_parameters.MC_ATK *= 1.5f;
                            }
                            break;
                        case 5:
                            if (Skill_public_funtion.skill_05_atk == false && static_parameters.MC_HP_tmp != static_parameters.MC_HP)
                            {
                                Debug.Log("skill_05");
                                Skill_public_funtion.skill_05_atk = true;
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

    private void sprint_Bonus()//觸發衝刺時作用，bool值在Ani_MC.cs
    {
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                switch (icon.iconID)
                {
                    case 32:
                        if (Skill_public_funtion.skill_32_Dash_end)
                        {
                            Skill_public_funtion.skill_32_Dash_end = false;
                            Skill_public_funtion.skill_32_Dash_time = 0;
                            static_parameters.MC_Wspeed *= 1.2f;
                        }
                        if (Skill_public_funtion.skill_32_Dash_time < 2f)
                        {
                            Skill_public_funtion.skill_32_Dash_time += Time.deltaTime;
                        }
                        else if (Skill_public_funtion.skill_32_Dash_time < 10f)
                        {
                            static_parameters.MC_Wspeed /= 1.2f;
                            Skill_public_funtion.skill_32_Dash_time = 15f;
                        }
                        break;
                    case 33:
                        if (Skill_public_funtion.skill_33_Dash)
                        {
                            Skill_public_funtion.skill_33_Dash = false;
                            Instantiate(bullet33, Firepoint.position, transform.rotation);
                        }
                        break;
                    case 34:
                        if (Skill_public_funtion.skill_34_Dash)
                        {
                            Skill_public_funtion.skill_34_Dash = false;
                            Instantiate(Ward34, transform.position, Ward34.transform.rotation);
                        }
                        break;
                    case 35:
                        if (Skill_public_funtion.skill_35_Dash_Magnification == 1f)
                        {
                            Skill_public_funtion.skill_35_Dash_Magnification = 0.9f;
                            Ani_MC.DashCD_time = 2f;
                            Debug.Log("skill_35_Dash_Magnification:" + Skill_public_funtion.skill_35_Dash_Magnification);
                        }
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
                    case 13:
                        if (Skill_public_funtion.skill_13_bullet_atk == 1f)
                        {
                            Skill_public_funtion.skill_13_bullet_atk = 2f;
                            Debug.Log("skill_13_bullet_atk:" + Skill_public_funtion.skill_13_bullet_atk);
                        }
                        break;
                    case 14:
                        if (Skill_public_funtion.skill_14_enter == false)
                        {
                            Skill_public_funtion.skill_14_enter = true;
                        }
                        break;
                }
            }
        }
    }
    private void Guardian()//背後靈
    {
        if (IconManager.Instance != null)
        {
            Guardian4x_point = new Vector3(transform.position.x, 3, transform.position.z + Skill_public_funtion.skill_4x_Sorting * 5);

            foreach (var icon in IconManager.Instance.IconList)
            {
                switch (icon.iconID)
                {
                    case 41:
                        if (Skill_public_funtion.skill_41_enter)
                        {
                            Skill_public_funtion.skill_41_enter = false;
                            Instantiate(Guardian41, Guardian4x_point, transform.rotation);
                            Skill_public_funtion.skill_4x_Sorting++;
                        }
                        break;
                    case 42:
                        Debug.Log("skill_42_enter:" + Skill_public_funtion.skill_42_enter);
                        if (Skill_public_funtion.skill_42_enter)
                        {
                            Skill_public_funtion.skill_42_enter = false;
                            Instantiate(Guardian42, Guardian4x_point, transform.rotation);
                            Skill_public_funtion.skill_4x_Sorting++;
                        }
                        break;
                    case 43:
                        if (Skill_public_funtion.skill_43_enter)
                        {
                            Skill_public_funtion.skill_43_enter = false;
                            Instantiate(Guardian43, Guardian4x_point, transform.rotation);
                            Skill_public_funtion.skill_4x_Sorting++;
                        }
                        break;
                    case 44:
                        if (Skill_public_funtion.skill_44_enter)
                        {
                            Skill_public_funtion.skill_44_enter = false;
                            Instantiate(Guardian44, Guardian4x_point, transform.rotation);
                            Skill_public_funtion.skill_4x_Sorting++;
                        }
                        break;
                    case 45:
                        if (Skill_public_funtion.skill_45_enter)
                        {
                            Skill_public_funtion.skill_45_enter = false;
                            Instantiate(Guardian45, Guardian4x_point, transform.rotation);
                            Skill_public_funtion.skill_4x_Sorting++;
                        }
                        break;
                }
            }
        }
    }
}
