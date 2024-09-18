using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victim_NPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 0=happy,1=angry,2=sad,3=wow
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
                    //to_MC
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
