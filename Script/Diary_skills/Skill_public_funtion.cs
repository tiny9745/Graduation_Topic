using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Skill_public_funtion : MonoBehaviour
{
    static public int feel_to_skill = -1;

    static public bool fight_instinct = false; static public uint fight_instinct_level = 1; static public uint fight_instinct_addition = 0;//skill 02
    static public bool Accurate_calculation = false; static public uint Accurate_calculation_level = 1; static public uint Accurate_calculation_addition = 0;//skill 03

    //
    static public bool Normal_blood_deduction_NPC = false;
    static public float blood_deduction_NPC_count = 0;
    static public int ATK_count = 0;
}
