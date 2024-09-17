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
        if (Skill_public_funtion.fight_instinct[0] == true)
        {

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
    }
    void Accurate_calculation()
    {
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
