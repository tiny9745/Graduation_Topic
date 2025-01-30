using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian41_col : MonoBehaviour
{
    public GameObject bullet, Img_Guardian;
    public Transform Firepoint;
    public GameObject player;
    public Animator Guardian_41;

    float bullet_time = 0;
    float bullet_time_max = 8f;
    float Guardian41_to_player_distance = 0;
    private bool isFacingRight = true;
    private bool Ready = false, npc_distance = false;

    private Queue<Vector3> playerPath = new Queue<Vector3>(); // 儲存 player 走過的路徑點
    private float pathLength = 0f; // 記錄路徑總長度
    private Vector3 lastPlayerPosition;

    void Start()
    {
        DontDestroyOnLoad(this);
        Guardian41_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 5;
        player = GameObject.Find("Player_S");
        lastPlayerPosition = player.transform.position;
    }

    void Update()
    {
        FollowPlayer();
        if (bullet_time < bullet_time_max)
        {
            bullet_time += Time.deltaTime;
        }
        else
        {
            bullet_time_max = UnityEngine.Random.Range(5f, 8f);
            bullet_time = 0;
            Ready = true;
        }
        if (!npc_distance)
        {
            NPC_distance_out();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "NPC")
        {
            npc_distance = true;
            GameObject closestNPC = FindClosestNPCWithinCollider();
            if (closestNPC != null)
            {
                if (closestNPC.transform.position.x > transform.position.x && !isFacingRight)
                {
                    Flip();
                }
                else if (closestNPC.transform.position.x < transform.position.x && isFacingRight)
                {
                    Flip();
                }
            }
            if (Ready)
            {
                Invoke("bullet_fire", 0.5f);
                Guardian_41.SetTrigger("Plant_guard01_ATK");
                Ready = false;
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "NPC")
        {
            npc_distance = false;
        }
    }

    private void NPC_distance_out()
    {
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x && !isFacingRight)
            {
                Flip();
            }
            else if (player.transform.position.x < transform.position.x && isFacingRight)
            {
                Flip();
            }
        }
    }

    private GameObject FindClosestNPCWithinCollider()
    {
        Collider selfCollider = GetComponent<Collider>();
        if (selfCollider == null) return null;

        Collider[] hitColliders = Physics.OverlapBox(selfCollider.bounds.center, selfCollider.bounds.extents / 2, Quaternion.identity);
        GameObject closestNPC = null;
        float closestDistance = float.MaxValue;

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("NPC"))
            {
                float distance = (hitCollider.transform.position - transform.position).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestNPC = hitCollider.gameObject;
                }
            }
        }
        return closestNPC;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = Img_Guardian.transform.localScale;
        theScale.x *= -1;
        Img_Guardian.transform.localScale = theScale;
    }

    private void bullet_fire()
    {
        if (static_parameters.MC_HP > 0)
        {
            Instantiate(bullet, Firepoint.position, transform.rotation);
        }
    }

    private void UpdatePlayerPath()
    {
        Vector3 currentPlayerPosition = player.transform.position;
        float segmentLength = Vector3.Distance(lastPlayerPosition, currentPlayerPosition);

        if (segmentLength > 0)
        {
            playerPath.Enqueue(currentPlayerPosition);
            pathLength += segmentLength;

            // 移除過長的路徑，保持總長度接近 Guardian44_to_player_distance
            while (pathLength > Guardian41_to_player_distance && playerPath.Count > 1)
            {
                Vector3 removedPoint = playerPath.Dequeue();
                pathLength -= Vector3.Distance(removedPoint, playerPath.Peek());
            }

            lastPlayerPosition = currentPlayerPosition;
        }
    }

    private void FollowPlayer()
    {
        UpdatePlayerPath();

        if (playerPath.Count > 0)
        {
            Vector3 targetPosition = playerPath.Peek(); // 取出最舊的點
            targetPosition.y = transform.position.y; // 保持 Y 軸不變
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);

            // 如果已經接近目標點，則從佇列移除該點
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                playerPath.Dequeue();
            }
        }
    }
}
