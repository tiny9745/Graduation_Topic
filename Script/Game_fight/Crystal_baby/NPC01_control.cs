using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC01_control : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    public int DetectDistance = 18; public int NPC01_ATK = 8;
    public float NPC_HP = 100; public float npcSpeed = 3f;
    private Quaternion initialRotation;
    //private Camera mainCamera;
    public GameObject NPC01;

    bool hit_Ani = false;
    bool hit = false;
    float coordinate_X;
    float coordinate_Z;
    private Vector3 lastPosition;
    public GameObject hitbox_Crystal_baby;

    void Start(){
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
        //mainCamera = FindObjectOfType<Camera>();//Get camera
    }

    // Update is called once per frame
    void Update(){
        TargetObj = GameObject.Find("Player");
        npcNavi = GetComponent<NavMeshAgent>();
        if (NPC_HP <= 0)
        {
            npcNavi.speed = 0;
            if (coordinate_X >= 0 && coordinate_Z > 0)
            {
                animator.Play("Crystal_baby_Big_bomb_RB");
            }
            if (coordinate_X < 0 && coordinate_Z >= 0)
            {
                animator.Play("Crystal_baby_Big_bomb_LB");
            }
            if (coordinate_X <= 0 && coordinate_Z < 0)
            {
                animator.Play("Crystal_baby_Big_bomb_LF");
            }
            if (coordinate_X > 0 && coordinate_Z <= 0)
            {
                animator.Play("Crystal_baby_Big_bomb_RF");
            }
            Invoke("dead", 2f);
        }
        else if (hit_Ani == false)
        {
            npcNavi.speed = npcSpeed;
            if (transform.position != lastPosition)
            {
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    animator.Play("Crystal_baby_Big_stand_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    animator.Play("Crystal_baby_Big_stand_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    animator.Play("Crystal_baby_Big_stand_LF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    animator.Play("Crystal_baby_Big_stand_RF");
                }
            }
            else
            {
                npcNavi.speed = npcSpeed * 5;
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    animator.Play("Crystal_baby_Big_walk_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    animator.Play("Crystal_baby_Big_walk_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    animator.Play("Crystal_baby_Big_walk_LF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    animator.Play("Crystal_baby_Big_walk_RF");
                }
            }
        }
        else
        {
            if (coordinate_X >= 0 && coordinate_Z > 0)
            {
                animator.Play("Crystal_baby_Big_Att_RB");
            }
            if (coordinate_X < 0 && coordinate_Z >= 0)
            {
                animator.Play("Crystal_baby_Big_Att_LB");
            }
            if (coordinate_X <= 0 && coordinate_Z < 0)
            {
                animator.Play("Crystal_baby_Big_Att_LF");
            }
            if (coordinate_X > 0 && coordinate_Z <= 0)
            {
                animator.Play("Crystal_baby_Big_Att_RF");
            }
        }
        transform.rotation = initialRotation;
        if (TargetObj == null)
        {
            //TargetObj = GameObject.Find("Player");
            //npcNavi = GetComponent<NavMeshAgent>();
            // Set the speed after each acquisition of the NavMeshAgent component
            if (npcNavi != null)
            {
                npcNavi.speed = npcSpeed;
            }
        }
        else
        {
            float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
            if (dist < DetectDistance && NPC_HP > 0)
            {
                npcNavi.destination = TargetObj.transform.position;
            }
            else // Track your location 
            {
                npcNavi.destination = transform.position;
            }
            //transform.LookAt(mainCamera.transform);
        }
        coordinate_X = TargetObj.transform.position.x - transform.position.x;
        coordinate_Z = TargetObj.transform.position.z - transform.position.z;
    }
    public int GetNPC01_ATK()
    {
        return NPC01_ATK;
    }
    public bool GetNPC01_hit()
    {
        return hit;
    }
    private void OnCollisionEnter(Collision Hit){
        //NPC attack determination
        if (Hit.gameObject.CompareTag("Player"))
        {
            static_parameters.MC_HP -= NPC01_ATK;
            print("Player_HP=" + static_parameters.MC_HP);
        }
        else
        {
            Debug.LogWarning("找不到對應組件");
        }
        //NPC is determined to be attacked
        /*if (NPC_HP <= 0)
        {
            Destroy(gameObject);
            static_parameters.Change_enemy--;
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hit_Ani = true;
            EnableHitbox();
        }
    }

    // Method to enable the hitbox
    void EnableHitbox()
    {
        hitbox_Crystal_baby.SetActive(true);
        hit = false;
        Invoke("EndAttANimation", 1f);
    }
    void EndAttANimation()
    {
        hit_Ani = false;
    }

    bool dead_open = true;
    void dead()
    {
        if (dead_open)
        {
            dead_open = false;
            static_parameters.Change_enemy++; //It is recommended to calculate the newly generated objects
            Destroy(gameObject);
        }
    }
}
