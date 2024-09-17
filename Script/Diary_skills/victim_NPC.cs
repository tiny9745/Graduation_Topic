using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victim_NPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill_public_funtion.fight_instinct[0] == true)
        {
            if(static_parameters.MC_HP/static_parameters.MC_HP_Max<=0.6f){

            }
        }
        else if (Skill_public_funtion.fight_instinct[1] == true)
        {

        }
        else if (Skill_public_funtion.fight_instinct[2] == true)
        {

        }
        else if (Skill_public_funtion.fight_instinct[3] == true)
        {

        }

        if (Skill_public_funtion.Accurate_calculation[0] == true)
        {

        }
        else if (Skill_public_funtion.Accurate_calculation[1] == true)
        {

        }
        else if (Skill_public_funtion.Accurate_calculation[2] == true)
        {

        }
        else if (Skill_public_funtion.Accurate_calculation[3] == true)
        {

        }
    }
}
