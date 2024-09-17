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
        if (Skill_public_funtion.fight_instinct == true)
        {
            if(static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
            {

            }
        }

        if (Skill_public_funtion.Accurate_calculation == true)
        {

        }
    }
}
