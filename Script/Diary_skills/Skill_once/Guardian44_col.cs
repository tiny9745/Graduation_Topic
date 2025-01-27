using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian44_col : MonoBehaviour
{
    public GameObject _throw, Img_Guardian;
    public GameObject player;
    public Animator Guardian_44;

    float bullet_time = 0;
    float bullet_time_max = 10f;
    float Guardian44_to_player_distance = 0;
    private bool isFacingRight = true;

    void Start()
    {
        DontDestroyOnLoad(this);
        Guardian44_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 5;
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
            bullet_time_max = Random.Range(10f, 20f);
            bullet_time = 0;
            Guardian_44.SetTrigger("Plant_Guard04_atk");
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
            Vector3 targetPosition = player.transform.position - directionToPlayer * Guardian44_to_player_distance;
            targetPosition.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }
}
