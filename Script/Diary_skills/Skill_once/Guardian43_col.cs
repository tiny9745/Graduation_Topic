using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian43_col : MonoBehaviour
{
    
    public GameObject _throw, Img_Guardian;
    public GameObject player;
    public Animator Guardian_43;

    float bullet_time = 0;
    float bullet_time_max = 5f;
    float Guardian43_to_player_distance = 0;
    private bool isFacingRight = true;

    void Start()
    {
        DontDestroyOnLoad(this);
        Guardian43_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 5;
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
            bullet_time_max = Random.Range(5f, 10f);
            bullet_time = 0;
            Guardian_43.SetTrigger("plant_guard03_atk");
            Invoke("bullet_fire", 3f);
        }
        NPC_distance_out();
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
            Instantiate(_throw, player.transform.position, player.transform.rotation);
        }
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - directionToPlayer * Guardian43_to_player_distance;
            targetPosition.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
