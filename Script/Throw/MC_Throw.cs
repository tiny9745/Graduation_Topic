using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Throw : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 15f, lifetime = 3f;
    public int damage = 10;
    public GameObject targetObject;
    Vector3 moveDirection;
    Transform targetTransform;
    private Animator skill13_animator;
    void Start()
    {
        targetObject = GameObject.Find("Player_S");
        skill13_animator = GetComponent<Animator>();
        if (targetObject != null)
        {
            float angle_NPC = FindNearestNPCAngle();
            targetTransform = targetObject.transform;
            // moveDirection = -targetTransform.forward;
            float radians = angle_NPC * Mathf.Deg2Rad; // 將角度轉為弧度
            moveDirection = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians)); // 計算絕對方向向量
        }
        Destroy(gameObject, lifetime);
        if (skill13_animator != null)
        {
            if (Skill_public_funtion.skill_13_bullet_atk != 1f)
            {
                skill13_animator.SetBool("skill13", true);
            }
            else
            {
                skill13_animator.SetBool("skill13", false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }

    public float FindNearestNPCAngle()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        GameObject nearestNPC = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(targetObject.transform.position, npc.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestNPC = npc;
            }
        }

        if (nearestNPC != null)
        {
            Vector3 directionToNPC = (nearestNPC.transform.position - transform.position).normalized;
            float angle = Vector3.SignedAngle(transform.forward, directionToNPC, Vector3.up);
            return angle;
        }
        return -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Destroy(gameObject);
        }
    }
}
