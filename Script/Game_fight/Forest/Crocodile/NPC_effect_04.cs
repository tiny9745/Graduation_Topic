using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_effect_04 : MonoBehaviour
{
    public NPC04_control control; public NPC_HP_04 HP_control; public skill_piano_effect _skill_piano_effect;
    public GameObject bomb_piano, bomb_point, Ward12;
    int play_piano_atk = 0; float NPC_back = 10, minus;
    bool piano_flag = true;
    public Animator skill_01_1, skill_02, skill04_B, skill05A, skill05B;
    public Animator skill_2x_animator, skill21_animator, skill22_animator, skill23_animator, skill24_animator, skill25_1_animator, skill25_2_animator;
    private bool skill_25_effect = false; private float skill_25_effect_time = 0; private float skill_25_max_time = 2, skill_25_step_time = 0.5f;

    void Start()
    {
        GameObject skill_01_1G = GameObject.Find("skill_01_add");
        if (skill_01_1G != null)
        {
            skill_01_1 = skill_01_1G.GetComponent<Animator>();
        }
        GameObject skill05_A = GameObject.Find("skill05_A");
        if (skill05_A != null)
        {
            skill05A = skill05_A.GetComponent<Animator>();
        }
    }
    void Update()
    {
        skill_update();
    }
    public void piano_Skill()//skill_add
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

        if (Skill_public_funtion.play_piano)
        {
            if (play_piano_atk < Skill_public_funtion.P_time)
            {
                play_piano_atk++;
                if (play_piano_atk == 1)
                {
                    _skill_piano_effect.FadeInMoveUp(0.25f, 4f);
                }
                if (play_piano_atk > 0)
                {
                    _skill_piano_effect.JumpAnimation(4f, 0.25f, play_piano_atk - 1);
                }
            }
            else
            {
                _skill_piano_effect.FadeOutMoveDown(0.25f, 4f);
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
                        skill21_animator.SetTrigger("skill_bomb21");
                        play_piano_atk = 0;
                        Skill_public_funtion.B_damage += 10;
                        continue;
                    case 22: // Flash
                        skill22_animator.SetBool("skill_bomb22", true);
                        Skill_public_funtion.B_damage += 15;
                        control.stun = true;
                        Invoke(nameof(Stun_end22), 3);
                        continue;
                    case 23: // Ricochet
                        skill23_animator.SetTrigger("skill_bomb23");
                        Skill_public_funtion.B_damage += 20;
                        piano_flag = false;
                        play_piano_atk++;
                        continue;
                    case 24: // Air Bullet
                        skill24_animator.SetTrigger("skill_bomb24");
                        Skill_public_funtion.B_damage += 15;
                        if (control.NPC_HP < NPC_back)
                            control.NPC_HP = 0;
                        else
                            transform.position -= NPC_back/2 * Vector3.back;
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
        }
    }

    void Stun_end22()
    {
        skill22_animator.SetBool("skill_bomb22", false);
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
        minus = (float)(ATK * ATK / (control.NPC04_DEF + ATK));
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
                            skill_01_1.SetTrigger("skill_01_1");
                            Skill_public_funtion.skill_01_time = 0;
                            static_parameters.MC_HP += static_parameters.MC_ATK * static_parameters.MC_ATK / (static_parameters.MC_ATK + control.NPC04_DEF) / 4;
                            if (static_parameters.MC_HP >= static_parameters.MC_HP_Max * 0.6f) static_parameters.MC_HP = static_parameters.MC_HP_Max * 0.6f;
                            break;
                        case 4:
                            skill04_B.SetTrigger("skill_04_B");
                            static_parameters.MC_HP -= static_parameters.MC_ATK * static_parameters.MC_ATK / (static_parameters.MC_ATK + control.NPC04_DEF) / 10;
                            break;
                        case 5:
                            if (Skill_public_funtion.skill_05_atk == true)
                            {
                                if (control.NPC_angle >= 0 && control.NPC_angle < 180)
                                {
                                    if (isFacingRight)
                                    {
                                        Flip_02();
                                    }
                                }
                                else
                                {
                                    if (!isFacingRight)
                                    {
                                        Flip_02();
                                    }
                                }
                                skill05A.SetTrigger("skill05_trigger");
                                skill05A.SetBool("skill05_bool", false);
                                skill05B.SetTrigger("skill05_B2");
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
                            if (control.NPC_angle >= 0 && control.NPC_angle < 180)
                            {
                                if (isFacingRight)
                                {
                                    Flip_02();
                                }
                            }
                            else
                            {
                                if (!isFacingRight)
                                {
                                    Flip_02();
                                }
                            }
                            skill_02.SetTrigger("skill_02");
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
                switch (icon.iconID)
                {
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
                                HP_control.TakeDamage(5, control.NPC04_DEF);
                                skill_25_step_time += 0.5f;
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
                    case 15:
                        if (other.gameObject.tag == "MC_bullet")
                        {
                            // skill_15_stop_time_trigger = true;
                            // skill_15_stop_time = 0;
                            control.stun = true;
                            skill22_animator.SetBool("skill_bullet15", true);
                            Invoke(nameof(Stun_end15), 2);
                        }
                        break;
                    case 31:
                        if (Skill_public_funtion.skill_31_dash && other.gameObject.tag == "Player")
                        {

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
            if (other.gameObject.tag == "skill_12_ward")
            {
                HP_control.TakeDamage(Skill_public_funtion.skill_12_atk, static_parameters.MC_DEF);
            }
        }
    }
    void Stun_end15()
    {
        skill22_animator.SetBool("skill_bullet15", false);
        control.stun = false;
    }

    bool isFacingRight = true;
    public GameObject Img_skill02;
    public GameObject Img_skill05;
    public void Flip_02()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale2 = Img_skill02.transform.localScale;
        theScale2.x *= -1;
        Img_skill02.transform.localScale = theScale2;

        Vector3 theScale5 = Img_skill05.transform.localScale;
        theScale5.x *= -1;
        Img_skill05.transform.localScale = theScale5;
    }
}
