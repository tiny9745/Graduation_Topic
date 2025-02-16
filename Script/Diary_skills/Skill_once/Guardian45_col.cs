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
        Guardian45_to_player_distance = Skill_public_funtion.skill_4x_Sorting * 5;
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
            bullet_time_max = Random.Range(12f, 15f);
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

    private float orbitSpeed = 360f / 2f; // 2 秒繞一圈，每秒旋轉 180 度
    private void FollowPlayer()
    {
        if (player != null)
        {
            float angle = Time.time * orbitSpeed; // 依時間變化的角度 (度數)
            float radian = angle * Mathf.Deg2Rad; // 轉換為弧度

            // 以 Guardian45_to_player_distance 作為繞圈半徑
            Vector3 orbitOffset = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian)) * Guardian45_to_player_distance;

            // 設定新位置
            Vector3 targetPosition = player.transform.position + orbitOffset;
            targetPosition.y = transform.position.y; // 保持當前高度

            // 平滑移動
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        }
    }

}
