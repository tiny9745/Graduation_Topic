using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC02_control : MonoBehaviour
{
    public NPC_HP_02 nPC_hP; public NPC_interactive npc_interactive; public NPC_effect_02 effect; public UI _UI;
    NavMeshAgent npcNavi;
    public Animator animator, animator_to_atk;
    public SpriteRenderer weaponDUCK;
    public GameObject TargetObj, NPC02, Drop, hitbox_Robot, Img_npc;
    private int DetectDistance = 75; public int NPC_angle = 0;
    public float NPC02_ATK = 15, NPC02_DEF = 12, NPC_HP_Max = 150, npcSpeed = 5f, NPC_HP;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f; float dist;
    bool hit_Ani = false, hit = false, bomb_Berry = true, dead_open = true, MC_to_Att = true;
    private bool isFacingRight = true, isCoroutineRunning = false; public bool stun = false;
    int open_EnableHitbox = 0;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private Color originalColor;
    private float fadeDuration = 5f, fadeTimer = 0f;
    public Animator money_animator;
    public AudioSource die_NPC;
    public AudioSource MC_throw_NPC;

    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色
        _UI = GameObject.Find("UI").GetComponent<UI>();

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

        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player_S");
        }
        // 初始化 npcNavi
        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_02>();
        }

        if (static_parameters.stage_number == 1)
        {
            NPC_HP_Max *= 1;
            NPC_HP = NPC_HP_Max;
            NPC02_ATK *= 1;
        }
        else if (static_parameters.stage_number == 2)
        {
            NPC_HP_Max *= 1.1f;
            NPC_HP = NPC_HP_Max;
            NPC02_ATK *= 1;
        }
        else if (static_parameters.stage_number == 3)
        {
            NPC_HP_Max *= 1.3f;
            NPC_HP = NPC_HP_Max;
            NPC02_ATK *= 1.1f;
        }
        else if (static_parameters.stage_number == 4)
        {
            NPC_HP_Max *= 1.5f;
            NPC_HP = NPC_HP_Max;
            NPC02_ATK *= 1.2f;
        }
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 取得 Layer 0 的動畫狀態
        if (stateInfo.IsName("Robot_Att_LF") && stateInfo.normalizedTime >= 0.5f && open_EnableHitbox == 1)
        {
            open_EnableHitbox = 2;
            EnableHitbox();
        }
        else if (stateInfo.IsName("Robot_Att_LB") && stateInfo.normalizedTime >= 0.5f && open_EnableHitbox == 1)
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
            die_NPC.PlayOneShot(die_NPC.clip, static_parameters._SE_volue* 0.5f);
            NPC_HP = 0;
            hitbox_Robot.SetActive(false);
            Img_npc.transform.position += 1.5f * Time.deltaTime * Vector3.down;
            npcNavi.speed = 0;
            fade();
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
            if (!isFacingRight)
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
    private void OnTriggerEnter(Collider other)
    {
        effect.skill_TriggerEnter(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0 && Time.time >= nextDamageTime && !stun)
        {
            if (other.gameObject.tag == "Player")
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
                effect.piano_Skill();
                effect.fight_instinct_npc();
                knock_back(TargetObj.transform);
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC02_DEF);
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
                MC_throw_NPC.PlayOneShot(MC_throw_NPC.clip);
                change_color_red();
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(20 * Skill_public_funtion.skill_13_bullet_atk, NPC02_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(20 * Skill_public_funtion.skill_13_bullet_atk, NPC02_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(20 * Skill_public_funtion.skill_13_bullet_atk, NPC02_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(20 * Skill_public_funtion.skill_13_bullet_atk, NPC02_DEF);
                        break;
                }
            }
        }

        if (NPC_HP > 0)
        {
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

    public float GetNPC02_ATK()
    {
        return NPC02_ATK;
    }
    public bool GetNPC02_hit()
    {
        return hit;
    }
    void wait_MC_att()
    {
        MC_to_Att = true;
    }

    void EnableHitbox()
    {
        hitbox_Robot.SetActive(true);
        hit = false;
        Invoke("closeHitbox", 2f);//atk time
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

    void knock_back(Transform player)
    {
        float knockbackForce = static_parameters.knockback_force;
        Vector3 knockbackDirection = (transform.position - player.position).normalized;
        Rigidbody rb = GetComponent<Rigidbody>(); // Get Rigidbody
        if (rb != null) rb.AddForce(knockbackDirection * knockbackForce * 0.5f, ForceMode.Impulse);
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
    void dead()
    {
        if (dead_open)
        {
            Transform object_A = this.transform;
            Transform object_B = object_A.Find("robotLF_stb_0").transform;
            Transform object_C = object_B.Find("Quad");
            if (object_C != null)
            {
                GameObject childGameObject = object_C.gameObject;
                childGameObject.SetActive(false);
            }
            Img_npc.transform.rotation = Quaternion.Euler(0, 0, -45);
            animator.speed = 0;
            hitbox_Robot.SetActive(false);
            static_parameters.Change_enemy--;
            if (static_parameters.Change_enemy == 0)
            {
                Vector3 currentPosition = transform.position;
                currentPosition.y = 2.5f;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            money_animator.transform.SetParent(null, true);
            money_animator.SetTrigger("money01");
            static_parameters.money += 12;
            _UI.Loadmoney();
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }
    void dead_after()
    {
        Destroy(gameObject);
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
