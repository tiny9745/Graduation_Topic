using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_public_funtion : MonoBehaviour // this change Remembers change the All_return.cs
{
    static public bool Reading = false; static public int WOW, SAD, HAPPY, ANGRY,Pain, mood_number = 0;
    static public bool play_piano = false;//old
    static public short P_time = 4; static public float B_damage = 0;//skill 01

    static public float blood_deduction_NPC_count = 0;
    static public int ATK_count = 0;
    static public float MC_HP_tmp = static_parameters.MC_HP;
    static public float MC_Wspeed_tmp = static_parameters.MC_Wspeed;
    static public float skill_01_time = 0;
    static public bool skill_04_atk = true;
    static public bool skill_05_atk = false;

    static public float skill_11_throw_time = 0;
    static public float skill_13_bullet_atk = 1f;
    static public bool skill_14_enter = false;

    static public ushort skill_32_33_Dash_direction = 4;
    static public bool skill_31_dash = false, skill_31_open = true, skill_32_Dash_end = false, skill_33_Dash = false, skill_34_Dash = false;
    static public float skill_34_atk = 15, skill_12_atk = 5;
    static public float skill_32_Dash_time = 15, skill_35_Dash_Magnification = 1f;

    static public int skill_4x_Sorting = 1;
    static public bool skill_41_enter = true; static public int skill_41_Atk = 10;
    static public bool skill_42_enter = true; static public int skill_42_Atk = 6;
    static public bool skill_43_enter = true, skill_44_enter = true;
    static public bool skill_45_enter = true; static public int skill_45_Atk = 22;

    static public List<HashSet<int>> validSequences; // 有效的組合數列
    static public List<HashSet<int>> validSequences_re = new List<HashSet<int>>(){
            new HashSet<int> { 1, 2, 5, 6 },//#空閒時間 #食物 #小玩具 #書籍-甜食折價券
            new HashSet<int> { 1, 2, 4, 5 },//#空閒時間 #父母 #小玩具 #書籍-新開的店
            new HashSet<int> { 2, 6 },//#空閒時間#食物-鎮上的雜貨店
            new HashSet<int> { 2, 4, 6 },//#空閒時間 #父母 #食物-午餐
            new HashSet<int> { 1, 3 },//#書籍 #植物-書籤

            new HashSet<int> { 11, 16, 17 },//#書籍 #父母 #魔法-新讀的小說
            new HashSet<int> { 11, 12, 17, 19 },//#父母 #天氣 #補習班 #書籍-雨夜
            new HashSet<int> { 13, 16, 18 },//#課業 #魔法 #食物-夢由心生
            new HashSet<int> { 11, 14, 16 },//#書籍 #魔法 #空閒時間-創作
            new HashSet<int> { 11, 15 },//#圖書館 #書籍-古老書籍

            new HashSet<int> { 22, 26 },//#鋼琴 #老師-手指
            new HashSet<int> { 21, 22, 26 },//#鋼琴 #老師 #食物-何乃老師
            new HashSet<int> { 22, 23, 25, 26 },//#鋼琴 #父母 #老師 #課業-敷衍塞責
            new HashSet<int> { 22, 24 },//#鋼琴 #學校-學校音樂會
            new HashSet<int> { 22, 24, 25, 26 },//#鋼琴 #老師 #課業 #學校-音樂課

            new HashSet<int> { 32, 36, 37 },//#課業 #老師 #補習班-補習日
            new HashSet<int> { 35, 36, 37 },//#課業 #老師 #學校-作文欣賞
            new HashSet<int> { 32, 34, 35, 39 },//#補習班 #父母 #學校 #天氣-失眠
            new HashSet<int> { 35, 37, 38 },//#老師 #小玩具 #學校-班導對話
            new HashSet<int> { 31, 33 },//#空閒時間 #書籍-新日記本

            new HashSet<int> { 42, 44 },//#圖書館 #植物-圖書館的新生命
            new HashSet<int> { 42, 44, 45 },//#圖書館 #植物 #學校-除塵
            new HashSet<int> { 41, 42, 44 },//#圖書館 #植物 #書籍-花苞
            new HashSet<int> { 43, 44 },//#植物 #魔法-禮物
            new HashSet<int> { 42, 44, 46 },//#圖書館 #植物 #天氣-無精打采
    };
}
