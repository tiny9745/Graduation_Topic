using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC01_control : MonoBehaviour
{
    public NPC_HP_01 nPC_hP; public NPC_interactive npc_interactive; public NPC01_effect effect;
    NavMeshAgent npcNavi;
    public Animator animator;
    public Animator animator_to_atk, bomb_animator;
    public SpriteRenderer weaponDUCK;
    public GameObject TargetObj, hitbox_Crystal_baby, Img_npc;
    private int DetectDistance = 70; public int NPC_angle = 0;
    public float NPC01_ATK = 6, NPC01_DEF = 5, NPC_HP_Max = 100, npcSpeed = 7f, NPC_HP;
    float dist;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit_Ani = false, hit = false, bomb_Berry = true, dead_open = true, MC_to_Att = true;
    public bool NPC01_hit = false, stun = false;
    private bool isFacingRight = true;
    int open_EnableHitbox = 0;
    private Vector3 lastPosition, presentPosition, lastEnteredDirection;// 記錄進入方向
    private Quaternion initialRotation;
    public GameObject NPC01, NPC01_1;
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private Color originalColor; private bool isCoroutineRunning = false;
    private float fadeDuration = 1.6f, fadeTimer = 0f;
    string dangerTag = "Thorns"; // 區域的 Tag
    float retreatDistance = 5f; // 移動距離
    private bool isInDangerZone = false; // 是否在危險區域內
    public AudioClip[] NPC01_audioclip;
    public AudioSource NPC01_audiosource;
    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色
        lastEnteredDirection = transform.position.normalized;
        presentPosition = Vector3.forward;

        static_parameters.Change_enemy++;

        initialRotation = transform.rotation;
        NPC01 = GameObject.Find("NPC01");
        if (NPC01 != null)
        {
            Renderer renderer = NPC01.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
        hitbox_Crystal_baby.SetActive(false);
        TargetObj = GameObject.Find("Player_S");

        npcNavi = GetComponent<NavMeshAgent>();
        npcNavi.speed = npcSpeed;

        if (static_parameters.stage_number == 1)
        {
            NPC_HP_Max *= 1;
            NPC01_ATK *= 1;
        }
        else if (static_parameters.stage_number == 2)
        {
            NPC_HP_Max *= 1.1f;
            NPC01_ATK *= 1;
        }
        else if (static_parameters.stage_number == 3)
        {
            NPC_HP_Max *= 1.3f;
            NPC01_ATK *= 1.1f;
        }
        else if (static_parameters.stage_number == 4)
        {
            NPC_HP_Max *= 1.5f;
            NPC01_ATK *= 1.2f;
        }
        NPC_HP = NPC_HP_Max;
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 取得 Layer 0 的動畫狀態
        if (stateInfo.IsName("Crystal_baby_Big_Att_LB") && stateInfo.normalizedTime >= 0.6f && open_EnableHitbox == 1)
        {
            open_EnableHitbox = 2;
            EnableHitbox();
        }
        else if (stateInfo.IsName("Crystal_baby_Big_Att_LF") && stateInfo.normalizedTime >= 0.6f && open_EnableHitbox == 1)
        {
            open_EnableHitbox = 2;
            EnableHitbox();
        }

        if (npcNavi == null || !npcNavi.isOnNavMesh) return;
        if (TargetObj != null)
        {
            dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        }
        if (NPC_HP <= 0)
        {
            NPC_HP = 0;
            hitbox_Crystal_baby.SetActive(false);
            Img_npc.transform.position += 1.5f * Time.deltaTime * Vector3.down;
            npcNavi.speed = 0;
            fade();
            PlayBombAnimation();
        }
        else if (!hit_Ani)
        {
            if (isInDangerZone || transform.position != lastPosition)
            {
                PlayWalkAnimation();
            }
            else
            {
                PlayStandAnimation();
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
        if (NPC_HP > 0)
        {
            if (other.gameObject.tag == "Player" && !stun && Time.time >= nextDamageTime)
            {
                if (open_EnableHitbox == 0)
                {
                    open_EnableHitbox = 1;
                    hit_Ani = true;
                }
            }

            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
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
                knock_back(TargetObj.transform);
                effect.piano_Skill();
                effect.fight_instinct_npc();
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC01_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.5f);
                nextDamageTime = Time.time + damageCooldown;
            }

            if (other.gameObject.CompareTag("MC_bomb"))
            {
                effect.play_piano_effect();
            }

            if (other.gameObject.CompareTag("MC_bullet"))
            {
                NPC01_audiosource.PlayOneShot(NPC01_audioclip[1]);
                change_color_red();
                bomb_animator.SetTrigger("BOOMFX_bomb");
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(static_parameters.MC_throw * Skill_public_funtion.skill_13_bullet_atk, NPC01_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(static_parameters.MC_throw * Skill_public_funtion.skill_13_bullet_atk, NPC01_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(static_parameters.MC_throw * Skill_public_funtion.skill_13_bullet_atk, NPC01_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(static_parameters.MC_throw * Skill_public_funtion.skill_13_bullet_atk, NPC01_DEF);
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

    void wait_MC_att()
    {
        MC_to_Att = true;
    }

    // Method to enable the hitbox
    void EnableHitbox()
    {
        hitbox_Crystal_baby.SetActive(true);
        hit = false;
        Invoke("closeHitbox", 1f);
    }
    void closeHitbox()
    {
        open_EnableHitbox = 0;
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = Img_npc.transform.localScale;
        theScale.x *= -1;
        Img_npc.transform.localScale = theScale;
    }

    public float GetNPC01_ATK()
    {
        return NPC01_ATK;
    }
    public bool GetNPC01_hit()
    {
        return hit;
    }
    public void change_color_red()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red; // 將顏色改為紅色
            if (!isCoroutineRunning)
            {
                StartCoroutine(ResetColorAfterDelay(0.75F));
            }
        }
    }
    void knock_back(Transform player)
    {
        float knockbackForce = static_parameters.knockback_force;
        Vector3 knockbackDirection = (transform.position - player.position).normalized;
        Rigidbody rb = GetComponent<Rigidbody>(); // Get Rigidbody
        if (rb != null) rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
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
    void dead()
    {
        if (dead_open)
        {
            Vector3 originalPosition = transform.position;
            Vector3 position1 = new Vector3(originalPosition.x - 5, originalPosition.y, originalPosition.z);
            Vector3 position2 = new Vector3(originalPosition.x + 5, originalPosition.y, originalPosition.z);

            Instantiate(NPC01_1, position1, Quaternion.identity);
            Instantiate(NPC01_1, position2, Quaternion.identity);
            NPC01_audiosource.PlayOneShot(NPC01_audioclip[0]);
            static_parameters.Change_enemy--;
            Des();
            dead_open = false;
        }
    }
    private void Des()
    {
        Destroy(gameObject);
    }
    public void Change()
    {
        switch (Change_mood.mood)
        {
            case 0:
                weaponDUCK.color = new Color(0.63f, 0.98f, 0.86f, 1);
                break;
            case 1:
                weaponDUCK.color = new Color(0.98f, 0.62f, 0.63f, 1);
                break;
            case 2:
                weaponDUCK.color = new Color(0.61f, 0.8f, 1, 1);
                break;
            case 3:
                weaponDUCK.color = new Color(0.84f, 0.62f, 0.88f, 1);
                break;
            case 4:
                weaponDUCK.color = new Color(1, 0.93f, 0.59f, 1);
                break;
            default:
                weaponDUCK.color = new Color(0.95f, 0.88f, 0.89f, 1);
                break;
        }
    }
}
