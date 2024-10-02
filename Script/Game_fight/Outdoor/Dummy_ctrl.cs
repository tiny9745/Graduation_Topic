using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_ctrl : MonoBehaviour
{
    public GameObject TargetObj;
    public float Dummy_ATK = 15; public float Dummy_DEF = 15;
    public float NPC_HP_Max = 850;
    public float NPC_HP;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit = false;
    public GameObject hitbox_Dummy;
    bool MC_to_Att = true;
    public Dummy_HP nPC_hP;


    void Start()
    {
        NPC_HP = NPC_HP_Max;
        hitbox_Dummy.SetActive(false);

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<Dummy_HP>();
            if (nPC_hP == null)
            {
                Debug.LogError("Dummy_HP component not found on " + gameObject.name);
            }
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
            TargetObj = GameObject.Find("Player");
        }
        Skill_outsourcing_updata();
    }

    public float GetDummy_ATK()
    {
        return Dummy_ATK;
    }

    public bool GetDummy_hit()
    {
        return hit;
    }

    bool open_EnableHitbox = true;
    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0 && Time.time >= nextDamageTime)
        {
            if (NPC_HP > 0)
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
                    if (nPC_hP == null)
                    {
                        Debug.LogError("nPC_hP is not assigned.");
                        return;
                    }
                    nPC_hP.TakeDamage(static_parameters.MC_ATK, Dummy_DEF);
                    Skill_public_funtion.Normal_blood_deduction_NPC = true;
                    MC_to_Att = false;
                    Skill_outsourcing_DeBlood();//skill_add
                    Invoke("wait_MC_att", 0.2f);
                    nextDamageTime = Time.time + damageCooldown;
                }
            }
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

    bool Skill_public_funtion_1_close = false;//skill_add
    void Skill_outsourcing_updata()//skill_add
    {
        if (Skill_public_funtion.fight_instinct == true)
        {
            if (static_parameters.MC_HP / static_parameters.MC_HP_Max <= 0.6f)
            {
                if (Skill_public_funtion.feel_to_skill == 1 && Skill_public_funtion_1_close == true)
                {
                    Skill_public_funtion_1_close = false;
                    nPC_hP.TakeDamage(Dummy_ATK, Dummy_DEF);
                    Debug.Log("NPC_HP:" + NPC_HP);
                }
            }
        }
    }
    Byte play_piano_atk = 0;
    public GameObject bomb_piano;
    void Skill_outsourcing_DeBlood()//skill_add
    {
        if (Skill_public_funtion.play_piano == true)
        {
            switch (Skill_public_funtion.feel_to_skill)
            {
                case 0:
                    if (play_piano_atk <= 3)
                    {
                        play_piano_atk++;
                    }
                    else
                    {
                        NPC_HP -= 225;
                        Instantiate(bomb_piano, transform.position, Quaternion.identity);
                        play_piano_atk = 0;
                    }
                    break;
                case 1:
                    if (play_piano_atk <= 6)
                    {
                        play_piano_atk++;
                    }
                    else
                    {
                        play_piano_atk = 0;
                    }
                    break;
                case 2:
                    if (play_piano_atk <= 12)
                    {
                        play_piano_atk++;
                    }
                    else
                    {
                        play_piano_atk = 0;
                    }
                    break;
                case 3:
                    if (play_piano_atk <= 15)
                    {
                        play_piano_atk++;
                    }
                    else
                    {
                        play_piano_atk = 0;
                    }
                    break;
            }
        }
    }
}