using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class skill_41_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator bullet_41;
    public GameObject targetObject;
    Vector3 moveDirection;
    Transform targetTransform;
    float lifetime = 10f;
    void Start()
    {
        targetObject = GameObject.Find("Player_S");
        if (targetObject != null)
        {
            float angle_NPC = FindNearestNPCAngle();
            targetTransform = targetObject.transform;
            // moveDirection = -targetTransform.forward;
            float radians = angle_NPC * Mathf.Deg2Rad; // 將角度轉為弧度
            moveDirection = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians)); // 計算絕對方向向量
        }
        Destroy(gameObject, lifetime);
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "NPC")
        {
            bullet_41.SetTrigger("bullet_41_atk");
           Invoke("Destroy", 0.11f);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
