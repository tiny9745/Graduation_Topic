using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_public_funtion : MonoBehaviour
{
    static public bool Reading = false; static public int WOW, SAD, HAPPY, ANGRY;
    static public bool play_piano = false;//old
    static public short P_time = 4; static public float B_damage = 0;//skill 01

    static public bool Normal_blood_deduction_NPC = false;
    static public float blood_deduction_NPC_count = 0;
    static public int ATK_count = 0;
    static public float MC_HP_tmp = static_parameters.MC_HP;
    static public float MC_Wspeed_tmp = static_parameters.MC_Wspeed;
    static public float skill_01_time = 0;
    static public bool skill_04_atk = true;
    static public bool skill_05_atk = false;

    static public ushort skill_32_33_Dash_direction = 4;
    static public bool skill_31_dash = false, skill_31_open = true, skill_32_Dash_end = false, skill_33_Dash = false, skill_34_Dash = false;
    static public float skill_34_atk = 15, skill_12_atk = 5;
    static public float skill_32_Dash_time = 15, skill_35_Dash_Magnification = 1f;
    static public float skill_11_throw_time = 0;
    static public float skill_13_bullet_atk = 1f;
    static public bool skill_14_enter = false;

    static public int skill_4x_Sorting = 1;
    static public bool skill_41_enter = true; static public int skill_41_Atk = 10;
    static public bool skill_42_enter = true; static public int skill_42_Atk = 6;
    static public bool skill_43_enter = true, skill_44_enter = true;
    static public bool skill_45_enter = true; static public int skill_45_Atk = 22;
}
