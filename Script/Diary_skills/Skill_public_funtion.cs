using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_public_funtion : MonoBehaviour
{
    static public int feel_to_skill = -1;//old
    static public bool play_piano = false;//old
    static public short P_time = 4; static public float B_damage = 0;//skill 01

    static public bool Normal_blood_deduction_NPC = false;
    static public float blood_deduction_NPC_count = 0;
    static public int ATK_count = 0;
    static public float MC_HP_tmp = static_parameters.MC_HP;
    static public float MC_Wspeed_tmp = static_parameters.MC_Wspeed;

    static public float skill_01_time = 0;
    static public int skill_05_atk = -1;

    static public bool skill_51_trigger_enter = false;
    static public bool skill_52_Dash_end = false; static public float skill_52_Dash_time = 0;
    static public bool skill_53_Dash = false;
    static public bool skill_54_Dash = false;
    static public float skill_55_Dash_Magnification = 1f;
    static public float skill_11_throw_time = 0;
}
