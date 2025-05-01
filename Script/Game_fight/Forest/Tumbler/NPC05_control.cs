using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC05_control : MonoBehaviour
{
    public NPC_interactive npc_interactive; public NPC_HP_05 nPC_hP; public NPC_effect_05 effect; public UI _UI;
    NavMeshAgent npcNavi;
    public Animator animator, animator_to_atk, bomb_animator;
    public SpriteRenderer weaponDUCK;
    public GameObject TargetObj, Img_npc, bulletPrefab, NPC05, Drop;
    private int DetectDistance = 30; public int NPC_angle = 0;
    public float NPC05_ATK = 35, NPC05_DEF = 17.5f, NPC_HP_Max = 60, npcSpeed = 0f, NPC_HP, fireRate = 0.33f, bulletSpeed = 10f;
    float dist, nextFireTime = 0f;
    bool hit_Ani = false, hit = false, dead_open = true, MC_to_Att = true, bomb_Berry = true;
    private bool isCoroutineRunning = false, isFacingRight = true; public bool stun = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public Transform firePoint;
    public AudioClip[] meleeSwingSounds;// 0=NPC_ATK, 1=MC_ATK_To_NPC
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private Color originalColor;
    private float fadeDuration = 5f, fadeTimer = 0f;
    public Animator money_animator;
    public AudioClip[] NPC05_audioclip;
    public AudioSource NPC05_audiosource;
    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色
        _UI = GameObject.Find("UI").GetComponent<UI>();

        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC05 = GameObject.Find("NPC05");
        if (NPC05 != null)
        {
            Renderer renderer = NPC05.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_05>();
        }

        switch (static_parameters.stage_number)
        {
            case 1:
                NPC_HP_Max *= 1;
                NPC05_ATK *= 1;
                break;
            case 2:
                NPC_HP_Max *= 1.1f;
                NPC05_ATK *= 1;
                break;
            case 3:
                NPC_HP_Max *= 1.3f;
                NPC05_ATK *= 1.1f;
                break;
            case 4:
                NPC_HP_Max *= 1.5f;
                NPC05_ATK *= 1.2f;
                break;
        }
        NPC_HP = NPC_HP_Max;
    }

    void Update()
    {
        if (npcNavi == null || !npcNavi.isOnNavMesh) return;
        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player_S");
        }
        else
        {
            dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        }

        if (NPC_HP <= 0)
        {
            NPC_HP = 0;
            gameObject.tag = "Untagged";
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

        if (TargetObj != null && Vector3.Distance(transform.position, TargetObj.transform.position) <= DetectDistance)
        {
            // Shoot at the player
            if (Time.time >= nextFireTime && NPC_HP > 0 && !stun)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }

        if (TargetObj != null && npcNavi != null && !stun)
        {

            npcNavi.destination = transform.position;
            Vector3 direction = TargetObj.transform.position - transform.position;
            Vector3 directionOnXZ = new Vector3(direction.x, 0, direction.z);
            Vector3 forwardOnXZ = new Vector3(transform.forward.x, 0, transform.forward.z);

            NPC_angle = Mathf.RoundToInt(Vector3.SignedAngle(forwardOnXZ, directionOnXZ, Vector3.up));
            if (directionOnXZ != Vector3.zero)
            {
                // Rotate the firePoint to face the direction
                firePoint.rotation = Quaternion.LookRotation(directionOnXZ);
            }
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
            animator.Play("Tumbler_stand_LB");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Tumbler_stand_LB");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Tumbler_stand_LF");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Tumbler_stand_LF");
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
            animator.Play("Tumbler_Atk_LB");
        }
        else if (NPC_angle >= 270 && NPC_angle < 360)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Tumbler_Atk_LB");
        }
        else if (NPC_angle >= 180 && NPC_angle < 270)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            animator.Play("Tumbler_Atk_LF");
        }
        else if (NPC_angle >= 90 && NPC_angle < 180)
        {
            if (isFacingRight)
            {
                Flip();
            }
            animator.Play("Tumbler_Atk_LF");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        effect.skill_TriggerEnter(other);
    }

    void Shoot()
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            PlaySoundAtIndex(0);
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0)
        {
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
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC05_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.5f);
            }

            // Omit the middle
            if (other.gameObject.CompareTag("MC_bullet"))
            {
                NPC05_audiosource.PlayOneShot(NPC05_audioclip[1]);
                bomb_animator.SetTrigger("BOOMFX_bomb");
                change_color_red();
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(static_parameters.MC_throw, NPC05_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(static_parameters.MC_throw, NPC05_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(static_parameters.MC_throw, NPC05_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(static_parameters.MC_throw, NPC05_DEF);
                        break;
                }
            }

            if (other.gameObject.CompareTag("MC_bomb"))
            {
                effect.play_piano_effect();
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
    public float GetNPC05_ATK()
    {
        return NPC05_ATK;
    }

    public bool GetNPC05_hit()
    {
        return hit;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = Img_npc.transform.localScale;
        theScale.x *= -1;
        Img_npc.transform.localScale = theScale;
    }


    private void PlaySoundAtIndex(int index)
    {
        if (meleeSwingSounds.Length > index && NPC05_audiosource != null)
        {
            NPC05_audiosource.PlayOneShot(meleeSwingSounds[index]);
        }
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
            Transform object_B = object_A.Find("tumblerLF_stb_0").transform;
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
                currentPosition.y = 4.4f;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            money_animator.transform.SetParent(null, true);
            money_animator.SetTrigger("money02");
            NPC05_audiosource.PlayOneShot(NPC05_audioclip[0]);
            static_parameters.money += 5;
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
