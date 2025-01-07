using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class NPC01_control : MonoBehaviour
{
    public NPC_HP_01 nPC_hP; public NPC_interactive npc_interactive;  public NPC01_effect effect;
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj,hitbox_Crystal_baby,Drop,Img_npc;
    public int DetectDistance = 27, Pcounter = 0;int NPC_angle = 0;
    public float NPC01_ATK = 8, NPC01_DEF = 5, NPC_HP_Max = 100, npcSpeed = 5f, NPC_HP;
    float dist;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit_Ani= false, hit = false, bomb_Berry= true,dead_open= true, MC_to_Att= true;
    public bool NPC01_hit = false,stun = false;
    private bool isFacingRight = true;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC01, NPC01_1;
    
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private UnityEngine.Color originalColor; private bool isCoroutineRunning = false;
    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC01 = GameObject.Find("NPC01");
        if (NPC01 != null)
        {
            Renderer renderer = NPC01.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            };
        }
        hitbox_Crystal_baby.SetActive(false);
        TargetObj = GameObject.Find("Player");
        
        npcNavi = GetComponent<NavMeshAgent>();
        npcNavi.speed = npcSpeed;     
        nPC_hP = GetComponent<NPC_HP_01>();
        
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
            hitbox_Crystal_baby.SetActive(false);
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
    

    bool open_EnableHitbox = true;
    private void OnTriggerStay(Collider other)
    { 
        if (NPC_HP > 0 && Time.time >= nextDamageTime && !stun)
        {
            // UnityEngine.Debug.Log("NPC01_control:"+other.gameObject.tag);
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
                change_color_red();
                switch (static_parameters._ItemID)
                {
                    case 1:
                        nPC_hP.TakeDamage(4, NPC01_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(3, NPC01_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(5, NPC01_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(1, NPC01_DEF);
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
            // if (other.tag == "Bomb_Fruit" && bomb_Berry)
            // {
            //     change_color_red();
            //     bomb_Berry = false;
            //     npc_interactive.NPC_Bomb_Berry(ref NPC_HP);
            //     nPC_hP.UpdateHealthBar();
            // }
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
        Invoke("closeHitbox", 0.5f);
        hit = false;
    }
    void closeHitbox()
    {
        hitbox_Crystal_baby.SetActive(false);
        open_EnableHitbox = true;
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
            Vector3 originalPosition = transform.position;
            Vector3 position1 = new Vector3(originalPosition.x - 5, originalPosition.y, originalPosition.z);
            Vector3 position2 = new Vector3(originalPosition.x + 5, originalPosition.y, originalPosition.z);

            Instantiate(NPC01_1, position1, Quaternion.identity);
            Instantiate(NPC01_1, position2, Quaternion.identity);
            static_parameters.Change_enemy--;
            Des();
            dead_open = false;
        }
    }
    private void Des()
    {
        Destroy(gameObject);
    }
}
