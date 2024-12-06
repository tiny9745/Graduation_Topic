using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class NPC03_control : MonoBehaviour
{
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj, Drop;
    public int DetectDistance = 22;
    public float NPC_HP_Max = 70, npcSpeed = 4f, NPC_HP, dist, NPC03_ATK = 25, NPC03_DEF = 5;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit_Ani, stun, hit = false; float NPC_back = 10;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC03, hitbox_Brick_Monster, Img_npc, bomb_piano, bomb_point;
    bool dead_open = true, MC_to_Att = true;
    public NPC_HP_03 nPC_hP;
    int NPC_angle, play_piano_atk = 0;
    private bool isFacingRight = true;
    public NPC_interactive npc_interactive;
    bool bomb_Berry = true;

    void Start()
    {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC03 = GameObject.Find("NPC03");
        if (NPC03 != null)
        {
            Renderer renderer = NPC03.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
        hitbox_Brick_Monster.SetActive(false);

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
        }
        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_03>();
        }
    }

    void Update()
    {
        if (npcNavi == null || !npcNavi.isOnNavMesh) return;
        if (TargetObj != null) dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        if (NPC_HP <= 0)
        {
            NPC_HP = 0;
            hitbox_Brick_Monster.SetActive(false);
            Img_npc.transform.position += 1.5f * Time.deltaTime * Vector3.down;
            npcNavi.speed = 0;
            dead();
        }
        else if (!hit_Ani)
        {
            if (transform.position == lastPosition)
            {
                PlayStandAnimation();
            }
            else
            {
                PlayWalkAnimation();
            }
        }
        else
        {
            PlayAttackAnimation();
        }

        if (dist >= DetectDistance * 3 / 5)
        {
            hit_Ani = false;
        }
        lastPosition = transform.position;
        transform.rotation = initialRotation;



        if (TargetObj != null && npcNavi != null)
        {
            if (dist < DetectDistance && NPC_HP > 0 && !stun)
            {
                npcNavi.destination = TargetObj.transform.position;
            }
            else
            {
                npcNavi.destination = transform.position;
            }

            Vector3 direction = TargetObj.transform.position - transform.position;
            Vector3 directionOnXZ = new Vector3(direction.x, 0, direction.z);
            Vector3 forwardOnXZ = new Vector3(transform.forward.x, 0, transform.forward.z);

            NPC_angle = Mathf.RoundToInt(Vector3.SignedAngle(forwardOnXZ, directionOnXZ, Vector3.up));

            if (NPC_angle < 0)
            {
                NPC_angle += 360;
            }
        }
    }

    private void PlayStandAnimation()
    {
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLB_stand");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLB_stand");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLF_stand");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLF_stand");
        }
    }

    private void PlayWalkAnimation()
    {
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLB_walk");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLB_walk");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLF_walk");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLF_walk");
        }
    }

    private void PlayAttackAnimation()
    {
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLB_atk");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLB_atk");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLF_atk");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("blocksLF_atk");
        }
    }


    bool open_EnableHitbox = true;
    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0 && Time.time >= nextDamageTime && !stun)
        {
            if (other.gameObject.tag == "Player")
            {
                if (open_EnableHitbox)
                {
                    hit_Ani = true;
                    Invoke("EnableHitbox", 1.1f);
                    open_EnableHitbox = false;
                }
            }
            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
                Skill();
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC03_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.2f);
                nextDamageTime = Time.time + damageCooldown;
            }
            if (other.gameObject.CompareTag("MC_bomb"))
            {
                switch (Skill_public_funtion.feel_to_skill)
                {
                    case 0://happy
                        Debug.Log("play_piano_atk:" + play_piano_atk);
                        play_piano_atk++;
                        Debug.Log("play_piano_atk:" + play_piano_atk);
                        break;
                    case 1://anger
                        NPC_HP -= 225; Debug.Log("boom");
                        break;
                    case 2://sad
                        if (NPC_HP < NPC_back) NPC_HP = 0;
                        else
                        {
                            Vector3 currentPosition = transform.position;
                            transform.position = currentPosition - NPC_back * Vector3.back;
                        }
                        play_piano_atk = 0; Debug.Log("knockback");
                        break;
                    case 3://wow
                        Debug.Log("stun");
                        stun = true;
                        Invoke("Stun_end", 3);
                        break;
                }
            }
            if (other.gameObject.CompareTag("MC_bullet"))
            {
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(4, NPC03_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(3, NPC03_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(5, NPC03_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(1, NPC03_DEF);
                        break;
                }
            }
        }
        if (other.tag == "Thorns")
        {
            npc_interactive.NPC_Thorns(ref NPC_HP);
            
            nPC_hP.UpdateHealthBar();
        }
        if (other.tag == "Bomb_Fruit" && bomb_Berry)
        {
            bomb_Berry = false;
            npc_interactive.NPC_Bomb_Berry(ref NPC_HP);
            nPC_hP.UpdateHealthBar();
        }
    }
    public float GetNPC03_ATK()
    {
        return NPC03_ATK;
    }

    public bool GetNPC03_hit()
    {
        return hit;
    }

    void wait_MC_att()
    {
        MC_to_Att = true;
    }

    void EnableHitbox()
    {
        hitbox_Brick_Monster.SetActive(true);
        Invoke("closeHitbox", 0.5f);//atk time
        hit = false;
    }
    void closeHitbox()
    {
        hitbox_Brick_Monster.SetActive(false);
        open_EnableHitbox = true;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = Img_npc.transform.localScale;
        theScale.x *= -1;
        Img_npc.transform.localScale = theScale;
    }
    void dead()
    {
        if (dead_open)
        {
            Transform object_A = this.transform;
            Transform object_B = object_A.Find("blocksLF_stb_0").transform;
            Transform object_C = object_B.Find("Quad");
            if (object_C != null)
            {
                GameObject childGameObject = object_C.gameObject;
                childGameObject.SetActive(false);
            }
            Img_npc.transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.speed = 0;
            hitbox_Brick_Monster.SetActive(false);
            static_parameters.Change_enemy--;
            if (static_parameters.Change_enemy == 0)
            {
                Vector3 currentPosition = transform.position;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            static_parameters.money += 7;
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }
    void knock_back()
    {
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition + 5f * Vector3.back;
    }
    void Skill()//skill_add
    {
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
    void Stun_end()
    {
        stun = false;
    }
    void dead_after()
    {
        Debug.Log("Dead03");
        Destroy(gameObject);
    }
}
