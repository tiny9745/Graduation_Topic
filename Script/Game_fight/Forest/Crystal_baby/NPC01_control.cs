using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC01_control : MonoBehaviour
{
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public bool NPC01_hit = false;
    public int DetectDistance = 18, Pcounter = 0;
    public float NPC01_ATK = 8, NPC01_DEF = 5, NPC_HP_Max = 100, npcSpeed = 3f, NPC_HP;
    float dist;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit_Ani = false, hit = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC01; public GameObject NPC01_1;
    public GameObject hitbox_Crystal_baby;
    public GameObject Drop;
    bool dead_open = true, MC_to_Att = true;
    public NPC_HP_01 nPC_hP;
    int NPC_angle = 0;
    private bool isFacingRight = true;
    public GameObject Img_npc;

    void Start()
    {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC01 = GameObject.Find("NPC01");
        if (NPC01 != null)
        {
            Renderer renderer = NPC01.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            };
        }
        hitbox_Crystal_baby.SetActive(false);

        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_01>();
            if (nPC_hP == null)
            {
                Debug.LogError("NPC_HP_01 component not found on " + gameObject.name);
            }
        }
    }

    void Update()
    {
        if (npcNavi == null || !npcNavi.isOnNavMesh) return;
        if (TargetObj != null)
        {
            dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        }
        if (NPC_HP <= 0)
        {
            PlayBombAnimation();
        }
        else if (!hit_Ani)
        {
            //npcNavi.speed = npcSpeed;
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

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
        }
        /*else
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
        }*/

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
            animator.Play("Crystal_baby_Big_stand_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_stand_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_stand_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_stand_LF");
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
            animator.Play("Crystal_baby_Big_walk_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_walk_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_walk_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_walk_LF");
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
            animator.Play("Crystal_baby_Big_Att_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_Att_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_Att_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_Att_LF");
        }
    }

    private void PlayBombAnimation()
    {
        npcNavi.speed = 0;
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_bomb_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_bomb_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_bomb_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_Big_bomb_LF");
        }
        Invoke("dead", 1.6f);
    }
    public float GetNPC01_ATK()
    {
        return NPC01_ATK;
    }
    public bool GetNPC01_hit()
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
                        hit_Ani = true;
                        Invoke("EnableHitbox", 1.1f);
                        open_EnableHitbox = false;
                    }
                }
                if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
                {
                    NPC01_hit = true;
                    print("NPC01_hit");
                    if (nPC_hP == null)
                    {
                        Debug.LogError("nPC_hP is not assigned.");
                        return;
                    }
                    nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC01_DEF);
                    MC_to_Att = false;
                    Invoke("wait_MC_att", 0.2f);
                    nextDamageTime = Time.time + damageCooldown;
                }
                else
                {
                    NPC01_hit = false;
                    print("NPC01_not_hit");
                }
            }
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
        Invoke("closeHitbox", 0.5f);
        hit = false;
    }
    void closeHitbox()
    {
        hitbox_Crystal_baby.SetActive(false);
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
