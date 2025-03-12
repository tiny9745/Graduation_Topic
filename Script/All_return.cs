using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_return : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        static_parameters.MC_HP_Max = 50;
        static_parameters.MC_HP = static_parameters.MC_HP_Max;
        static_parameters.MC_HP_tmp = static_parameters.MC_HP;
        static_parameters.MC_HP_Max_tmp = static_parameters.MC_HP_Max;
        static_parameters.MC_ATK = 115;
        static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
        static_parameters.MC_DEF = 120;
        static_parameters.MC_DEF_tmp = static_parameters.MC_DEF;
        static_parameters.MC_Wspeed = 20f;
        static_parameters.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
        static_parameters.knockback_force = 3;
        static_parameters.MC_ATK_Speed = 1;
        static_parameters.MC_ATK_Speed_tmp = static_parameters.MC_ATK_Speed;
        static_parameters.stage_number = 0;
        static_parameters.stage_number_Boss = 0;
        // static_parameters.stage_number_Store = 0;
        // static_parameters.stage_number_Award = 0;
        static_parameters.Text_box_state = new int[] { 1, 1, 0, 0 };
        // static_parameters.isSceneLoading = false;
        static_parameters.Bookstate = false;
        // static_parameters.filp = false;
        static_parameters.invincible = false;
        static_parameters.revival = false;
        static_parameters.Ani_state = 0;
        static_parameters.face = 0;
        static_parameters.pickdiary = 1;
        static_parameters.Change_enemy = 0;
        static_parameters.Comic_scene_sort = 0;
        static_parameters.diary_number = 0;
        static_parameters.money = 999999;
        static_parameters.diary_memory = new uint[][]
        {
            new uint[] { 0, 0, 0, 0 },//暫存
            new uint[] { 0, 0, 0, 0 },//以下定存
            new uint[] { 0, 0, 0, 0 },
            new uint[] { 0, 0, 0, 0 },
            new uint[] { 0, 0, 0, 0 }
        };
        // static_parameters.diary_step = 0;
        // static_parameters._BGM_volue = 1;
        // static_parameters._SE_volue = 1;
        static_parameters.Map_start = 0;
        static_parameters.bullet_quantity = 0;
        static_parameters._ItemID = 0;
        static_parameters.Piece_ID = 0;
        static_parameters._IconID = 0;
        static_parameters.teaching_stop = 100;
        static_parameters.isTeaching = false;
        static_parameters.wait_atk_return = false;
        static_parameters.into_gameFight = false;

        Skill_public_funtion.Reading = false;
        Skill_public_funtion.WOW = 0;
        Skill_public_funtion.SAD = 0;
        Skill_public_funtion.HAPPY = 0;
        Skill_public_funtion.ANGRY = 0;
        Skill_public_funtion.mood_number = 0;
        Skill_public_funtion.play_piano = false;
        Skill_public_funtion.P_time = 4;
        Skill_public_funtion.B_damage = 0;
        // Skill_public_funtion.Normal_blood_deduction_NPC = false;
        Skill_public_funtion.blood_deduction_NPC_count = 0;
        Skill_public_funtion.ATK_count = 0;
        Skill_public_funtion.MC_HP_tmp = static_parameters.MC_HP;
        Skill_public_funtion.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
        Skill_public_funtion.skill_01_time = 0;
        Skill_public_funtion.skill_04_atk = true;
        Skill_public_funtion.skill_05_atk = false;
        Skill_public_funtion.skill_32_33_Dash_direction = 4;
        Skill_public_funtion.skill_31_dash = false;
        Skill_public_funtion.skill_31_open = true;
        Skill_public_funtion.skill_32_Dash_end = false;
        Skill_public_funtion.skill_33_Dash = false;
        Skill_public_funtion.skill_34_Dash = false;
        Skill_public_funtion.skill_34_atk = 15;
        Skill_public_funtion.skill_12_atk = 5;
        Skill_public_funtion.skill_32_Dash_time = 15;
        Skill_public_funtion.skill_35_Dash_Magnification = 1f;
        Skill_public_funtion.skill_11_throw_time = 0;
        Skill_public_funtion.skill_13_bullet_atk = 1f;
        Skill_public_funtion.skill_14_enter = false;
        Skill_public_funtion.skill_4x_Sorting = 1;
        Skill_public_funtion.skill_41_enter = true;
        Skill_public_funtion.skill_41_Atk = 10;
        Skill_public_funtion.skill_42_enter = true;
        Skill_public_funtion.skill_42_Atk = 6;
        Skill_public_funtion.skill_43_enter = true;
        Skill_public_funtion.skill_44_enter = true;
        Skill_public_funtion.skill_45_enter = true;
        Skill_public_funtion.skill_45_Atk = 22;
    }
}
