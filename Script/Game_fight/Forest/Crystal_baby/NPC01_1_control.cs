using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC01_1_control : MonoBehaviour
{
    public NPC_HP_01_1 nPC_hP;public NPC_interactive npc_interactive; public NPC01_1_effect effect;
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 25;
    public float NPC01_ATK = 4, NPC01_DEF = 2, NPC_HP_Max = 40, npcSpeed = 4f, NPC_HP, minus;
    float dist;
    private float damageCooldown = 1.0f; // Time in seconds between damage instances
    private float nextDamageTime = 0.0f;
    bool hit_Ani = false, hit = false, dead_open= true , MC_to_Att= true, bomb_Berry = true;
    private bool isFacingRight = true; public bool stun=false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC01_1;
    public GameObject hitbox_Crystal_baby_small, Drop;
    int NPC_angle = 0;
    
    public GameObject Img_npc;
    SpriteRenderer spriterenderer;
    
    void Start()
    {
        static_parameters.Change_enemy++;
        NPC_HP = NPC_HP_Max;
        initialRotation = transform.rotation;
        NPC01_1 = GameObject.Find("NPC01_1");
        spriterenderer = Img_npc.GetComponent<SpriteRenderer>();
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
            TargetObj = GameObject.Find("Player");
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
    }

    void Update()
    {
        TargetObj = GameObject.Find("Player");
        npcNavi = GetComponent<NavMeshAgent>();
        if (NPC_HP <= 0)
        {
            NPC_HP = 0;
            hitbox_Crystal_baby_small.SetActive(false);
            Img_npc.transform.position += 1.5f * Time.deltaTime * Vector3.down;
            npcNavi.speed = 0;
            dead();
        }
        if (NPC_HP <= 0)
        {
            PlayBombAnimation();
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
            PlayAtkAnimation();
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
                npc_interactive.NPC_Thorns(ref NPC_HP);
                nPC_hP.UpdateHealthBar();
            }
            if (other.tag == "Bomb_Fruit" && bomb_Berry)
            {
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
                currentPosition.y = 2.5f;
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            static_parameters.money += 3;
            Destroy(gameObject);
            dead_open = false;
        }
    }
}
