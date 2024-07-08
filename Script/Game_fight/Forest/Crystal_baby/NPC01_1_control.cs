using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC01_1_control : MonoBehaviour
{
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 20; public float NPC01_ATK = 4;public float NPC01_DEF = 2;
    public float NPC_HP_Max = 40; public float npcSpeed = 4f;
    public float NPC_HP;
    private Quaternion initialRotation;
    public GameObject NPC01_1;
    bool dead_open = true; bool hit_Ani = false; bool hit = false;
    float coordinate_X; float coordinate_Z;
    private Vector3 lastPosition;
    public GameObject hitbox_Crystal_baby_small;
    public GameObject Drop;
    public NPC_HP_01_1 nPC_hP;
    bool MC_to_Att = true;
    private bool isFacingRight = true;
    public GameObject Img_npc;

    void Start()
    {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        lastPosition = transform.position;
        NPC01_1 = GameObject.Find("NPC01_1");
        if (NPC01_1 != null)
        {
            Renderer renderer = NPC01_1.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        TargetObj = GameObject.Find("Player");
        npcNavi = GetComponent<NavMeshAgent>();
        if (NPC_HP <= 0)
        {
            npcNavi.speed = 0;
            if (coordinate_X >= 0 && coordinate_Z > 0)
            {
                animator.Play("Crystal_baby_small_Bomb_RB");
            }
            if (coordinate_X < 0 && coordinate_Z >= 0)
            {
                animator.Play("Crystal_baby_small_Bomb_LB");
            }
            if (coordinate_X <= 0 && coordinate_Z < 0)
            {
                animator.Play("Crystal_baby_small_Bomb_LF");
            }
            if (coordinate_X > 0 && coordinate_Z <= 0)
            {
                animator.Play("Crystal_baby_small_Bomb_RF");
            }
            Invoke("dead", 0.8f);
        }
        else if (hit_Ani == false)
        {
            npcNavi.speed = npcSpeed;
            if (transform.position == lastPosition)
            {
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    if (!isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_stand_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    if (isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_stand_RB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    if (isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_stand_RF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    if (!isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_stand_RF");
                }
            }
            else
            {
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    if (!isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_walk_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    if (isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_walk_RB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    if (isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_walk_RF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    if (!isFacingRight)
                    {
                        Flip();
                    }
                    animator.Play("Crystal_baby_small_walk_RF");
                }
            }
        }
        else
        {
            npcNavi.speed = npcSpeed * 6;
            if (coordinate_X >= 0 && coordinate_Z > 0)
            {
                if (!isFacingRight)
                {
                    Flip();
                }
                animator.Play("Crystal_baby_small_Att_RB");
            }
            if (coordinate_X < 0 && coordinate_Z >= 0)
            {
                if (isFacingRight)
                {
                    Flip();
                }
                animator.Play("Crystal_baby_small_Att_RB");
            }
            if (coordinate_X <= 0 && coordinate_Z < 0)
            {
                if (isFacingRight)
                {
                    Flip();
                }
                animator.Play("Crystal_baby_small_Att_RF");
            }
            if (coordinate_X > 0 && coordinate_Z <= 0)
            {
                if (!isFacingRight)
                {
                    Flip();
                }
                animator.Play("Crystal_baby_small_Att_RF");
            }
        }
        transform.rotation = initialRotation;
        if (TargetObj == null)
        {
            if (npcNavi != null)
            {
                npcNavi.speed = npcSpeed;
            }
        }
        else
        {
            float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
            if (dist < DetectDistance && NPC_HP > 0)
            {
                npcNavi.destination = TargetObj.transform.position;
            }
            else // Track your location 
            {
                npcNavi.destination = transform.position;
            }
        }
        transform.rotation = initialRotation;
        lastPosition = transform.position;
        coordinate_X = TargetObj.transform.position.x - transform.position.x;
        coordinate_Z = TargetObj.transform.position.z - transform.position.z;
    }
    public float GetNPC01_ATK()
    {
        return NPC01_ATK;
    }
    public bool GetNPC01_hit()
    {
        return hit;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hit_Ani = true;
            EnableHitbox();
        }
        if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
        {
            NPC_HP -= static_parameters.MC_ATK;
            nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC01_DEF);
            MC_to_Att = false;
            Invoke("wait_MC_att", 0.2f);
        }
    }

    void wait_MC_att()
    {
        MC_to_Att = true;
    }

    // Method to enable the hitbox
    void EnableHitbox()
    {
        hitbox_Crystal_baby_small.SetActive(true);
        hit = false;
        Invoke("EndAttANimation", 1f);
    }
    void EndAttANimation()
    {
        hit_Ani = false;
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
            static_parameters.Change_enemy--;
            if (static_parameters.Change_enemy == 0)
            {
                Vector3 currentPosition = transform.position;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            Destroy(gameObject);
            dead_open = false;
        }
    }
}
