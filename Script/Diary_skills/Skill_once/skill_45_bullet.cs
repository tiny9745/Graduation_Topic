using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_45_bullet : MonoBehaviour
{
    float speed = 30f;
    private GameObject targetObject;
    Vector3 moveDirection;
    Transform targetTransform;
    public Animator Guardian_45_bullet;
    private bool isFacingRight = true;
    void Start()
    {
        targetObject = GameObject.Find("Player_S");
        if (targetObject != null)
        {
            float angle_NPC = FindNearestNPCAngle();
            targetTransform = targetObject.transform;
            float radians = angle_NPC * Mathf.Deg2Rad; // 將角度轉為弧度
            moveDirection = new Vector3(Mathf.Sin(radians), 0, Mathf.Cos(radians)); // 計算絕對方向向量
        }
    }

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
                if (npc.transform.position.x > transform.position.x && !isFacingRight)
                {
                    Flip();
                }
                else if (npc.transform.position.x < transform.position.x && isFacingRight)
                {
                    Flip();
                }
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
            Guardian_45_bullet.SetTrigger("bullet45");
            Destroy(gameObject, 0.11f);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }
}
