using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_ctrl : MonoBehaviour
{
    public GameObject TargetObj;
    public float Dummy_ATK = 15, Dummy_DEF = 15;
    public float NPC_HP_Max = 850, NPC_HP;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit, stun = false; Byte play_piano_atk = 0;
    public GameObject hitbox_Dummy, bomb_piano;
    //float NPC_back = 10;
    bool MC_to_Att, open_EnableHitbox = true, Skill_public_funtion_1_close = false;//skill_add
    public Dummy_HP nPC_hP;

    void Start()
    {
        if (static_parameters.teaching_stop < 100 || static_parameters.isTeaching == true)
        {
            Destroy(gameObject);
        }
        NPC_HP = NPC_HP_Max;
        hitbox_Dummy.SetActive(false);

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<Dummy_HP>();
        }
    }

    void Update()
    {
        if (NPC_HP <= 0)
        {
            NPC_HP = NPC_HP_Max;
            hitbox_Dummy.SetActive(false);
        }

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player_S");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0 && Time.time >= nextDamageTime && !stun)
        {
            if (other.gameObject.tag == "Player")
            {
                if (open_EnableHitbox)
                {
                    Invoke("EnableHitbox", 0.1f);
                    open_EnableHitbox = false;
                }
            }
            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
                nPC_hP.TakeDamage(static_parameters.MC_ATK, Dummy_DEF);
                MC_to_Att = false;
                Skill();//skill_add
                Invoke("wait_MC_att", 0.2f);
                nextDamageTime = Time.time + damageCooldown;
            }
            // if (other.gameObject.CompareTag("MC_bomb"))
            // {
            //     switch (Skill_public_funtion.feel_to_skill)
            //     {
            //         case 0:
            //             NPC_HP -= 225; Debug.Log("boom");
            //             break;
            //         case 1:
            //             Debug.Log("stun");
            //             stun = true;
            //             Invoke("Stun_end", 1);
            //             break;
            //         case 2:
            //             Debug.Log("play_piano_atk:" + play_piano_atk);
            //             play_piano_atk++;
            //             Debug.Log("play_piano_atk:" + play_piano_atk);
            //             break;
            //         case 3:
            //             if (NPC_HP < NPC_back) NPC_HP = 0;
            //             else
            //             {
            //                 Vector3 currentPosition = transform.position;
            //                 transform.position = currentPosition - NPC_back * Vector3.back;
            //             }
            //             play_piano_atk = 0; Debug.Log("knockback");
            //             break;
            //     }
            // }
        }
    }

    void wait_MC_att()
    {
        MC_to_Att = true;
    }
    void EnableHitbox()
    {
        hitbox_Dummy.SetActive(true);
        Skill_public_funtion_1_close = true;//skill_add
        hit = false;
        Invoke("closeHitbox", 0.3f);
    }
    void closeHitbox()
    {
        hitbox_Dummy.SetActive(false);
        open_EnableHitbox = true;
    }
    //Knockback value of skill effect
    void Skill()//skill_add
    {
        if (Skill_public_funtion.play_piano)
        {
            if (play_piano_atk <= 3) play_piano_atk++;
            else
            {
                Instantiate(bomb_piano, transform.position, Quaternion.identity);
                play_piano_atk = 0;
            }
        }
    }

    void Stun_end()
    {
        stun = false;
    }
    public float GetDummy_ATK()
    {
        return Dummy_ATK;
    }

    public bool GetDummy_hit()
    {
        return hit;
    }
}