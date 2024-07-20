using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC03_control : MonoBehaviour
{
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 22; public float NPC03_ATK = 25; public float NPC03_DEF = 5;
    public float NPC_HP_Max = 70; public float npcSpeed = 4f;
    public float NPC_HP;
    float dist;
    bool hit_Ani = false;
    bool hit = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC03;
    public GameObject hitbox_Brick_Monster;
    public GameObject Drop;
    bool dead_open = true;
    bool MC_to_Att = true;
    public NPC_HP_03 nPC_hP;
    int NPC_angle = 0;
    private bool isFacingRight = true;
    public GameObject Img_npc;

    void Start()
    {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        print("NPC_HP:" + NPC_HP);
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

        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        // Check if nPC_hP is assigned
        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_03>();
            if (nPC_hP == null)
            {
                Debug.LogError("NPC_HP_03 component not found on " + gameObject.name);
            }
        }
    }

    void Update()
    {
        if (npcNavi == null) return;
        if (TargetObj != null)
        {
            dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        }
            if (NPC_HP <= 0)
        {
            NPC_HP = 0;
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
        if (dist >= DetectDistance*3/5)
        {
            hit_Ani = false;
        }
        lastPosition = transform.position;
        transform.rotation = initialRotation;

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
        }

        if (TargetObj != null && npcNavi != null)
        {
            if (dist < DetectDistance && NPC_HP > 0)
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

    public float GetNPC03_ATK()
    {
        return NPC03_ATK;
    }

    public bool GetNPC03_hit()
    {
        return hit;
    }

    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0) {
            if (other.gameObject.tag == "Player")
            {
                hit_Ani = true;
                Invoke("EnableHitbox", 1.2f);
                Invoke("closeHitbox", 1.7f);
            }
            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
                if (static_parameters.MC_ATK == null)
                {
                    Debug.LogError("MC_ATK is not assigned in static_parameters.");
                    return;
                }

                if (nPC_hP == null)
                {
                    Debug.LogError("nPC_hP is not assigned.");
                    return;
                }

                knock_back();
                print("NPC_HP:" + NPC_HP);
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC03_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.2f);
            }
        }
    }

    void wait_MC_att()
    {
        MC_to_Att = true;
    }

    void EnableHitbox()
    {
        hitbox_Brick_Monster.SetActive(true);
        hit = false;
    }
    void closeHitbox()
    {
        hitbox_Brick_Monster.SetActive(false);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = Img_npc.transform.localScale;
        theScale.x *= -1;
        Img_npc.transform.localScale = theScale;
    }
    void knock_back()
    {
        print("knock_back");
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition + 5f * Vector3.back;
    }

    void dead()
    {
        if (dead_open)
        {
            Img_npc.transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.speed = 0;
            hitbox_Brick_Monster.SetActive(false);
            static_parameters.Change_enemy--;
            print(static_parameters.Change_enemy);
            if (static_parameters.Change_enemy == 0)
            {
                Vector3 currentPosition = transform.position;
                print("currentPosition:"+currentPosition);
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }

    void dead_after()
    {
        Destroy(gameObject);
    }
}
