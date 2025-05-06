using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian45_col : MonoBehaviour
{
    public GameObject bullet, Img_Guardian;
    public Transform Firepoint;
    public GameObject player;
    public Animator Guardian_45;

    float bullet_time = 0;
    float bullet_time_max = 15f;
    float Guardian45_to_player_distance = 0;
    private bool isFacingRight = true;
    private bool Ready = false, npc_distance = false;

    void Start()
    {
        DontDestroyOnLoad(this);
        Guardian45_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 6f;
        Skill_public_funtion.skill_4x_Sorting++;
        player = GameObject.Find("Player_S");
        if (this.transform.rotation.eulerAngles.y != 0)
        {
            Vector3 euler = transform.rotation.eulerAngles;
            euler.y = 0;
            transform.rotation = Quaternion.Euler(euler);
        }
    }

    void Update()
    {
        FollowPlayer();
        if (static_parameters.MC_HP > 0 && static_parameters.Change_enemy != 0)
        {
            if (bullet_time < bullet_time_max)
            {
                bullet_time += Time.deltaTime;
            }
            else
            {
                bullet_time_max = Random.Range(12f, 15f);
                bullet_time = 0;
                Ready = true;
            }
        }
        if (!npc_distance)
        {
            NPC_distance_out();
        }
        MC_Dead();
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
                Guardian_45.SetTrigger("Plant_guard01_ATK");
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

    private float orbitAngle = 0f; // 當前角度 (度數)
    private float linearSpeed = 6.5f; // 固定線速度 (單位/秒)

    // 確保 `orbitAngle` 根據 `linearSpeed` 和 `Guardian45_to_player_distance` 來計算角速度
    private void FollowPlayer()
    {
        if (player != null)
        {
            // 確保半徑不為零，避免除以零錯誤
            if (Guardian45_to_player_distance <= 0.01f)
                Guardian45_to_player_distance = 0.01f;

            float orbitSpeed = (linearSpeed / Guardian45_to_player_distance) * Mathf.Rad2Deg;

            orbitAngle += orbitSpeed * Time.deltaTime;

            if (orbitAngle >= 360f)
                orbitAngle -= 360f;

            float radian = orbitAngle * Mathf.Deg2Rad; // 轉換為弧度

            Vector3 orbitOffset = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian)) * Guardian45_to_player_distance;

            Vector3 targetPosition = player.transform.position + orbitOffset;
            targetPosition.y = transform.position.y; // 保持高度不變

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }

    private void MC_Dead()
    {
        if (static_parameters.MC_HP <= 0||player == null)
        {
            Destroy(gameObject);
        }
    }
}
