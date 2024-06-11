using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC01_control : MonoBehaviour
{
    NavMeshAgent npcNavi;public TakeHit NPChit;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 18; public int NPC01_ATK = 8;
    public float NPC_HP_Max = 100; public float npcSpeed = 3f;
    public float NPC_HP;
    private Quaternion initialRotation;
    //private Camera mainCamera;
    public GameObject NPC01; public GameObject NPC01_1;
    bool dead_open = true;bool hit_Ani = false;bool hit = false;
    float coordinate_X; float coordinate_Z;
    private Vector3 lastPosition;
    public GameObject hitbox_Crystal_baby;
    public NPC_HP_01 nPC_hP;
    bool MC_to_Att = true;

    void Start() {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        lastPosition = transform.position;
        NPC01 = GameObject.Find("NPC01");
        if (NPC01 != null)
        {
            Renderer renderer = NPC01.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            };
        }
    }

    // Update is called once per frame
    void Update() {
        TargetObj = GameObject.Find("Player");
        npcNavi = GetComponent<NavMeshAgent>();
        if (NPC_HP <= 0)
        {
            npcNavi.speed = 0;
            if (coordinate_X >= 0 && coordinate_Z > 0)
            {
                animator.Play("Crystal_baby_Big_bomb_RB");
            }
            if (coordinate_X < 0 && coordinate_Z >= 0)
            {
                animator.Play("Crystal_baby_Big_bomb_LB");
            }
            if (coordinate_X <= 0 && coordinate_Z < 0)
            {
                animator.Play("Crystal_baby_Big_bomb_LF");
            }
            if (coordinate_X > 0 && coordinate_Z <= 0)
            {
                animator.Play("Crystal_baby_Big_bomb_RF");
            }
            Invoke("dead", 1.6f);
        }
        else if (hit_Ani == false)
        {
            npcNavi.speed = npcSpeed;
            if (transform.position == lastPosition)
            {
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    animator.Play("Crystal_baby_Big_stand_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    animator.Play("Crystal_baby_Big_stand_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    animator.Play("Crystal_baby_Big_stand_LF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    animator.Play("Crystal_baby_Big_stand_RF");
                }
            }
            else
            {
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    animator.Play("Crystal_baby_Big_walk_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    animator.Play("Crystal_baby_Big_walk_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    animator.Play("Crystal_baby_Big_walk_LF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    animator.Play("Crystal_baby_Big_walk_RF");
                }
            }
        }
        else
        {
            npcNavi.speed = npcSpeed * 5;
            if (coordinate_X >= 0 && coordinate_Z > 0)
            {
                animator.Play("Crystal_baby_Big_Att_RB");
            }
            if (coordinate_X < 0 && coordinate_Z >= 0)
            {
                animator.Play("Crystal_baby_Big_Att_LB");
            }
            if (coordinate_X <= 0 && coordinate_Z < 0)
            {
                animator.Play("Crystal_baby_Big_Att_LF");
            }
            if (coordinate_X > 0 && coordinate_Z <= 0)
            {
                animator.Play("Crystal_baby_Big_Att_RF");
            }
        }
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
    public int GetNPC01_ATK()
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
            nPC_hP.TakeDamage(static_parameters.MC_ATK);
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
        hitbox_Crystal_baby.SetActive(true);
        hit = false;
        Invoke("EndAttANimation", 1f);
    }
    void EndAttANimation()
    {
        hit_Ani = false;
    }

    void dead()
    {
        if (dead_open)
        {
            Vector3 originalPosition = transform.position;
            Vector3 position1 = new Vector3(originalPosition.x - 5, originalPosition.y, originalPosition.z);
            Vector3 position2 = new Vector3(originalPosition.x + 5, originalPosition.y, originalPosition.z);

            Instantiate(NPC01_1, position1, Quaternion.identity);
            Instantiate(NPC01_1, position2, Quaternion.identity);
            static_parameters.Change_enemy--;
            Des();
            dead_open = false;
        }
    }
    private void Des()
    {
        Destroy(gameObject);
    }
}
