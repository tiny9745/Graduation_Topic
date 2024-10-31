using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class initiator_MC : MonoBehaviour
{
    float timer_f = 0;
    bool time_A_B = false;
    public float NPC_DEF;

    private Vector3 previousPosition;
    float accumulatedDistance = 0;
    bool timer_close = true;

    // Start is called before the first frame update
    void Start()
    {
        Skill_public_funtion.play_piano = true;
        Skill_public_funtion.feel_to_skill = 2; // 0=happy,1=angry,2=sad,3=wow
        Debug.Log("feel_to_skill:" + Skill_public_funtion.feel_to_skill);
        previousPosition = transform.position;
        Skill_public_funtion.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill_public_funtion.fight_instinct == true) Invoke("fight_instinct", 0.5f);
        if (Skill_public_funtion.Accurate_calculation == true) Invoke("Accurate_calculation", 0.25f);
    }

    void fight_instinct()
    {
        if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
        {
            switch (Skill_public_funtion.feel_to_skill)
            {
                case 0:
                    timer_f += Time.deltaTime;
                    if (Skill_public_funtion.Normal_blood_deduction_NPC == true)
                    {
                        Skill_public_funtion.Normal_blood_deduction_NPC = false;
                        timer_f = 0;
                        static_parameters.MC_HP += Mathf.Pow(static_parameters.MC_ATK, 2) / (static_parameters.MC_ATK + NPC_DEF) * 0.1f;
                        if (static_parameters.MC_HP >= static_parameters.MC_HP_Max) static_parameters.MC_HP = static_parameters.MC_HP_Max;
                        Debug.Log("MC_HP" + static_parameters.MC_HP);
                    }
                    else if (Skill_public_funtion.Normal_blood_deduction_NPC == false && timer_f > 10f)
                    {
                        static_parameters.MC_HP -= static_parameters.MC_HP_Max / 20;
                        timer_f = 0;
                        Debug.Log("MC_HP" + static_parameters.MC_HP);
                    }
                    break;
                case 1:
                    //to_Skill_outsourcing
                    break;
                case 2:
                    if (Skill_public_funtion.MC_HP_tmp != static_parameters.MC_HP)
                    {
                        Skill_public_funtion.MC_HP_tmp = static_parameters.MC_HP;
                        static_parameters.MC_ATK = Mathf.Pow(1.75f - static_parameters.MC_HP / static_parameters.MC_HP_Max, 2);
                        Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
                    }
                    break;
                case 3:
                    if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp)
                    {
                        Debug.Log("MC_ATK(before):" + static_parameters.MC_ATK);
                        static_parameters.MC_ATK *= 1.5f;
                        Debug.Log("MC_ATK(after):" + static_parameters.MC_ATK);
                    }
                    if (Skill_public_funtion.Normal_blood_deduction_NPC == true)
                    {
                        Skill_public_funtion.Normal_blood_deduction_NPC = false;
                        static_parameters.MC_HP -= Mathf.Pow(static_parameters.MC_ATK, 2) / (static_parameters.MC_ATK + static_parameters.MC_DEF) * 0.1f;
                    }
                    break;
            }
        }
        else //reduction
        {
            static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
        }

    }
    void Accurate_calculation()
    {

        switch (Skill_public_funtion.feel_to_skill)
        {
            case 0:
                timer_f += Time.deltaTime;
                if (timer_f > 15)
                {
                    timer_f = 0;
                    time_A_B = !time_A_B;
                    if (time_A_B)
                    {
                        static_parameters.MC_ATK *= 1.1f;
                        static_parameters.MC_DEF = static_parameters.MC_DEF_tmp;
                    }
                    else
                    {
                        static_parameters.MC_DEF *= 1.1f;
                        static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
                    }
                    Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
                    Debug.Log("MC_DEF:" + static_parameters.MC_DEF);
                }

                break;
            case 1:
                if (Skill_public_funtion.blood_deduction_NPC_count >= 400)
                {
                    Skill_public_funtion.blood_deduction_NPC_count = 0;
                    static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
                    time_A_B = !time_A_B;
                    if (time_A_B)
                    {
                        static_parameters.MC_ATK *= 1.5f;
                    }
                    else
                    {
                        static_parameters.MC_ATK *= 0.8f;
                    }
                    Debug.LogWarningFormat("MC_ATK:" + static_parameters.MC_ATK);
                }

                break;
            case 2:
                float distance = Vector3.Distance(previousPosition, transform.position);
                accumulatedDistance += distance;
                previousPosition = transform.position;
                //Debug.Log("add_distance: " + accumulatedDistance);
                if (accumulatedDistance >= 40)
                {
                    time_A_B = !time_A_B;
                    static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
                    static_parameters.MC_Wspeed = Skill_public_funtion.MC_Wspeed_tmp;
                    accumulatedDistance = 0;
                    timer_f = 0;
                    timer_close = true;
                }
                if (time_A_B)
                {
                    if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp && timer_f < 2)
                    {
                        static_parameters.MC_ATK *= 2f;
                        Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
                    }
                    else
                    {
                        timer_f += Time.deltaTime;
                        if (timer_f > 5 && timer_close)
                        {
                            timer_close = false;
                            static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
                            Debug.Log("MC_ATK:" + static_parameters.MC_ATK);
                        }
                    }
                }
                else
                {
                    if (static_parameters.MC_Wspeed == Skill_public_funtion.MC_Wspeed_tmp && timer_f < 2)
                    {
                        static_parameters.MC_Wspeed *= 2f;
                        Debug.Log("MC_speed:" + static_parameters.MC_Wspeed);
                    }
                    else
                    {
                        timer_f += Time.deltaTime;
                        if (timer_f > 5 && timer_close)
                        {
                            timer_close = false;
                            static_parameters.MC_Wspeed = Skill_public_funtion.MC_Wspeed_tmp;
                            Debug.Log("MC_speed:" + static_parameters.MC_Wspeed);
                        }
                    }
                }
                break;
            case 3:
                if (Skill_public_funtion.ATK_count >= 25)
                {
                    Skill_public_funtion.ATK_count = 0;
                    static_parameters.MC_DEF = static_parameters.MC_DEF_tmp;
                    time_A_B = !time_A_B;
                    if (time_A_B)
                    {
                        static_parameters.MC_DEF = static_parameters.MC_DEF * 1.25f;
                    }
                    else
                    {
                        static_parameters.MC_DEF = static_parameters.MC_DEF * 0.8f;
                    }
                    Debug.Log("MC_DEF:" + static_parameters.MC_DEF);
                }
                break;

        }
    }
}
