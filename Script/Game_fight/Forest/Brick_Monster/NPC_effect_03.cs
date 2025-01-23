using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_effect_03 : MonoBehaviour
{
    public NPC03_control control;
    public GameObject bomb_piano, bomb_point;
    int play_piano_atk = 0; float NPC_back = 20, minus;
    bool piano_flag = true;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
    public void Skill()//skill_add
    {
        Debug.Log("NPC03 skill");
        if (Skill_public_funtion.play_piano)
        {
            if (play_piano_atk <= Skill_public_funtion.P_time)
            {
                play_piano_atk++;
            }
            else
            {
                Instantiate(bomb_piano, bomb_point.transform.position, Quaternion.identity);
                play_piano_atk = 0;
            }
        }
    }
    public void play_piano_effect()
    {
        piano_flag = true;
        foreach (var icon in IconManager.Instance.IconList)
        {
            switch (icon.iconID)
            {
                case 21: // Bomb
                    play_piano_atk = 0;
                    Skill_public_funtion.B_damage += 10;
                    continue;

                case 22: // Flash
                    Skill_public_funtion.B_damage += 15;
                    control.stun = true;
                    Invoke(nameof(Stun_end), 3);
                    continue;

                case 23: // Ricochet
                    Skill_public_funtion.B_damage += 20;
                    piano_flag = false;
                    play_piano_atk++;
                    continue;

                case 24: // Air Bullet
                    Skill_public_funtion.B_damage += 15;
                    if (control.NPC_HP < NPC_back)
                        control.NPC_HP = 0;
                    else
                        transform.position -= NPC_back * Vector3.back;
                    continue;

                case 25: // Smoke Bomb
                    Skill_public_funtion.B_damage += 20;//spawn smoke not done
                    continue;
                default:
                    continue;
            }
        }
        damage(Skill_public_funtion.B_damage);
        Reset_flag();
        control.change_color_red();
    }
    public void fight_instinct_npc()//被攻擊時作用
    {
        foreach (var icon in IconManager.Instance.IconList)
        {
            switch (icon.iconID)
            {
                case 1:
                    Skill_public_funtion.skill_01_time = 0;
                    static_parameters.MC_HP += Mathf.Pow(static_parameters.MC_ATK, 2) / (static_parameters.MC_ATK + control.NPC03_DEF) * 0.1f;
                    if (static_parameters.MC_HP >= static_parameters.MC_HP_Max) static_parameters.MC_HP = static_parameters.MC_HP_Max;
                    break;
                case 2:
                    control.NPC_HP -= Mathf.Pow(control.NPC03_ATK, 2) / (control.NPC03_ATK + static_parameters.MC_DEF) * 0.2f;
                    break;
                case 4:
                    static_parameters.MC_HP -= Mathf.Pow(static_parameters.MC_ATK, 2) / (static_parameters.MC_ATK + control.NPC03_DEF) * 0.1f;
                    break;
                case 5:
                    if (Skill_public_funtion.skill_05_atk == 1)
                    {
                        Skill_public_funtion.skill_05_atk = -1;
                        static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
                    }
                    break;
            }
        }
    }

    void Stun_end()
    {
        control.stun = false;
    }
    void Reset_flag()
    {
        if (piano_flag)
        {
            play_piano_atk = 0;
        }
    }
    void damage(float ATK)
    {
        minus = (float)(ATK * ATK / (control.NPC03_DEF + ATK));
        if (minus < 5) minus = 5.0f;
        control.NPC_HP -= minus;
        Skill_public_funtion.B_damage = 0;
    }
}
