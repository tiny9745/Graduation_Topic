using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class initiator_MC : MonoBehaviour
{
    private Vector3 previousPosition, lastTriggerPosition_31;
    public GameObject skill_hit_box31, bullet33, Ward34, throw11, Guardian41, Guardian42, Guardian43, Guardian44, Guardian45;
    public Transform Firepoint;
    public Animator skill01_animator, skill_01_2, skill03C;
    public Animator skill31_animator, skill31_animator_1, skill32_animator_1, skill32_animator_2, skill32_animator_3, skill33_animator_1, skill33_animator_2, skill33_animator_3;
    public Animator[] skill11_animatorA;
    public Transform skill_hit_box31_postion, skill33_Firepoint_1, skill33_Firepoint_2, skill33_Firepoint_3;
    public InventoryManager inventoryManager;
    private float skill31_triggerDistance = 3f;

    private Vector3 Guardian4x_point = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void fight_instinct()
    {

        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
                {
                    switch (icon.iconID)
                    {
                        case 1:
                            skill01_animator.SetInteger("skill_0x", 2);
                            Skill_public_funtion.skill_01_time += Time.deltaTime;
                            if (Skill_public_funtion.skill_01_time > 10f)
                            {
                                Debug.Log("skill_01");
                                skill_01_2.SetTrigger("skill_01_2");
                                static_parameters.MC_HP -= static_parameters.MC_HP_Max / 20;
                                Skill_public_funtion.skill_01_time = 0;
                                Debug.Log("MC_HP" + static_parameters.MC_HP);
                            }
                            break;
                        case 2:
                            skill01_animator.SetInteger("skill_0x", 2);
                            break;
                        case 3:
                            skill01_animator.SetInteger("skill_0x", 2);
                            if (Skill_public_funtion.MC_HP_tmp != static_parameters.MC_HP)
                            {
                                Skill_public_funtion.MC_HP_tmp = static_parameters.MC_HP;
                                static_parameters.MC_ATK = Mathf.Pow(1.75f - static_parameters.MC_HP / static_parameters.MC_HP_Max, 2);
                                if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.2f)
                                {
                                    skill03C.SetInteger("A03C", 3);
                                }
                                else if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.4f)
                                {
                                    skill03C.SetInteger("A03C", 2);
                                }
                                else if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
                                {
                                    skill03C.SetInteger("A03C", 1);
                                }
                                Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
                            }
                            break;
                        case 4:
                            skill01_animator.SetInteger("skill_0x", 2);
                            if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp && Skill_public_funtion.skill_04_atk)
                            {
                                Debug.Log("skill_04");
                                Skill_public_funtion.skill_04_atk = false;
                                static_parameters.MC_ATK *= 1.5f;
                            }
                            break;
                        case 5:
                            skill01_animator.SetInteger("skill_0x", 2);
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
                else
                {
                    switch (icon.iconID)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            skill03C.SetInteger("A03C", 0);
                            skill01_animator.SetInteger("skill_0x", 1);
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
                    case 31:
                        if (Skill_public_funtion.skill_31_dash && Skill_public_funtion.skill_31_open)
                        {
                            Skill_public_funtion.skill_31_open = false;
                            // skill31_animator.SetBool("skill31", true);
                            skill31_animator_1.SetTrigger("skill31_1");
                            lastTriggerPosition_31 = transform.position;
                        }
                        if (Skill_public_funtion.skill_31_dash)
                        {
                            if (Vector3.Distance(transform.position, lastTriggerPosition_31) >= skill31_triggerDistance)
                            {
                                Instantiate(skill_hit_box31, skill_hit_box31_postion.position, skill_hit_box31_postion.rotation);
                                lastTriggerPosition_31 = transform.position;
                            }
                        }
                        // else if (Skill_public_funtion.skill_31_dash == false && Skill_public_funtion.skill_31_open == false)
                        // {
                        //     Skill_public_funtion.skill_31_open = true;
                        //     skill31_animator.SetBool("skill31", false);
                        // }
                        break;
                    case 32:
                        if (Skill_public_funtion.skill_32_Dash_end)
                        {
                            Skill_public_funtion.skill_32_Dash_end = false;
                            Skill_public_funtion.skill_32_Dash_time = 0;
                            static_parameters.MC_Wspeed *= 1.2f;
                            Debug.Log("skill_32_Dash_direction:" + Skill_public_funtion.skill_32_33_Dash_direction);
                        }
                        if (Skill_public_funtion.skill_32_Dash_time < 2f)
                        {
                            if (Skill_public_funtion.skill_32_33_Dash_direction == 1 || Skill_public_funtion.skill_32_33_Dash_direction == 3)
                            {
                                skill32_animator_1.SetBool("skill32", true);
                                skill32_animator_2.SetBool("skill32", false);
                                skill32_animator_3.SetBool("skill32", false);
                            }
                            else if (Skill_public_funtion.skill_32_33_Dash_direction == 2)
                            {
                                skill32_animator_1.SetBool("skill32", false);
                                skill32_animator_2.SetBool("skill32", true);
                                skill32_animator_3.SetBool("skill32", false);
                            }
                            else if (Skill_public_funtion.skill_32_33_Dash_direction == 4)
                            {
                                skill32_animator_1.SetBool("skill32", false);
                                skill32_animator_2.SetBool("skill32", false);
                                skill32_animator_3.SetBool("skill32", true);
                            }
                            Skill_public_funtion.skill_32_Dash_time += Time.deltaTime;
                        }
                        else if (Skill_public_funtion.skill_32_Dash_time < 3f)
                        {
                            Skill_public_funtion.skill_32_Dash_time = 5f;
                            skill32_animator_1.SetBool("skill32", false);
                            skill32_animator_2.SetBool("skill32", false);
                            skill32_animator_3.SetBool("skill32", false);
                            static_parameters.MC_Wspeed /= 1.2f;
                            Skill_public_funtion.skill_32_Dash_time = 15f;
                        }
                        break;
                    case 33:
                        if (Skill_public_funtion.skill_33_Dash)
                        {
                            Debug.Log("skill_33_Dash");
                            Skill_public_funtion.skill_33_Dash = false;
                            if (Skill_public_funtion.skill_32_33_Dash_direction == 1 || Skill_public_funtion.skill_32_33_Dash_direction == 3)
                            {
                                skill33_animator_1.SetTrigger("skill33");
                            }
                            else if (Skill_public_funtion.skill_32_33_Dash_direction == 2)
                            {
                                skill33_animator_2.SetTrigger("skill33");
                            }
                            else if (Skill_public_funtion.skill_32_33_Dash_direction == 4)
                            {
                                skill33_animator_3.SetTrigger("skill33");
                            }
                            StartCoroutine(Delayed_skill33());
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
    IEnumerator Delayed_skill31()
    {
        Instantiate(skill_hit_box31, skill_hit_box31_postion.position, skill_hit_box31_postion.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(skill_hit_box31, skill_hit_box31_postion.position, skill_hit_box31_postion.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(skill_hit_box31, skill_hit_box31_postion.position, skill_hit_box31_postion.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(skill_hit_box31, skill_hit_box31_postion.position, skill_hit_box31_postion.rotation);
    }

    IEnumerator Delayed_skill33()
    {
        Debug.Log("Delayed_skill33");
        yield return new WaitForSeconds(0.15f);
        if (Skill_public_funtion.skill_32_33_Dash_direction == 1 || Skill_public_funtion.skill_32_33_Dash_direction == 3)
        {
            Instantiate(bullet33, skill33_Firepoint_1.position, transform.rotation);
        }
        else if (Skill_public_funtion.skill_32_33_Dash_direction == 2)
        {
            Instantiate(bullet33, skill33_Firepoint_2.position, transform.rotation);
        }
        else if (Skill_public_funtion.skill_32_33_Dash_direction == 4)
        {
            Instantiate(bullet33, skill33_Firepoint_3.position, transform.rotation);
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
                        else if (static_parameters.bullet_quantity < 4)
                        {
                            Skill_public_funtion.skill_11_throw_time = 0;
                            StartCoroutine(skill_11_after());
                        }
                        break;
                    case 13:
                        if (Skill_public_funtion.skill_13_bullet_atk == 1f)
                        {
                            Skill_public_funtion.skill_13_bullet_atk = 2f;
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

    IEnumerator skill_11_after()
    {
        skill11_animatorA[static_parameters.bullet_quantity].SetTrigger("skill11A");
        yield return new WaitForSeconds(1.15f);
        Instantiate(throw11, Firepoint.position, transform.rotation);
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
