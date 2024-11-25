using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Throw : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 15f, lifetime = 3f;
    public int damage = 10, R = 1;
    public GameObject targetObject;
    Vector3 moveDirection;
    Transform targetTransform;
    void Start()
    {
        targetObject = GameObject.Find("Hitbox");
        if (targetObject != null)
        {
            float angle_NPC = FindNearestNPCAngle();
            targetTransform = targetObject.transform;
            // moveDirection = -angle_NPC * Vector3.forward;
            moveDirection = -targetTransform.forward;
            // Debug.Log($"發射子彈，角度為: {angle_NPC} 度");
        }
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
    }
    GameObject FindNearestNPC()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC"); // 獲取所有 Tag 為 "NPC" 的物件
        GameObject nearestNPC = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestNPC = npc;
            }
        }
        return nearestNPC;
    }

    public float FindNearestNPCAngle()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        GameObject nearestNPC = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);
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

            Debug.Log($"最近的 NPC 是: {nearestNPC.name}，距離為: {shortestDistance}，與 MC 的角度為: {angle} 度");
            return angle;
        }

        Debug.LogWarning("未找到任何 NPC");
        return -1;
    }
}
