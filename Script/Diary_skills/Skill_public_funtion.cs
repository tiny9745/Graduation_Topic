using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Skill_public_funtion : MonoBehaviour
{
    static public int feel_to_skill = -1;

    static public bool play_piano = true; static public uint play_piano_level = 1,play_piano_addition = 0;static public short P_time = 4;//skill 01
    static public bool fight_instinct = false; static public uint fight_instinct_level = 1,fight_instinct_addition = 0;//skill 02
    static public bool Accurate_calculation = false; static public uint Accurate_calculation_level = 1,Accurate_calculation_addition = 0;//skill 03

    static public bool Normal_blood_deduction_NPC = false;
    static public float blood_deduction_NPC_count = 0;
    static public int ATK_count = 0;
    static public float MC_HP_tmp = static_parameters.MC_HP;
    static public float MC_Wspeed_tmp = static_parameters.MC_Wspeed;
}
