using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class static_parameters : MonoBehaviour
{
    //Player's basic value
    static public float MC_HP_Max = 100;static public float MC_HP = MC_HP_Max;
    static public float MC_HP_tmp = MC_HP; static public float MC_HP_Max_tmp = MC_HP_Max;
    static public float MC_ATK = 1; static public float MC_DEF = 10;
    static public float MC_Wspeed = 6; static public float MC_Wspeed_tmp = MC_Wspeed;
    static public float MC_ATK_Speed = 1; static public float MC_ATK_Speed_tmp = MC_ATK_Speed;
    static public short Attactstate = 0;
    static public bool invincible = false;
    static public int Change_enemy = 0;

    static public bool isSceneLoading = false; //Used to track whether the scene is loading
    static public bool Bookstate = false; //Used to track whether the scene is changing
    static public bool filp = false; //to trigger the flip animation
    static public int stage_number = 0;
}
