using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class static_parameters : MonoBehaviour
{
    //Player's basic value
    static public int MC_HP_Max = 200;
    static public int MC_HP = MC_HP_Max;
    static public int MC_HP_tmp = MC_HP;
    static public int MC_ATK = 100;
    static public int MC_Wspeed = 10;

    static public float MC_ATK_Speed = 1;
    static public int Change_enemy = 0;

    static public bool isSceneLoading = false; //Used to track whether the scene is loading
    static public bool Bookstate = false; //Used to track whether the scene is changing
    static public bool filp = false; //to trigger the flip animation
    static public int stage_number = 0;
}
