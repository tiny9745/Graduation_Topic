using UnityEngine;

public class static_parameters : MonoBehaviour // this change Remembers change the All_return.cs
{
    //Need save
    static public float MC_HP_Max = 250, MC_HP = MC_HP_Max, MC_HP_tmp = MC_HP, MC_HP_Max_tmp = MC_HP_Max;
    static public float MC_ATK = 13, MC_ATK_tmp = MC_ATK, MC_DEF = 12, MC_DEF_tmp = MC_DEF, MC_Wspeed = 3f, MC_Wspeed_tmp = MC_Wspeed, knockback_force = 3, MC_ATK_Speed = 1, MC_ATK_Speed_tmp = MC_ATK_Speed;
    static public int stage_number = 0, stage_number_Boss = 0;
    // static public int stage_number_Store = 0, stage_number_Award = 0;
    public static int[] Text_box_state = { 1, 1, 0, 0 };

    //No need save
    static public bool Bookstate = false; //Used to track whether the scene is changing
    static public bool invincible = false, revival = false; //to trigger the flip animation
    static public int Ani_state = 0, face = 0, pickdiary = 1;
    static public int Change_enemy = 0;

    static public int Comic_scene_sort = 0;
    static public int diary_number = 0, money = 999999;
    static public float _All_sound = 1, _BGM_volue = 1, _SE_volue = 1;
    static public float _All_sound_tmp = 1, _BGM_volue_tmp = 1, _SE_volue_tmp = 1;
    static public int Map_start = 0;
    static public int bullet_quantity = 0;
    static public int _ItemID, Piece_ID = 0;
    static public int _IconID = 0;
    static public int teaching_stop = 100;
    static public bool isTeaching = false;
    static public bool wait_atk_return = false;
    static public bool MC_NPC_col_move = true;
    static public bool into_gameFight = false;//是否進入戰鬥場景
    static public int into_gameFight_Levels = 0;//戰鬥場景選擇的關卡
}
