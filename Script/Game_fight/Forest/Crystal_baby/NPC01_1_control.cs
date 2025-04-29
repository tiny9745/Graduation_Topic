using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC01_1_control : MonoBehaviour
{
    public NPC_HP_01_1 nPC_hP; public NPC_interactive npc_interactive; public NPC01_1_effect effect;
    NavMeshAgent npcNavi;
    public Animator animator, animator_to_atk, bomb_animator;
    public SpriteRenderer weaponDUCK;
    public GameObject TargetObj, NPC01_1, Img_npc, hitbox_Crystal_baby_small, Drop;
    private int DetectDistance = 65;
    public float NPC01_ATK = 4, NPC01_DEF = 2, NPC_HP_Max = 50, npcSpeed = 9f, NPC_HP, minus;
    float dist;
    private float nextDamageTime = 0.0f, damageCooldown = 1.0f; // Time in seconds between damage instances
    bool hit_Ani = false, hit = false, dead_open = true, MC_to_Att = true, bomb_Berry = true;
    private bool isFacingRight = true; public bool stun = false;
    private Vector3 lastPosition, presentPosition;
    private Quaternion initialRotation;
    public int NPC_angle = 0;
    private float fadeDuration = 0.8f, fadeTimer = 0f;
    SpriteRenderer spriterenderer;
    public UI _UI;
    public Animator money_animator;
    public AudioClip[] NPC01_1_audioclip;
    public AudioSource NPC01_1_audiosource;

    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private Color originalColor; private bool isCoroutineRunning = false;


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
        NPC01_1 = GameObject.Find("NPC01_1");
        spriterenderer = Img_npc.GetComponent<SpriteRenderer>();
        _UI = GameObject.Find("UI").GetComponent<UI>();
        if (NPC01_1 != null)
        {
            Renderer renderer = NPC01_1.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
        hitbox_Crystal_baby_small.SetActive(false);

        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player_S");
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_01_1>();
        }
        if (spriterenderer != null)
        {
            int color_change = Random.Range(0, 5);
            switch (color_change)
            {
                case 0:
                    spriterenderer.color = new Color(155 / 255f, 255 / 255f, 155 / 255f, 1f);
                    break;
                case 1:
                    spriterenderer.color = new Color(0f, 190f / 255f, 255f / 255f, 1f);
                    break;
                case 2:
                    spriterenderer.color = new Color(230 / 255f, 230 / 255f, 0f, 1f);
                    break;
                case 3:
                    spriterenderer.color = new Color(230 / 255f, 125 / 255f, 230 / 255f, 1f);
                    break;
                case 4:
                    spriterenderer.color = new Color(140 / 255f, 110 / 255f, 210 / 255f, 1f);
                    break;
                case 5:
                    spriterenderer.color = new Color(255 / 255f, 105 / 255f, 70 / 255f, 1f);
                    break;
            }
        }

        if (static_parameters.stage_number == 1)
        {
            NPC_HP_Max *= 1;
            NPC_HP = NPC_HP_Max;
            NPC01_ATK *= 1;
        }
        else if (static_parameters.stage_number == 2)
        {
            NPC_HP_Max *= 1.1f;
            NPC_HP = NPC_HP_Max;
            NPC01_ATK *= 1;
        }
        else if (static_parameters.stage_number == 3)
        {
            NPC_HP_Max *= 1.3f;
            NPC_HP = NPC_HP_Max;
            NPC01_ATK *= 1.1f;
        }
        else if (static_parameters.stage_number == 4)
        {
            NPC_HP_Max *= 1.5f;
            NPC_HP = NPC_HP_Max;
            NPC01_ATK *= 1.2f;
        }
    }

    void Update()
    {
        TargetObj = GameObject.Find("Player_S");
        npcNavi = GetComponent<NavMeshAgent>();
        if (NPC_HP <= 0)
        {
            NPC_HP = 0;
            gameObject.tag = "Untagged";
            fade();
            hitbox_Crystal_baby_small.SetActive(false);

            Img_npc.transform.position += 1.5f * Time.deltaTime * Vector3.down;
            npcNavi.speed = 0;
            PlayBombAnimation();
        }
        else if (!hit_Ani)
        {
            if (isInDangerZone)
            {
                PlayWalkAnimation();
            }
            else if (transform.position == lastPosition)
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
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Stand_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Stand_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Stand_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Stand_LF");
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
            animator.Play("Crystal_baby_small_Walk_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Walk_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Walk_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Walk_LF");
        }
    }

    private void PlayAtkAnimation()
    {
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Atk_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Atk_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Atk_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Atk_LF");
        }
    }

    private void PlayBombAnimation()
    {
        npcNavi.speed = 0;
        if (NPC_angle >= 0 && NPC_angle < 90)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LB");
        }
        if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LB");
        }
        if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LF");
        }
        if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Crystal_baby_small_Bomb_LF");
        }
        Invoke("dead", 0.8f);
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
        if (NPC_HP > 0 )
        {
            if (other.gameObject.tag == "Player" && !stun && Time.time >= nextDamageTime )
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
                effect.fight_instinct_npc();
                knock_back(TargetObj.transform);
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC01_DEF);
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
                NPC01_1_audiosource.PlayOneShot(NPC01_1_audioclip[1]);
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
    void knock_back(Transform player)
    {
        float knockbackForce = static_parameters.knockback_force;
        Vector3 knockbackDirection = (transform.position - player.position).normalized;
        Rigidbody rb = GetComponent<Rigidbody>(); // Get Rigidbody
        if (rb != null) rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
    }
    IEnumerator ResetColorAfterDelay(float delay)
    {
        isCoroutineRunning = true; // 設置為 true，表示協程正在運行
        yield return new WaitForSeconds(delay);  // 等待指定的延遲時間
        spriteRenderer.color = UnityEngine.Color.white; // 重置顏色為白色
        isCoroutineRunning = false; // 協程結束後將旗標設回 false
    }
    public float GetNPC01_ATK()
    {
        return NPC01_ATK;
    }
    public bool GetNPC01_hit()
    {
        return hit;
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
                currentPosition.y = 4.4f;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            money_animator.transform.SetParent(null, true);
            money_animator.SetTrigger("money01");
            NPC01_1_audiosource.PlayOneShot(NPC01_1_audioclip[0]);
            static_parameters.money += 3;
            _UI.Loadmoney();
            Destroy(gameObject);
            dead_open = false;
        }
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
                weaponDUCK.color = new Color(0.84f, 0.62f, 0.88f, 1);
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
