using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class NPC03_control : MonoBehaviour
{
    public NPC_interactive npc_interactive; public NPC_HP_03 nPC_hP; public NPC_effect_03 effect;
    public NavMeshAgent npcNavi;
    public Animator animator, animator_to_atk;
    public SpriteRenderer weaponDUCK;
    public GameObject TargetObj, Drop, NPC03, hitbox_Brick_Monster, Img_npc;
    public int DetectDistance = 33; int NPC_angle;
    public float NPC_HP_Max = 70, npcSpeed = 5.5f, NPC_HP, NPC03_ATK = 10, NPC03_DEF = 5;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f, dist;
    bool hit_Ani = false, hit = false, dead_open = true, MC_to_Att = true, bomb_Berry = true;
    public bool stun; private bool isFacingRight = true;
    private Vector3 lastPosition, presentPosition;
    private Quaternion initialRotation;

    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private UnityEngine.Color originalColor; private bool isCoroutineRunning = false;

    string dangerTag = "Thorns"; // 區域的 Tag
    float retreatDistance = 5f; // 移動距離
    private bool isInDangerZone = false; // 是否在危險區域內
    private Vector3 lastEnteredDirection; // 記錄進入方向


    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色
        lastEnteredDirection = transform.position.normalized;
        presentPosition = Vector3.forward;

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
        nPC_hP = GetComponent<NPC_HP_03>();
        effect = GetComponent<NPC_effect_03>();
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

        if (TargetObj != null && npcNavi != null && !isInDangerZone)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(dangerTag))
        {
            lastEnteredDirection = (transform.position - other.transform.position).normalized;
            isInDangerZone = true;

            // 計算新的目標位置
            Vector3 retreatDirection = lastEnteredDirection; // 原路折返
            // 計算目標位置
            Vector3 retreatTarget = transform.position + retreatDirection;
            if (npcNavi != null)
            {
                npcNavi.SetDestination(retreatTarget);
            }
            Invoke("wait_safe_to_walk", 1.5f);
        }
        effect.skill_TriggerEnter(other);
    }

    private void wait_safe_to_walk()
    {
        isInDangerZone = false;
    }
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
                Debug.Log("MC_Att: " + static_parameters.Ani_state);
                Change();
                switch (static_parameters.Ani_state)
                {
                    case 2:
                        animator_to_atk.SetTrigger("atk_to_MC01");
                        break;
                    case 3:
                        animator_to_atk.SetTrigger("atk_to_MC02");
                        break;
                    case 4:
                        animator_to_atk.SetTrigger("atk_to_MC02");
                        break;
                }
                change_color_red();
                effect.piano_Skill();
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC03_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.2f);
                nextDamageTime = Time.time + damageCooldown;
            }

            if (other.gameObject.CompareTag("MC_bomb"))
            {
                effect.play_piano_effect();
            }

            if (other.gameObject.CompareTag("MC_bullet"))
            {
                change_color_red();
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(4 * Skill_public_funtion.skill_13_bullet_atk, NPC03_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(3 * Skill_public_funtion.skill_13_bullet_atk, NPC03_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(5 * Skill_public_funtion.skill_13_bullet_atk, NPC03_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(1 * Skill_public_funtion.skill_13_bullet_atk, NPC03_DEF);
                        break;
                }
            }
        }

        if (NPC_HP > 0)
        {
            // 如果進入危險區域且標記匹配
            if (other.CompareTag(dangerTag))
            {
                if (!isInDangerZone)
                {
                    isInDangerZone = true;
                }

                // 計算新的目標位置
                Vector3 retreatTarget = TargetObj.transform.position + retreatDistance * lastEnteredDirection;

                // 設置 NavMeshAgent 的目標位置
                if (npcNavi != null)
                {
                    npcNavi.SetDestination(retreatTarget);
                }
            }

            if (other.tag == "Thorns_atk")
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

    private void OnTriggerExit(Collider other)
    {
        // 當離開危險區域時，重置狀態
        if (other.CompareTag(dangerTag))
        {
            isInDangerZone = false;
            if (npcNavi != null)
            {
                npcNavi.ResetPath(); // 停止導航，清除路徑
            }
        }
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
                currentPosition.y = 2.5f;
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
    void dead_after()
    {
        Destroy(gameObject);
    }
    public void change_color_red()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = UnityEngine.Color.red; // 將顏色改為紅色
            if (!isCoroutineRunning)  // 檢查協程是否正在運行
            {
                StartCoroutine(ResetColorAfterDelay(0.75F)); // 啟動協程
            }
        }
    }
    IEnumerator ResetColorAfterDelay(float delay)
    {
        isCoroutineRunning = true; // 設置為 true，表示協程正在運行
        yield return new WaitForSeconds(delay);  // 等待指定的延遲時間
        spriteRenderer.color = UnityEngine.Color.white; // 重置顏色為白色
        isCoroutineRunning = false; // 協程結束後將旗標設回 false
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
    public void Change()
    {
        switch (Change_mood.mood)
        {
            case 0:
                weaponDUCK.color = new UnityEngine.Color(0.63f, 0.98f, 0.86f, 1);
                break;
            case 1:
                weaponDUCK.color = new UnityEngine.Color(0.98f, 0.62f, 0.63f, 1);
                break;
            case 2:
                weaponDUCK.color = new UnityEngine.Color(0.61f, 0.8f, 1, 1);
                break;
            case 3:
                //Mood.sprite = ;
                break;
            case 4:
                weaponDUCK.color = new UnityEngine.Color(1, 0.93f, 0.59f, 1);
                break;
            default:
                weaponDUCK.color = new UnityEngine.Color(0.95f, 0.88f, 0.89f, 1);
                break;
        }
    }
}
