using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC05_control : MonoBehaviour
{
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj,Img_npc,bulletPrefab,NPC05, Drop;
    public int DetectDistance = 12;
    public float NPC05_ATK = 35, NPC05_DEF = 15,NPC_HP_Max = 160, npcSpeed = 0f, NPC_HP, fireRate = 1f,bulletSpeed = 20f;
    float dist, nextFireTime = 0f;
    bool hit_Ani, hit = false;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    bool dead_open,MC_to_Att = true;
    public NPC_HP_05 nPC_hP;
    int NPC_angle = 0;
    private bool isFacingRight = true;
    public Transform firePoint;

    void Start()
    {
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
    }

    void Update()
    {
        if (npcNavi == null || !npcNavi.isOnNavMesh) return;
        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
        }else {
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
            if (Time.time >= nextFireTime)
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

    public float GetNPC05_ATK()
    {
        return NPC05_ATK;
    }

    public bool GetNPC05_hit()
    {
        return hit;
    }


    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0)
        {
            
            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
                print("NPC_HP:" + NPC_HP);
                nPC_hP.TakeDamage(static_parameters.MC_ATK, NPC05_DEF);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.1f);
            }
        }
    }
    void Shoot()
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }

    void wait_MC_att()
    {
        MC_to_Att = true;
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
                Instantiate(Drop, currentPosition, Quaternion.identity);
            }
            Invoke("dead_after", 5);
            dead_open = false;
        }
    }

    void dead_after()
    {
        Destroy(gameObject);
    }
}
