using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class gin_col : MonoBehaviour
{
    public NPC_interactive npc_interactive; public gin_HP nPC_hP;
    public NavMeshAgent npcNavi;
    public Animator animator, animator_to_atk;
    public SpriteRenderer weaponDUCK;
    public GameObject TargetObj, Drop, NPC_gin, hitbox_Brick_Monster, Img_npc;
    public int DetectDistance = 50; public int NPC_angle;
    public float NPC_HP_Max = 50, npcSpeed = 4f, NPC_HP, NPC_gin_ATK = 0, NPC_gin_DEF = 5;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f, dist;
    bool hit_Ani = false, hit = false, dead_open = true, MC_to_Att = true;
    int open_EnableHitbox = 0;
    public bool stun; private bool isFacingRight = true;
    private float fadeDuration = 5f, fadeTimer = 0f;
    private Vector3 lastPosition, presentPosition;
    private Quaternion initialRotation;
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private UnityEngine.Color originalColor; private bool isCoroutineRunning = false;
    public UI _UI;
    Ptest ptest;
    void Start()
    {
        ptest = FindObjectOfType<Ptest>();
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色
        presentPosition = Vector3.forward;
        _UI = GameObject.Find("UI").GetComponent<UI>();

        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC_gin = GameObject.Find("gingerbreadman");
        if (NPC_gin != null)
        {
            Renderer renderer = NPC_gin.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
        hitbox_Brick_Monster.SetActive(false);

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player_S");
        }
        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.teaching_stop >= 100 && static_parameters.isTeaching == false)
        {
            Destroy(gameObject);
        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 取得 Layer 0 的動畫狀態
        if (stateInfo.IsName("blocksLB_atk") && stateInfo.normalizedTime >= 0.6f && open_EnableHitbox == 1)
        {
            open_EnableHitbox = 2;
            EnableHitbox();
        }
        else if (stateInfo.IsName("blocksLF_atk") && stateInfo.normalizedTime >= 0.6f && open_EnableHitbox == 1)
        {
            open_EnableHitbox = 2;
            EnableHitbox();
        }
        if (npcNavi == null || !npcNavi.isOnNavMesh) return;
        if (TargetObj != null) dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        if (NPC_HP <= 0)
        {
            NPC_HP = 0;
            hitbox_Brick_Monster.SetActive(false);
            Img_npc.transform.position += 1.5f * Time.deltaTime * Vector3.down;
            npcNavi.speed = 0;
            fade();
            dead();
        }
        else if (hit_Ani)
        {
            PlayAttackAnimation();
        }
        else
        {
            PlayWalkAnimation();
        }

        if (dist >= 15)
        {
            hit_Ani = false;
        }
        lastPosition = transform.position;
        transform.rotation = initialRotation;

        if (TargetObj != null && npcNavi != null && !stun)
        {
            npcNavi.destination = TargetObj.transform.position;

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
    private void PlayWalkAnimation()
    {
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RB_walk");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RB_walk");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RF_walk");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RF_walk");
        }
    }

    private void PlayAttackAnimation()
    {
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RB_atk");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RB_atk");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RF_atk");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("gin_RF_atk");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0 )
        {
            if (other.gameObject.tag == "Player" && Time.time >= nextDamageTime && !stun)
            {
                if (open_EnableHitbox == 0)
                {
                    open_EnableHitbox = 1;
                    hit_Ani = true;
                }
            }

            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
                // Change();
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
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC_gin_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.5f);
                nextDamageTime = Time.time + damageCooldown;
            }
            if (other.gameObject.CompareTag("MC_bullet"))
            {
                change_color_red();
                switch (static_parameters._ItemID)
                {
                    case 0:
                        nPC_hP.TakeDamage(9 * Skill_public_funtion.skill_13_bullet_atk, NPC_gin_DEF);
                        break;
                    case 1:
                        nPC_hP.TakeDamage(4 * Skill_public_funtion.skill_13_bullet_atk, NPC_gin_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(3 * Skill_public_funtion.skill_13_bullet_atk, NPC_gin_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(5 * Skill_public_funtion.skill_13_bullet_atk, NPC_gin_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(1 * Skill_public_funtion.skill_13_bullet_atk, NPC_gin_DEF);
                        break;
                }
            }
        }
    }

    void EnableHitbox()
    {
        hitbox_Brick_Monster.SetActive(true);
        hit = false;
        Invoke("closeHitbox", 2f);
    }
    void closeHitbox()
    {
        open_EnableHitbox = 0;
    }

    public void Flip()
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
            animator.speed = 0;
            Transform object_A = transform;
            Transform object_B = object_A.Find("gingerbreadman_pic").transform;
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
                currentPosition.y = 4.4f;
                ptest.teaching_end_Pieces();
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }

    void dead_after()
    {
        if (static_parameters.Change_enemy == 0 && static_parameters.teaching_stop == 5)
        {
            static_parameters.teaching_stop = 6;
        }
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
    void fade()
    {
        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
        }
    }
    IEnumerator ResetColorAfterDelay(float delay)
    {
        isCoroutineRunning = true; // 設置為 true，表示協程正在運行
        yield return new WaitForSeconds(delay);  // 等待指定的延遲時間
        spriteRenderer.color = UnityEngine.Color.white; // 重置顏色為白色
        isCoroutineRunning = false; // 協程結束後將旗標設回 false
    }
    public float Getgin_ATK()
    {
        return NPC_gin_ATK;
    }

    public bool Getgin_hit()
    {
        return hit;
    }

    void wait_MC_att()
    {
        MC_to_Att = true;
    }
}
