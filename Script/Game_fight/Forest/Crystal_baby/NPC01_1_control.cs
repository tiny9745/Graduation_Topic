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
    public float NPC_HP; public float minus;
    float dist;
    bool hit_Ani = false;
    bool hit = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC01_1;
    public GameObject hitbox_Crystal_baby_small;
    public GameObject Drop;
    bool dead_open = true;
    bool MC_to_Att = true;
    public NPC_HP_01_1 nPC_hP;
    int NPC_angle = 0;
    private bool isFacingRight = true;
    public GameObject Img_npc;

    void Start()
    {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC01_1 = GameObject.Find("NPC01_1");
        if (NPC01_1 != null)
        {
            Renderer renderer = NPC01_1.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            };
        }
        hitbox_Crystal_baby_small.SetActive(false);

        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_01_1>();
            if (nPC_hP == null)
            {
                Debug.LogError("NPC_HP_01_1 component not found on " + gameObject.name);
            }
        }
    }

    void Update()
    {
        TargetObj = GameObject.Find("Player");
        npcNavi = GetComponent<NavMeshAgent>();
        if (NPC_HP <= 0)
        {
            PlayBombAnimation();
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
            PlayAtkAnimation();
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
            animator.Play("Crystal_baby_small_stand_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_stand_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_stand_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_stand_LF");
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
            animator.Play("Crystal_baby_small_walk_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_walk_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_walk_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_walk_LF");
        }
    }

    private void PlayAtkAnimation()
    {
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Att_RB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Att_RB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Att_RF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Att_RF");
        }
    }

    private void PlayBombAnimation()
    {
        npcNavi.speed = 0;
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            print("dying");
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            print("dying");
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            print("dying");
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            print("dying");
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LF");
        }
        Invoke("dead", 0.8f);
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
                if (nPC_hP == null)
                {
                    Debug.LogError("nPC_hP is not assigned.");
                    return;
                }

                print("NPC_HP:" + NPC_HP);
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC01_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.2f);
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
        hitbox_Crystal_baby_small.SetActive(true);
        Invoke("closeHitbox", 0.1f);
        hit = false;
    }
    void closeHitbox()
    {
        hitbox_Crystal_baby_small.SetActive(false);
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
