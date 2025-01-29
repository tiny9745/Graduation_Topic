using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian42_col : MonoBehaviour
{
    public GameObject bullet, Img_Guardian;
    public Transform Firepoint01, Firepoint02;
    public GameObject player;
    public Animator Guardian_42;

    float bullet_time = 0;
    float bullet_time_max = 3f;
    float Guardian42_to_player_distance = 0;
    private bool isFacingRight = true;
    private bool Ready = false, npc_distance = false;
    private bool bullet_fire_flag = false;
    void Start()
    {
        DontDestroyOnLoad(this);
        Guardian42_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 10;
        player = GameObject.Find("Player_S");
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
            bullet_time_max = Random.Range(1f, 3f);
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
                Invoke("bullet_fire", 0.7f);
                bullet_fire_flag = !bullet_fire_flag;
                if (bullet_fire_flag)
                {
                    Guardian_42.SetTrigger("Plant_guard02-1_ATK");
                }
                else
                {
                    Guardian_42.SetTrigger("Plant_guard02-2_ATK");
                }
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
            if (bullet_fire_flag)
            {
                Instantiate(bullet, Firepoint01.position, transform.rotation);
            }
            else
            {
                Instantiate(bullet, Firepoint02.position, transform.rotation);
            }
        }
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - directionToPlayer * Guardian42_to_player_distance;
            targetPosition.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
