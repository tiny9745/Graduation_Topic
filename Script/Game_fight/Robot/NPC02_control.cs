using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC02_control : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent npcNavi;
    public Animator animator;
    public GameObject TargetObj;
    int DetectDistance = 20; int NPC02_ATK = 20;
    float NPC_HP = 80; float npcSpeed = 5f;
    bool hit_Ani = false;
    bool hit = false;
    float coordinate_X;
    float coordinate_Z;
    private Vector3 lastPosition;
    private Quaternion initialRotation;
    public GameObject NPC02;
    public GameObject hitbox_Robot;

    void Start()
    {
        initialRotation = transform.rotation;
        NPC02 = GameObject.Find("NPC02");
        if (NPC02 != null){
            Renderer renderer = NPC02.GetComponent<Renderer>();
            if (renderer != null){
                renderer.enabled = false;
            };
        }
        hitbox_Robot.SetActive(false);
    }
    // Update is called once per frame
    void Update(){
        if (hit_Ani == false)
        {
            if (transform.position != lastPosition)
            {
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    animator.Play("Robot_stand_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    animator.Play("Robot_stand_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    animator.Play("Robot_stand_LF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    animator.Play("Robot_stand_RF");
                }
            }
            else
            {
                if (coordinate_X >= 0 && coordinate_Z > 0)
                {
                    animator.Play("Robot_walk_RB");
                }
                if (coordinate_X < 0 && coordinate_Z >= 0)
                {
                    animator.Play("Robot_walk_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z < 0)
                {
                    animator.Play("Robot_walk_LF");
                }
                if (coordinate_X > 0 && coordinate_Z <= 0)
                {
                    animator.Play("Robot_walk_RF");
                }
            }
        }
        else
        {
            if (coordinate_X >= 0 && coordinate_Z > 0)
            {
                animator.Play("Robot_Att_RB");
            }
            if (coordinate_X < 0 && coordinate_Z >= 0)
            {
                animator.Play("Robot_Att_LB");
            }
            if (coordinate_X <= 0 && coordinate_Z < 0)
            {
                animator.Play("Robot_Att_LF");
            }
            if (coordinate_X > 0 && coordinate_Z <= 0)
            {
                animator.Play("Robot_Att_RF");
            }
        }
        lastPosition = transform.position;

        transform.rotation = initialRotation;
        if (TargetObj == null){
            TargetObj = GameObject.Find("Player");
            npcNavi = GetComponent<NavMeshAgent>();
            // Set the speed after each acquisition of the NavMeshAgent component
            if (npcNavi != null){
                npcNavi.speed = npcSpeed;
            }
        }else{
            float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
            if (dist < DetectDistance && NPC_HP > 0){
                npcNavi.destination = TargetObj.transform.position;
            }else{
                npcNavi.destination = transform.position;
            }
        }
        coordinate_X = TargetObj.transform.position.x - transform.position.x;
        coordinate_Z = TargetObj.transform.position.z - transform.position.z;
    }
    public int GetNPC02_ATK(){
        return NPC02_ATK;
    }
    public bool GetNPC02_hit()
    {
        return hit;
    }
    private void OnCollisionEnter(Collision Hit){
        if (NPC_HP <= 0){
            Destroy(gameObject);
            static_parameters.Change_enemy--;
        }
    }
    private void OnTriggerEnter(Collider other){
        //EnableHitbox();
        
        if (other.gameObject.tag == "Player"){
            hit_Ani = true;
            Invoke("EnableHitbox", 1.15f); 
        }
    }

    // Method to enable the hitbox
    void EnableHitbox(){
        hitbox_Robot.SetActive(true);
        hit = false;
        Invoke("EndAttANimation", 0.85f);
    }
    void EndAttANimation()
    {
        hit_Ani = false;
    }
}
