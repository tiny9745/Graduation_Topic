using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC02_control : MonoBehaviour
{
    public NPC_HP_02 nPC_hP;public NPC_interactive npc_interactive; public NPC_effect_02 effect;
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj,NPC02,Drop,hitbox_Robot,Img_npc;
    public int DetectDistance = 20;int NPC_angle = 0;
    public float NPC02_ATK = 50, NPC02_DEF = 10,NPC_HP_Max = 80, npcSpeed = 5f, NPC_HP;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;float dist;
    bool hit_Ani,hit = false,bomb_Berry, dead_open, MC_to_Att= true;
    private bool isFacingRight = true,isCoroutineRunning = false; public bool stun = false;
    private Vector3 lastPosition;private Quaternion initialRotation;
    public Transform spriteTransform; private SpriteRenderer spriteRenderer; private UnityEngine.Color originalColor;
    void Start()
    {
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色

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
            TargetObj = GameObject.Find("Player");
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
            hitbox_Robot.SetActive(false);
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
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC02_DEF);
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
                        nPC_hP.TakeDamage(4, NPC02_DEF);
                        break;
                    case 2:
                        nPC_hP.TakeDamage(3, NPC02_DEF);
                        break;
                    case 3:
                        nPC_hP.TakeDamage(5, NPC02_DEF);
                        break;
                    case 4:
                        nPC_hP.TakeDamage(1, NPC02_DEF);
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
        Invoke("closeHitbox", 0.5f);//atk time
        hit = false;
    }
    void closeHitbox()
    {
        hitbox_Robot.SetActive(false);
        open_EnableHitbox = true;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = Img_npc.transform.localScale;
        theScale.x *= -1;
        Img_npc.transform.localScale = theScale;
    }
    
    void knock_back()
    {
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition + 0.5f * Vector3.back;
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
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            static_parameters.money += 5;
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }
    void dead_after()
    {
        Destroy(gameObject);
    }
}
