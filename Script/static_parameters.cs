using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class static_parameters : MonoBehaviour
{
    //Need save
    static public float MC_HP_Max = 100, MC_HP = MC_HP_Max, MC_HP_tmp = MC_HP, MC_HP_Max_tmp = MC_HP_Max;
    static public float MC_ATK = 1, MC_ATK_tmp = MC_ATK, MC_DEF = 10, MC_DEF_tmp = MC_DEF, MC_Wspeed = 7, MC_Wspeed_tmp = MC_Wspeed, knockback_force = 3, MC_ATK_Speed = 1, MC_ATK_Speed_tmp = MC_ATK_Speed;
    static public int stage_number = 0, stage_number_Boss = 0;
    static public int stage_number_Store = 0, stage_number_Award = 0;
    public static int[] Text_box_state = { 1, 1, 0, 0 };

    //No need save
    static public bool isSceneLoading = false; //Used to track whether the scene is loading
    static public bool Bookstate = false; //Used to track whether the scene is changing
    static public bool filp = false, invincible = false; //to trigger the flip animation
    static public short Ani_state = 0, face = 0, pickdiary = 1;
    static public int Change_enemy = 0;

    static public int Comic_scene_sort = 0;
    static public int diary_number = 0, money = 999999;
    static public uint[][] diary_memory = new uint[][]
{
    new uint[] { 0, 0, 0, 0 },//暫存
    new uint[] { 0, 0, 0, 0 },//以下定存
    new uint[] { 0, 0, 0, 0 },
    new uint[] { 0, 0, 0, 0 },
    new uint[] { 0, 0, 0, 0 }
};
    static public uint diary_step;

    static public float _BGM_volue;
    static public float _SE_volue;
    static public int Map_start = 0;
}
