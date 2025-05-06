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
    private bool Ready = false;
    private bool bullet_fire_flag = false;

    private Queue<Vector3> playerPath = new Queue<Vector3>();
    private float pathLength = 0f;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        DontDestroyOnLoad(this);
        Guardian42_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 6f;
        Skill_public_funtion.skill_4x_Sorting++;
        player = GameObject.Find("Player_S");
        lastPlayerPosition = player.transform.position;
        if (this.transform.rotation.eulerAngles.y != 0)
        {
            Vector3 euler = transform.rotation.eulerAngles;
            euler.y = 0;
            transform.rotation = Quaternion.Euler(euler);
        }
    }

    void Update()
    {
        if (static_parameters.MC_HP <= 0 || player == null)
        {
            MC_Dead();
            return;
        }
        FollowPlayer();
        UpdateBulletTime();
        FaceNearestNPC();
    }

    private void UpdateBulletTime()
    {
        if (static_parameters.MC_HP > 0 && static_parameters.Change_enemy != 0)
        {
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
        }

    }

    private void FaceNearestNPC()
    {
        GameObject closestNPC = FindClosestNPCWithinCollider();
        if (closestNPC != null)
        {
            FaceTarget(closestNPC.transform);
            if (Ready)
            {
                Invoke("bullet_fire", 0.7f);
                bullet_fire_flag = !bullet_fire_flag;
                Guardian_42.SetTrigger(bullet_fire_flag ? "Plant_guard02-1_ATK" : "Plant_guard02-2_ATK");
                Ready = false;
            }
        }
        else
        {
            FaceTarget(player.transform);
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

    private void FaceTarget(Transform target)
    {
        if (target == null) return;
        if (target.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (target.position.x < transform.position.x && isFacingRight)
        {
            Flip();
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
            Instantiate(bullet, bullet_fire_flag ? Firepoint01.position : Firepoint02.position, transform.rotation);
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

            while (pathLength > Guardian42_to_player_distance && playerPath.Count > 1)
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
        if (player != null)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - directionToPlayer * Guardian42_to_player_distance;
            targetPosition.y = transform.position.y;

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }

    private void MC_Dead()
    {
        Destroy(gameObject);
    }
}