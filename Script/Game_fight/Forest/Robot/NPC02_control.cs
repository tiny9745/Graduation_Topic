using System.Drawing;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class NPC02_control : MonoBehaviour
{
    //test;
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 20; public float NPC02_ATK = 20;public float NPC02_DEF = 10;
    public float NPC_HP_Max = 80; public float npcSpeed = 5f;
    public float NPC_HP;
    float dist;
    bool hit_Ani = false;
    bool hit = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC02;
    public GameObject hitbox_Robot;
    public GameObject Drop;
    bool dead_open = true;
    bool MC_to_Att = true;
    public NPC_HP_02 nPC_hP;
    int NPC_angle = 0;
    private bool isFacingRight = true;
    public GameObject Img_npc;

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

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_02>();
            if (nPC_hP == null)
            {
                Debug.LogError("NPC_HP_02 component not found on " + gameObject.name);
            }
        }
    }

    void Update()
    {
        if (npcNavi == null) return;
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

            Vector3 direction = TargetObj.transform.position - transform.position;
            Vector3 directionOnXZ = new Vector3(direction.x, 0, direction.z);

            // Calculate the forward vector (on the XZ plane)
            Vector3 forwardOnXZ = new Vector3(transform.forward.x, 0, transform.forward.z);

            // Calculate the angle between two vectors
            NPC_angle = Mathf.RoundToInt(Vector3.SignedAngle(forwardOnXZ, directionOnXZ, Vector3.up));

            // relative angle
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
            animator.Play("Robot_stand_LB");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_stand_LB");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_stand_LF");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_stand_LF");
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
            animator.Play("Robot_walk_LB");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_walk_LB");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_walk_LF");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_walk_LF");
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
            animator.Play("Robot_Att_LB");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_Att_LB");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if(!isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_Att_LF");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Robot_Att_LF");
        }
    }

    public float GetNPC02_ATK()
    {
        return NPC02_ATK;
    }

    public bool GetNPC02_hit()
    {
        return hit;
    }

    bool open_EnableHitbox = true;
    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0)
        {
            if (other.gameObject.tag == "Player" && open_EnableHitbox)
            {
                hit_Ani = true;
                Invoke("EnableHitbox", 1.15f);
            }
            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
                knock_back();
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC02_DEF);
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
        hitbox_Robot.SetActive(true);
        Invoke("closeHitbox", 0.2f);
        hit = false;
    }
    void closeHitbox()
    {
        hitbox_Robot.SetActive(false);
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
            Img_npc.transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.speed = 0;
            static_parameters.Change_enemy--;
            if (static_parameters.Change_enemy == 0)
            {
                Vector3 currentPosition = transform.position;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }
    void knock_back()
    {
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition + 0.5f * Vector3.back;
    }
    void dead_after()
    {
        Destroy(gameObject);
    }
}
