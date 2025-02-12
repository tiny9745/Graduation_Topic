using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_effect_03 : MonoBehaviour
{
    public NPC03_control control; public NPC_HP_03 HP_control; public skill_piano_effect _skill_piano_effect;
    public GameObject bomb_piano, bomb_point, Ward12;
    int play_piano_atk = 0; float NPC_back = 20, minus;
    bool piano_flag = true;
    public Animator skill_2x_animator, skill21_animator, skill22_animator, skill23_animator, skill24_animator, skill25_1_animator, skill25_2_animator;

    private bool skill_15_stop_time_trigger = true; private float skill_15_stop_time = 0;

    private bool skill_25_effect = false; private float skill_25_effect_time = 0; private float skill_25_max_time = 2, skill_25_step_time = 0.5f;


    // Update is called once per frame
    void Update()
    {
        skill_update();
    }
    public void piano_Skill()
    {
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                if (Skill_public_funtion.play_piano)
                {
                    break;
                }
                else if (icon.iconID >= 20 && icon.iconID < 30)
                {
                    Skill_public_funtion.play_piano = true;
                }
            }
        }
        else
        {
            Debug.Log("IconManager.Instance == null");
        }
        if (Skill_public_funtion.play_piano)
        {
            Debug.Log("piano NPC03 skill");
            if (play_piano_atk < Skill_public_funtion.P_time - 1)
            {
                play_piano_atk++;
                Debug.Log("NPC03 skill_2x:" + play_piano_atk);
                if (play_piano_atk == 1)
                {
                    _skill_piano_effect.FadeInMoveUp(0.25f, 4f);
                }
                else if (play_piano_atk > 1)
                {
                    _skill_piano_effect.JumpAnimation(4f, 0.25f, play_piano_atk - 1);
                }
            }
            else
            {
                Debug.Log("NPC03 skill_2x complete!");
                Instantiate(bomb_piano, bomb_point.transform.position, Quaternion.identity);
                play_piano_atk = 0;
            }
        }
    }
    public void play_piano_effect()
    {
        piano_flag = true;
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                if (icon.iconID >= 20 && icon.iconID < 30)
                {
                    skill_2x_animator.SetTrigger("skill_base_bomb");
                }
                switch (icon.iconID)
                {
                    case 21: // Bomb
                        Debug.Log("NPC03 skill_21");
                        skill21_animator.SetTrigger("skill_bomb21");
                        play_piano_atk = 0;
                        Skill_public_funtion.B_damage += 10;
                        continue;

                    case 22: // Flash
                        Debug.Log("NPC03 skill_22");
                        skill22_animator.SetBool("skill_bomb22", true);
                        Skill_public_funtion.B_damage += 15;
                        control.stun = true;
                        Invoke(nameof(Stun_end), 3);
                        continue;

                    case 23: // Ricochet
                        Debug.Log("NPC03 skill_23");
                        skill23_animator.SetTrigger("skill_bomb23");
                        Skill_public_funtion.B_damage += 20;
                        piano_flag = false;
                        play_piano_atk++;
                        continue;

                    case 24: // Air Bullet
                        Debug.Log("NPC03 skill_24");
                        skill24_animator.SetTrigger("skill_bomb24");
                        Skill_public_funtion.B_damage += 15;
                        if (control.NPC_HP < NPC_back)
                            control.NPC_HP = 0;
                        else
                            transform.position -= NPC_back * Vector3.back;
                        continue;
                    case 25: // Smoke Bomb
                        skill_25_effect = true;
                        skill25_1_animator.SetBool("skill_bomb25_1", true);
                        skill25_2_animator.SetBool("skill_bomb25_2", true);
                        continue;
                    default:
                        continue;
                }
            }
            damage(Skill_public_funtion.B_damage);
            Reset_flag();
            control.change_color_red();
            if (play_piano_atk >= 5)
            {
                Debug.Log("NPC03 play_piano_atk warning! " + play_piano_atk);
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
        HP_control.UpdateHealthBar();
    }

    public void fight_instinct_npc()//被MC攻擊時作用
    {
        if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
        {
            if (IconManager.Instance != null)
            {
                foreach (var icon in IconManager.Instance.IconList)
                {
                    switch (icon.iconID)
                    {
                        case 1:
                            Debug.Log("NPC03 skill_01");
                            Skill_public_funtion.skill_01_time = 0;
                            static_parameters.MC_HP += static_parameters.MC_ATK * static_parameters.MC_ATK / (static_parameters.MC_ATK + control.NPC03_DEF) / 4;
                            if (static_parameters.MC_HP >= static_parameters.MC_HP_Max * 0.6f) static_parameters.MC_HP = static_parameters.MC_HP_Max * 0.6f;
                            break;
                        case 4:
                            Debug.Log("NPC04 skill_04");
                            static_parameters.MC_HP -= static_parameters.MC_ATK * static_parameters.MC_ATK / (static_parameters.MC_ATK + control.NPC03_DEF) / 10;
                            break;
                        case 5:
                            if (Skill_public_funtion.skill_05_atk == true)
                            {
                                Debug.Log("NPC03 skill_05");
                                Skill_public_funtion.skill_05_atk = false;
                                static_parameters.MC_ATK = static_parameters.MC_ATK_tmp;
                            }
                            break;
                    }
                }
            }
        }
    }

    public void fight_instinct_MC()//攻擊MC時
    {
        if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
        {
            if (IconManager.Instance != null)
            {
                foreach (var icon in IconManager.Instance.IconList)
                {
                    switch (icon.iconID)
                    {
                        case 2:
                            HP_control.TakeDamage(static_parameters.MC_ATK / 5, static_parameters.MC_DEF / 5);
                            break;
                    }
                }
            }
        }
    }

    public void skill_update()
    {
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                {
                    Skill_public_funtion.play_piano = true;
                }
                switch (icon.iconID)
                {
                    case 15:
                        if (skill_15_stop_time_trigger)
                        {
                            if (skill_15_stop_time < 10.5f)
                            {
                                skill_15_stop_time += Time.deltaTime;
                            }
                            else
                            {
                                Debug.Log("NPC03 rewalk");
                                skill_15_stop_time_trigger = false;
                                control.npcNavi.speed = control.npcSpeed;
                                break;
                            }
                        }
                        break;
                    case 25:
                        if (skill_25_effect && skill_25_effect_time < 5)
                        {
                            skill_25_effect_time += Time.deltaTime;
                            if (skill_25_effect_time >= skill_25_max_time)
                            {
                                skill_25_step_time = 0.5f;
                                skill25_1_animator.SetBool("skill_bomb25_1", false);
                                skill25_2_animator.SetBool("skill_bomb25_2", false);
                                skill_25_effect = false;
                                skill_25_effect_time = 0;
                                break;
                            }
                            else if (skill_25_effect_time >= skill_25_step_time)
                            {
                                HP_control.TakeDamage(5, control.NPC03_DEF);
                                skill_25_step_time += 0.5f;
                                Debug.Log("NPC03 skill_25_step_time:" + skill_25_step_time);
                            }
                        }
                        break;
                }
            }
        }
    }

    public void skill_TriggerEnter(Collider other)
    {
        if (IconManager.Instance != null)
        {
            foreach (var icon in IconManager.Instance.IconList)
            {
                switch (icon.iconID)
                {
                    case 12:
                        if (other.gameObject.tag == "MC_bullet")
                        {
                            Vector3 point = new Vector3(transform.position.x, 0f, transform.position.z);
                            Instantiate(Ward12, point, Ward12.transform.rotation);
                        }
                        break;
                    case 15://trigger Enter tag = "MC_bullet"
                        if (other.gameObject.tag == "MC_bullet")
                        {
                            Debug.Log("NPC03 Stop");
                            skill_15_stop_time_trigger = true;
                            skill_15_stop_time = 0;
                            control.npcNavi.speed = 0;
                        }
                        break;
                    case 31:
                        if (Skill_public_funtion.skill_31_dash && other.gameObject.tag == "Player")
                        {
                            Debug.Log("NPC03 skill_31");
                            HP_control.TakeDamage(static_parameters.MC_ATK / 2, static_parameters.MC_DEF / 2);
                        }
                        break;
                }
            }

            if (other.gameObject.tag == "skill_41_bullet")
            {
                HP_control.TakeDamage(Skill_public_funtion.skill_41_Atk, static_parameters.MC_DEF);
            }
            if (other.gameObject.tag == "skill_42_bullet")
            {
                HP_control.TakeDamage(Skill_public_funtion.skill_42_Atk, static_parameters.MC_DEF);
            }
            if (other.gameObject.tag == "skill_45_bullet")
            {
                HP_control.TakeDamage(Skill_public_funtion.skill_45_Atk, static_parameters.MC_DEF);
            }
            if (other.gameObject.tag == "skill_34_ward")
            {
                HP_control.TakeDamage(Skill_public_funtion.skill_34_atk, static_parameters.MC_DEF);
            }
        }
    }
}
