using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class NPC03_control : MonoBehaviour
{
    public NPC_interactive npc_interactive; public NPC_HP_03 nPC_hP;public NPC_effect_03 effect;
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj, Drop,NPC03, hitbox_Brick_Monster, Img_npc;
    public int DetectDistance = 22; int NPC_angle;
    public float NPC_HP_Max = 70, npcSpeed = 5.5f, NPC_HP, dist, NPC03_ATK = 25, NPC03_DEF = 5;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit_Ani, hit = false;bool dead_open, MC_to_Att,bomb_Berry = true;
    public bool stun; private bool isFacingRight = true; 
    private Vector3 lastPosition;
    private Quaternion initialRotation;

    public Material Deduct_Blood; private Material originalMaterial;
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private UnityEngine.Color originalColor;private bool isCoroutineRunning = false;
    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色

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

        if (TargetObj != null && npcNavi != null)
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
                change_color_red();
                effect.Skill();
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC03_DEF);
                MC_to_Att = false;
                effect.Skill();
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
                        nPC_hP.TakeDamage(4, NPC03_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(3, NPC03_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(5, NPC03_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(1, NPC03_DEF);
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
        Debug.Log("Dead03");
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
}
