using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class NPC02_control : MonoBehaviour
{
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 20; public int NPC02_ATK = 20;
    public float NPC_HP_Max = 80; public float npcSpeed = 5f;
    public float NPC_HP;
    bool hit_Ani = false;
    bool hit = false;
    float coordinate_X;
    float coordinate_Z;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC02;
    public GameObject hitbox_Robot;
    public GameObject Drop;
    bool dead_open = true;
    bool MC_to_Att = true;
    public NPC_HP_02 nPC_hP;

    void Start()
    {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC02 = GameObject.Find("NPC02");
        if (NPC02 != null)
        {
            Renderer renderer = NPC02.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
        hitbox_Robot.SetActive(false);

        // 初始化 npcNavi
        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }
    }

    void Update()
    {
        if (npcNavi == null) return;

        if (NPC_HP <= 0)
        {
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

        lastPosition = transform.position;
        transform.rotation = initialRotation;

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
        }

        if (TargetObj != null && npcNavi != null)
        {
            float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
            if (dist < DetectDistance && NPC_HP > 0)
            {
                npcNavi.destination = TargetObj.transform.position;
            }
            else
            {
                npcNavi.destination = transform.position;
            }

            coordinate_X = TargetObj.transform.position.x - transform.position.x;
            coordinate_Z = TargetObj.transform.position.z - transform.position.z;
        }
    }

    private void PlayStandAnimation()
    {
        if (coordinate_X >= 0 && coordinate_Z > 0)
        {
            animator.Play("Robot_stand_RB");
        }
        else if (coordinate_X < 0 && coordinate_Z >= 0)
        {
            animator.Play("Robot_stand_LB");
        }
        else if (coordinate_X <= 0 && coordinate_Z < 0)
        {
            animator.Play("Robot_stand_LF");
        }
        else if (coordinate_X > 0 && coordinate_Z <= 0)
        {
            animator.Play("Robot_stand_RF");
        }
    }

    private void PlayWalkAnimation()
    {
        if (coordinate_X >= 0 && coordinate_Z > 0)
        {
            animator.Play("Robot_walk_RB");
        }
        else if (coordinate_X < 0 && coordinate_Z >= 0)
        {
            animator.Play("Robot_walk_LB");
        }
        else if (coordinate_X <= 0 && coordinate_Z < 0)
        {
            animator.Play("Robot_walk_LF");
        }
        else if (coordinate_X > 0 && coordinate_Z <= 0)
        {
            animator.Play("Robot_walk_RF");
        }
    }

    private void PlayAttackAnimation()
    {
        if (coordinate_X >= 0 && coordinate_Z > 0)
        {
            animator.Play("Robot_Att_RB");
        }
        else if (coordinate_X < 0 && coordinate_Z >= 0)
        {
            animator.Play("Robot_Att_LB");
        }
        else if (coordinate_X <= 0 && coordinate_Z < 0)
        {
            animator.Play("Robot_Att_LF");
        }
        else if (coordinate_X > 0 && coordinate_Z <= 0)
        {
            animator.Play("Robot_Att_RF");
        }
    }

    public int GetNPC02_ATK()
    {
        return NPC02_ATK;
    }

    public bool GetNPC02_hit()
    {
        return hit;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hit_Ani = true;
            Invoke("EnableHitbox", 1.15f);
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

    void EnableHitbox()
    {
        hitbox_Robot.SetActive(true);
        hit = false;
        Invoke("EndAttANimation", 0.85f);
    }

    void EndAttANimation()
    {
        hit_Ani = false;
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
            dead_open = false;
            npcNavi = null;
            Destroy(gameObject);
        }
    }
}
