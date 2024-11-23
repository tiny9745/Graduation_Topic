using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Throw : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5f,lifetime = 3f;
    public int damage = 10,R=1;
    public GameObject targetObject;
    Vector3 moveDirection;
    Transform targetTransform;
    void Start()
    {
        targetObject = GameObject.Find("Hitbox");
        if (targetObject != null)
        {
            targetTransform = targetObject.transform;
            moveDirection = targetTransform.forward;
        }
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            if(R>0)
            {
                // 找尋場景中所有標籤為 "NPC" 的物件
                GameObject nearestNPC = FindNearestNPC();
                if (nearestNPC != null)
                {
                    // 將方向調整至距離最近的 NPC
                    targetObject = nearestNPC;
                }
            }

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
}
