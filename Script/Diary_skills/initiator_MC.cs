using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiator_MC : MonoBehaviour
{
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
                if (Skill_public_funtion.feel_to_skill == 0)
                {
                    if (Skill_public_funtion.Normal_blood_deduction_NPC == true)
                    {

                    }
                    else if (Skill_public_funtion.Normal_blood_deduction_NPC == false &&)
                    {

                    }
                }
                else if (Skill_public_funtion.feel_to_skill == 1)
                {

                }
                else if (Skill_public_funtion.feel_to_skill == 2)
                {

                }
                else if (Skill_public_funtion.feel_to_skill == 3)
                {

                }
            }
        }
    }
    void Accurate_calculation()
    {
        if (Skill_public_funtion.Accurate_calculation == true)
        {
            if (Skill_public_funtion.feel_to_skill == 0)
            {

            }
            else if (Skill_public_funtion.feel_to_skill == 1)
            {

            }
            else if (Skill_public_funtion.feel_to_skill == 2)
            {

            }
            else if (Skill_public_funtion.feel_to_skill == 3)
            {

            }
        }
    }
}
