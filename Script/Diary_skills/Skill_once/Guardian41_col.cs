using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian41_col : MonoBehaviour
{
    public GameObject bullet;
    public Transform Firepoint;
    private GameObject player;

    float bullet_time = 0;
    float bullet_time_max = 8f;
    float Guardian41_to_player_distance = 0;

    void Start()
    {
        Guardian41_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 5;
        GameObject player = GameObject.FindWithTag("Player");
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
            bullet_time_max = Random.Range(5f, 8f);
            bullet_time = 0;
            bullet_fire();
        }
    }

    private void bullet_fire()
    {
        if (static_parameters.MC_HP > 0)
        {
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
