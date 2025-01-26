using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian41_col : MonoBehaviour
{
    public GameObject bullet, Img_Guardian;
    public Transform Firepoint;
    private GameObject player;
    public Animator Guardian_41;

    float bullet_time = 0;
    float bullet_time_max = 8f;
    float Guardian41_to_player_distance = 0;
    private bool isFacingRight = true;

    private bool Ready = false;

    void Start()
    {
        Guardian41_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 5;
        GameObject player = GameObject.Find("Player_S");
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
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "NPC")
        {
            GameObject closestNPC = FindClosestNPCWithinCollider();
            if (closestNPC != null)
            {
                if (closestNPC.transform.position.x > transform.position.x && !isFacingRight)
                {
                    Debug.Log("Guardian41_col:Flip_n");
                    Flip();
                }
                else if (closestNPC.transform.position.x < transform.position.x && isFacingRight)
                {
                    Debug.Log("Guardian41_col:Flip_n!");
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
        else
        {
            if (player != null)
            {
                Debug.Log("Guardian41_col:player");
                if (player.transform.position.x > transform.position.x && !isFacingRight)
                {
                    Debug.Log("Guardian41_col:Flip_p");
                    Flip();
                }
                else if (player.transform.position.x < transform.position.x && isFacingRight)
                {
                    Debug.Log("Guardian41_col:Flip_p!");
                    Flip();
                }
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
            Debug.Log("Guardian41_col:"+bullet);
            Instantiate(bullet, Firepoint.position, transform.rotation);
        }
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - directionToPlayer * Guardian41_to_player_distance;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
