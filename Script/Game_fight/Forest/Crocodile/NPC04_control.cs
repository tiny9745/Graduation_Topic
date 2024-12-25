using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC04_control : MonoBehaviour
{
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 15;
    public float NPC04_ATK = 15, NPC04_DEF = 15, NPC_HP_Max = 150, npcSpeed = 6f, NPC_HP;
    float dist;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit_Ani, hit = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC04, hitbox_Brick_Monster, Drop, Img_npc;
    bool dead_open, MC_to_Att = true;
    public NPC_HP_04 nPC_hP;
    int NPC_angle = 0; bool open_EnableHitbox = true;
    private bool isFacingRight = true;
    public NPC_interactive npc_interactive; bool bomb_Berry = true;
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private UnityEngine.Color originalColor;
    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色

        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC04 = GameObject.Find("NPC04");
        if (NPC04 != null)
        {
            Renderer renderer = NPC04.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
        }
        hitbox_Brick_Monster.SetActive(false);

        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_04>();
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
            animator.Play("crocodile_LB_stand");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LB_stand");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LF_stand");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LF_stand");
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
            animator.Play("crocodile_LB_walk");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LB_walk");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LF_walk");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LF_walk");
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
            animator.Play("crocodile_LB_atk");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LB_atk");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LF_atk");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("crocodile_LF_atk");
        }
    }

    public float GetNPC04_ATK()
    {
        return NPC04_ATK;
    }

    public bool GetNPC04_hit()
    {
        return hit;
    }


    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0 && Time.time >= nextDamageTime)
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
                change_color_red();
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC04_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.2f);
                nextDamageTime = Time.time + damageCooldown;
            }
            // Omit the middle
            if (other.gameObject.CompareTag("MC_bullet"))
            {
                change_color_red();
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(8, NPC04_DEF);
                        break;
                }
            }
        }
        if (NPC_HP > 0)
        {
            if (other.tag == "Thorns")
            {
                change_color_red();
                npc_interactive.NPC_Thorns(ref NPC_HP);

                nPC_hP.UpdateHealthBar();
            }
            if (other.tag == "Bomb_Fruit" && bomb_Berry)
            {
                change_color_red();
                bomb_Berry = false;
                npc_interactive.NPC_Bomb_Berry(ref NPC_HP);
                nPC_hP.UpdateHealthBar();
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
        Invoke("closeHitbox", 0.3f);
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
            Transform object_B = object_A.Find("crocodileLB_stb_0").transform;
            Transform object_C = object_B.Find("Quad");
            if (object_C != null)
            {
                GameObject childGameObject = object_C.gameObject;
                childGameObject.SetActive(false);
            }
            Img_npc.transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.speed = 0;
            static_parameters.Change_enemy--;
            if (static_parameters.Change_enemy == 0)
            {
                Vector3 currentPosition = transform.position;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            static_parameters.money += 4;
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }
    void dead_after()
    {
        Destroy(gameObject);
    }
    private void change_color_red()
    {
        if (spriteRenderer != null)
        {
            Debug.Log("change color");
            spriteRenderer.color = UnityEngine.Color.red; // 將顏色改為紅色
            StartCoroutine(ResetColorAfterDelay(0.2f));
        }
    }
    IEnumerator ResetColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SpriteRenderer spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor; // 還原顏色
        }
    }
}
