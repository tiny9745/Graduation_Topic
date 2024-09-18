using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiator_MC : MonoBehaviour
{
    float timer_f = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fight_instinct();
        Accurate_calculation();
    }

    void fight_instinct()
    {
        if (Skill_public_funtion.fight_instinct == true)
        {
            if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
            {
                switch (Skill_public_funtion.feel_to_skill)
                {
                    case 0:
                        timer_f += Time.deltaTime;
                        if (Skill_public_funtion.Normal_blood_deduction_NPC == true)
                        {
                            timer_f = 0;
                            Skill_public_funtion.Normal_blood_deduction_NPC = false;
                        }
                        else if (Skill_public_funtion.Normal_blood_deduction_NPC == false && timer_f > 10f)
                        {
                            static_parameters.MC_HP -= static_parameters.MC_HP_Max / 20;
                            timer_f = 0;
                        }
                        break; 
                    case 1:
                        //to_NPC
                        break; 
                    case 2:
                        if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp) { static_parameters.MC_ATK = Mathf.Pow(1.75f - static_parameters.MC_HP / static_parameters.MC_HP_Max, 2); }
                        break;
                    case 3:
                        if (static_parameters.MC_ATK == static_parameters.MC_ATK_tmp) static_parameters.MC_ATK *= 1.5f;
                        break;
                }
            }
            else //reduction
            {
                static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
            }
        }
    }
    void Accurate_calculation()
    {
        if (Skill_public_funtion.Accurate_calculation == true)
        {
            switch (Skill_public_funtion.feel_to_skill)
            {
                case 0:

                    break; 
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
            }
        }
    }
}
