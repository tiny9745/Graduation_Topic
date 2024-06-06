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
    private Collider hitboxCollider;
    public GameObject TargetObj;
    public Transform hitboxPrefab;
    public static int DetectDistance = 25; public static int NPC02_ATK = 20;
    public static float NPC_HP = 80; public static float npcSpeed = 5f;
    bool hit = false;
    float coordinate_X;
    float coordinate_Z;
    private Vector3 lastPosition;

    private Quaternion initialRotation;
    public GameObject NPC02;

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

        Transform hitboxTransform = transform.Find("Hitbox");
        if (hitboxTransform != null){
            hitboxCollider = hitboxTransform.GetComponent<Collider>();
            DisableHitbox();      
            if (hitboxCollider == null){
                Debug.LogError("No Collider component found on the Hitbox.");
            }
        }else{
            Debug.LogError("No child object named 'Hitbox' found.");
        }
    }
    // Update is called once per frame
    void Update(){
        Transform NPC02_hit = Instantiate(hitboxPrefab, transform.position, Quaternion.identity);
        NPC02_Hit_box NPC02_hit_col = NPC02_hit.GetComponent<NPC02_Hit_box>();
        coordinate_X = NPC02_hit_col.coordinate_X;
        coordinate_Z = NPC02_hit_col.coordinate_Z;
        if (hit == false)
        {
            if (transform.position != lastPosition)
            {
                if (coordinate_X >= 0 && coordinate_Z >= 0)
                {
                    animator.Play("Robot_stand_RB");
                }
                if (coordinate_X <= 0 && coordinate_Z >= 0)
                {
                    animator.Play("Robot_stand_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z <= 0)
                {
                    animator.Play("Robot_stand_LF");
                }
                if (coordinate_X >= 0 && coordinate_Z <= 0)
                {
                    animator.Play("Robot_stand_RF");
                }
            }
            else
            {
                if (coordinate_X >= 0 && coordinate_Z >= 0)
                {
                    animator.Play("Robot_walk_RB");
                }
                if (coordinate_X <= 0 && coordinate_Z >= 0)
                {
                    animator.Play("Robot_walk_LB");
                }
                if (coordinate_X <= 0 && coordinate_Z <= 0)
                {
                    animator.Play("Robot_walk_LF");
                }
                if (coordinate_X >= 0 && coordinate_Z <= 0)
                {
                    animator.Play("Robot_walk_RF");
                }
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
    }
    public int getNPC02_ATK(){
        return NPC02_ATK;
    }
    private void OnCollisionEnter(Collision Hit){
        if (NPC_HP <= 0){
            Destroy(gameObject);
            static_parameters.Change_enemy--;
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            NPC02attack();
        }
    }

    private void NPC02attack(){
        EnableHitbox();
        Invoke("DisableHitbox", 1f);
    }

    // Method to enable the hitbox
    public void EnableHitbox(){
        if (hitboxCollider != null){
            hitboxCollider.enabled = true;
        }
    }
    // Method to disable the hitbox
    public void DisableHitbox(){
        if (hitboxCollider != null){
            hitboxCollider.enabled = false;
        }
    }
}
