using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS01_HP : MonoBehaviour
{
    // public SpriteRenderer healthBarFill;
    float MaxHealth, minus;
    public Boss_col control;
    void Start()
    {
        MaxHealth = control.BOSS_HP_Max;
    }


    public void TakeDamage(float damage, float NPC_DEF)
    {
        control.change_color_red();
        minus = (float)(damage * damage / (damage + NPC_DEF));
        if (minus < 5) minus = 5;
        control.BOSS_HP -= minus;
        control.BOSS_HP = Mathf.Clamp(control.BOSS_HP, 0, MaxHealth);
        Debug.Log("BOSS_HP01:" + control.BOSS_HP);
    }
}
