using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class static_parameters : MonoBehaviour
{
    //Player's basic value
    static public int MC_HP_Max = 200;
    static public int MC_HP = MC_HP_Max;
    static public int MC_HP_tmp = MC_HP;
    static public int MC_ATK = 15;
    static public int MC_Wspeed = 5;
    static public float MC_ATK_Speed = 1;

    static public int Max_enemy = 10;//Default number of enemies
    static public int Change_enemy = Max_enemy;

    static public bool isSceneLoading = false; // 用于跟踪场景是否正在加载
}
