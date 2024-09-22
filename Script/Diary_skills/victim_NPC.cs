using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victim_NPC : MonoBehaviour
{
    public float NPC_Atk, NPC_Def, NPC_Hp;
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
                switch (Skill_public_funtion.feel_to_skill)
                {
                    case 0:
                        //to_MC
                        break;
                    case 1:
                        //to_Skill_outsourcing
                        break;
                    case 2:
                        //to_MC
                        break;
                    case 3:
                        //to_MC
                        break;
                }
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
                    //to_MC
                    break;
                case 1:
                    //to_MC
                    break;
                case 2:
                    //to_MC
                    break;
                case 3:
                    //to_MC
                    break;
            }
        }
    }
}
