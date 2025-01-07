using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC05_control : MonoBehaviour
{
    public NPC_interactive npc_interactive; public NPC_HP_05 nPC_hP; public NPC_effect_05 effect;
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj, Img_npc, bulletPrefab, NPC05, Drop;
    public int DetectDistance = 12; int NPC_angle = 0;
    public float NPC05_ATK = 35, NPC05_DEF = 15, NPC_HP_Max = 160, npcSpeed = 0f, NPC_HP, fireRate = 1f, bulletSpeed = 20f;
    float dist, nextFireTime = 0f;
    bool hit_Ani= false, hit = false, dead_open= true, MC_to_Att= true, bomb_Berry = true;
    private bool isCoroutineRunning = false, isFacingRight = true; public bool stun = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;    
    public Transform firePoint;
    public AudioSource audioSource;public AudioClip[] meleeSwingSounds;// 0=NPC_ATK, 1=MC_ATK_To_NPC
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private UnityEngine.Color originalColor; 
    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色

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
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = static_parameters._SE_volue;
        npcNavi = GetComponent<NavMeshAgent>();
        if (npcNavi != null)
        {
            npcNavi.speed = npcSpeed;
        }

        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_05>();
        }
    }

    void Update()
    {
        if (npcNavi == null || !npcNavi.isOnNavMesh) return;
        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
        }
        else
        {
            dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        }

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
            if (Time.time >= nextFireTime && NPC_HP > 0)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }

        if (TargetObj != null && npcNavi != null)
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
                change_color_red();
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC05_DEF);
                MC_to_Att = false; effect.Skill();
                Invoke("wait_MC_att", 0.1f);
            }

            // Omit the middle
            if (other.gameObject.CompareTag("MC_bullet"))
            {
                change_color_red();
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(4, NPC05_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(3, NPC05_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(5, NPC05_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(1, NPC05_DEF);
                        break;
                }
            }

            if (other.gameObject.CompareTag("MC_bomb"))
            {
                effect.play_piano_effect();
            }
            // if (other.tag == "Thorns")
            // {
            //     change_color_red();
            //     npc_interactive.NPC_Thorns(ref NPC_HP);
            //     nPC_hP.UpdateHealthBar();
            // }
            if (other.tag == "Bomb_Fruit" && bomb_Berry)
            {
                change_color_red();
                bomb_Berry = false;
                npc_interactive.NPC_Bomb_Berry(ref NPC_HP);
                nPC_hP.UpdateHealthBar();
            }
        }else dead();
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
        if (meleeSwingSounds.Length > index && audioSource != null)
        {
            audioSource.PlayOneShot(meleeSwingSounds[index]);
        }
        else
        {
            Debug.LogWarning($"音效序號 {index} 超出範圍或 AudioSource 未指定");
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
                currentPosition.y = 2.5f;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            static_parameters.money += 6;
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }
    void dead_after()
    {
        Destroy(gameObject);
    }
}
